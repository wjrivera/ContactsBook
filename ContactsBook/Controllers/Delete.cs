using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBook.Entity;

namespace ContactsBook.Controllers
{
    public class Delete
    {
        public void DeleteUser(ContactContext db)
        {
            Console.Write("Please enter the User ID you want to DELETE: ");
            var checkNumberInput = InputValidators.CheckNumberInput();
            var user = db.Contacts.FirstOrDefault(ñ => ñ.ContactId == checkNumberInput);
            if (user != null)
            {
                db.Contacts.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
