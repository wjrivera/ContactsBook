using System;
using System.Threading;
using System.Linq;
using ContactsBook.Entity;

namespace ContactsBook.Controllers
{
    public class Read
    {
        public void ListUsers(ContactContext db)
        {
            Console.WriteLine("");
            var query = from b in db.Contacts
                orderby b.ContactId
                select b;

            if (query.Any())
            {
                Console.WriteLine("|======================================================|");
                Console.WriteLine("|======================CONTACTS========================|");
                Console.WriteLine("|======================================================|");

                foreach (var person in query)
                {
                    string currentUser = person.FirstName + " " + person.LastName;
                    Console.WriteLine("| {0,-2}: {1, -20} \t\t Active: {2, -5} |", person.ContactId, currentUser, person.Active);
                }
                Console.WriteLine("|======================================================|\n");
            }
            else
            {
                Console.WriteLine("No Contacts Found\n");
            }
        }
    }
}
