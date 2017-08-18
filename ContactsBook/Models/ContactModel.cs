using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsBook.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public int EmailId { get; set; }
        public int PhoneId { get; set; }
        public int AddressId { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }

        //[ForeignKey("CompanyId")]
        //public virtual CompanyModel CompanyModel { get; set; }
        //[ForeignKey("EmailId")]
        //public virtual AddressModel AddressModel { get; set; }
        //[ForeignKey("PhoneId")]
        //public virtual PhoneModel PhoneModel { get; set; }
        //[ForeignKey("AddressId")]
        //public virtual EmailModel EmailModel { get; set; }
    }
}
