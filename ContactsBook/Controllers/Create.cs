using ContactsBook.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContactsBook.Models;

namespace ContactsBook.Controllers
{
    public class Create
    {
        public void AddUser(ContactContext db)
        {
            Console.WriteLine("");
            Console.WriteLine("ADD USER:");
            var contact = new Contact();
            // CONTACT INFORMATION
            Console.Write("Please enter the First Name: ");
            contact.FirstName = InputValidators.CheckNoInput();
            Console.Write("Please enter the Last Name: ");
            contact.LastName = InputValidators.CheckNoInput();
            Console.Write("Please enter the Age: ");
            contact.Age = InputValidators.CheckNumberInput();
            contact.Active = true;

            // CONTACT EMAIL INFORMATION
            Console.Write("Would you like to add the Email? [Y/n] ");
            var email = new EmailModel();
            if (InputValidators.CheckYesOrNo())
            {
                email = AddEmail(db);
                if (email.EmailId == 0)
                {
                    contact.EmailId = db.Emails.Count() + 1;
                    db.Emails.Add(email);
                }
                if (email.EmailId > 0)
                {
                    contact.EmailId = email.EmailId;
                }
            }

            // CONTACT ADDRESS INFORMATION
            Console.Write("Would you like to add the Address? [Y/n] ");
            var address = new AddressModel();

            if (InputValidators.CheckYesOrNo())
            {
                address = AddAddress(db);
                if (address.AddressId == 0)
                {
                    contact.AddressId = db.Addresses.Count() + 1;
                    db.Addresses.Add(address);
                }
                if (address.AddressId > 0)
                {
                    contact.AddressId = address.AddressId;
                }
            }

            // CONTACT PHONE INFORMATION
            Console.Write("Would you like to add the Phone? [Y/n] ");
            var phone = new PhoneModel();

            if (InputValidators.CheckYesOrNo())
            {
                phone = AddPhone(db);
                if (phone.PhoneId == 0)
                {
                    contact.PhoneId = db.Phones.Count() + 1;
                    db.Phones.Add(phone);
                }
                if (phone.PhoneId > 0)
                {
                    contact.PhoneId = phone.PhoneId;
                }
            }

            // CONTACT COMPANY INFORMATION
            Console.Write("Would you like to add a Company? [Y/n] ");
            var addCompany = InputValidators.CheckYesOrNo();

            var company = new CompanyModel();
            var companyEmail = new EmailModel();
            var companyAddress = new AddressModel();
            var companyPhone = new PhoneModel();


            var contactSearch = db.Contacts.FirstOrDefault(
                ñ =>
                    ñ.FirstName == contact.FirstName
                    &&
                    ñ.LastName == contact.LastName
                    &&
                    ñ.Age == contact.Age
                    &&
                    (
                        ñ.EmailId == contact.EmailId
                        ||
                        ñ.AddressId == contact.AddressId
                        ||
                        ñ.PhoneId == contact.PhoneId
                    )
            );
            
            if (addCompany)
            {
                company = AddCompany(db);
                if (company.CompanyId == 0)
                {
                    contact.CompanyId = db.Companies.Count() + 1;
                    db.Companies.Add(company);
                }
                if (company.CompanyId > 0)
                {
                    contact.CompanyId = company.CompanyId;
                }
            }

            if (contactSearch == null)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("WARNING: The user you are trying to insert already exists");
            }

            if (addCompany)
            {
                Console.Write("Would you like to add the Email? [Y/n] ");
                if (InputValidators.CheckYesOrNo())
                {
                    companyEmail = AddEmail(db);
                    if (companyEmail.EmailId == 0)
                    {
                        company.EmailId = db.Emails.Count() + 1;
                        db.Emails.Add(companyEmail);
                    }
                    if (companyEmail.EmailId > 0)
                    {
                        company.EmailId = companyEmail.EmailId;
                    }
                }

                Console.Write("Would you like to add the Address? [Y/n] ");
                if (InputValidators.CheckYesOrNo())
                {
                    companyAddress = AddAddress(db);
                    if (companyAddress.AddressId == 0)
                    {
                        company.AddressId = db.Addresses.Count() + 1;
                        db.Addresses.Add(companyAddress);
                    }
                    if (companyAddress.AddressId > 0)
                    {
                        company.AddressId = companyAddress.AddressId;
                    }
                }

                Console.Write("Would you like to add the Phone? [Y/n] ");
                if (InputValidators.CheckYesOrNo())
                {
                    companyPhone = AddPhone(db);
                    if (companyPhone.PhoneId == 0)
                    {
                        company.PhoneId = db.Phones.Count() + 1;
                        db.Phones.Add(companyPhone);
                    }
                    if (companyPhone.PhoneId > 0)
                    {
                        company.PhoneId = companyPhone.PhoneId;
                    }
                }
            }
            db.SaveChanges();
        }

