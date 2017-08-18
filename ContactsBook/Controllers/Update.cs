using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBook.Entity;

namespace ContactsBook.Controllers
{
    public class Update
    {
        // TODO: CHECK IF THE USER IS THE ONLY ONE THAT HAS EMAIL, ADDRESSES AND PHONE NUMBERS
        public void DeactivateUser(ContactContext db)
        {
            Console.Write("Please enter the User ID you want to DEACTIVATE: ");
            var checkNumberInput = InputValidators.CheckNumberInput();
            var input = checkNumberInput;
            var user = db.Contacts.FirstOrDefault(ñ => ñ.ContactId == input);
            if (user != null)
            {
                user.Active = false;
                db.SaveChanges();
            }
        }

        // TODO: CHECK IF THE USER IS THE ONLY ONE THAT HAS EMAIL, ADDRESSES AND PHONE NUMBERS
        public void ActivateUser(ContactContext db)
        {
            Console.Write("Please enter the User ID you want to ACTIVATE: ");
            var checkNumberInput = InputValidators.CheckNumberInput();
            var input = checkNumberInput;
            var user = db.Contacts.FirstOrDefault(ñ => ñ.ContactId == input);
            if (user != null)
            {
                user.Active = true;
                db.SaveChanges();
            }
        }
    }
}
