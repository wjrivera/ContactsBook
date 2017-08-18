using System.Data.Entity;
using ContactsBook.Models;

namespace ContactsBook.Entity
{
    // Entity for the Project
    public class ContactContext : DbContext
    {
        // Name of our database is: Contacts
        public ContactContext() : base("Contacts") { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<EmailModel> Emails { get; set; }
        public DbSet<PhoneModel> Phones { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
    }
}