        private static EmailModel AddEmail(ContactContext db)
        {
            Console.Write("Please enter the Email: ");
            var checkNoInput = InputValidators.CheckNoInput();
            string contactEmailAddress = checkNoInput;
            var emailModel = new EmailModel();

            if (contactEmailAddress != null)
            {
                contactEmailAddress = contactEmailAddress.Trim();
                var contactEmail = new MailAddress(contactEmailAddress);
                var contactEmailLocal = contactEmail.User;
                var contactEmailHost = contactEmail.Host;

                emailModel.LocalPart = contactEmailLocal;
                emailModel.Domain = contactEmailHost;

                var emailSearch = db.Emails.FirstOrDefault(
                    ñ =>
                        ñ.LocalPart.ToLower() == emailModel.LocalPart.ToLower()
                        &&
                        ñ.Domain.ToLower() == emailModel.Domain.ToLower()
                );

                if (emailSearch == null)
                {
                    return emailModel;
                }
                emailModel.EmailId = emailSearch.EmailId;
                return emailModel;
            }

            return new EmailModel
            {
                EmailId = -1
            };
        }

        private static PhoneModel AddPhone(ContactContext db)
        {
            Console.Write("Please enter the Phone Number: ");
            var checkNoInput = InputValidators.CheckNoInput();
            string phoneNumber = checkNoInput;
            var phoneModel = new PhoneModel();

            if (phoneNumber != null)
            {
                phoneNumber = Regex.Replace(phoneNumber, @"[^\d]", "");
                phoneNumber = phoneNumber.Trim();

                if (phoneNumber.Length == 10)
                {
                    phoneModel.AreaCode = Convert.ToInt32(phoneNumber.Substring(0, 3));
                    phoneModel.Prefix = Convert.ToInt32(phoneNumber.Substring(3, 3));
                    phoneModel.Number = Convert.ToInt32(phoneNumber.Substring(6, 4));

                    // TODO: VALIDATE THAT IS ON THE SAME LINE
                    var phoneSearch = db.Phones.FirstOrDefault(
                        ñ =>
                            ñ.AreaCode == phoneModel.AreaCode
                            &&
                            ñ.Prefix == phoneModel.Prefix
                            &&
                            ñ.Number == phoneModel.Number
                    );

                    if (phoneSearch == null)
                    {
                        return phoneModel;
                    }
                    phoneModel.PhoneId = phoneSearch.PhoneId;
                    return phoneModel;
                }
            }
            return new PhoneModel
            {
                PhoneId = -1
            };
        }

        private static AddressModel AddAddress(ContactContext db)
        {
            var addressModel = new AddressModel();
            Console.Write("Please enter the Street Number: ");
            var number = InputValidators.CheckNumberInput();
            Console.Write("Please enter the Street Name: ");
            var street = InputValidators.CheckNoInput();
            Console.Write("Please enter the City: ");
            var city = InputValidators.CheckNoInput();
            Console.Write("Please enter the State: ");
            var state = InputValidators.CheckNoInput();
            Console.Write("Please enter the Zip Code: ");
            var zip = InputValidators.CheckNumberInput();

            if (number > 0 || street != "" || city != "" || state != "" || zip > 0)
            {
                addressModel.StreetNumber = number;
                addressModel.StreetName = street;
                addressModel.City = city;
                addressModel.State = state.Trim();
                addressModel.ZipCode = zip;

                // TODO: VALIDATE THAT IS ON THE SAME LINE
                var addressSearch = db.Addresses.FirstOrDefault(
                    ñ =>
                        ñ.StreetNumber == addressModel.StreetNumber
                        &&
                        ñ.StreetName.ToLower() == addressModel.StreetName.ToLower()
                        &&
                        ñ.City.ToLower() == addressModel.City.ToLower()
                        &&
                        ñ.State.ToLower().Trim() == addressModel.State.ToLower().Trim()
                        &&
                        ñ.ZipCode == addressModel.ZipCode
                );

                if (addressSearch == null)
                {
                    return addressModel;
                }
                addressModel.AddressId = addressSearch.AddressId;
                return addressModel;
            }
            return new AddressModel()
            {
                AddressId = -1
            };
        }

        private static CompanyModel AddCompany(ContactContext db)
        {
            var companyModel = new CompanyModel();
            Console.Write("Please enter the Company Name: ");
            var name = InputValidators.CheckNoInput();

            if (name != "")
            {
                companyModel.Name = name;
                var companySearch = db.Companies.FirstOrDefault(
                    ñ => ñ.Name.ToLower() == companyModel.Name.ToLower());

                if (companySearch == null)
                {
                    return companyModel;
                }
                companyModel.CompanyId = companySearch.CompanyId;
                return companyModel;
            }
            return companyModel;
        }
    }
}
