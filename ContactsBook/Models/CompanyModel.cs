using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsBook.Models
{
    public class CompanyModel
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int EmailId { get; set; }
        public int PhoneId { get; set; }
        public int AddressId { get; set; }

        //[ForeignKey("EmailId")]
        //public virtual AddressModel AddressModel { get; set; }
        //[ForeignKey("PhoneId")]
        //public virtual PhoneModel PhoneModel { get; set; }
        //[ForeignKey("AddressId")]
        //public virtual EmailModel EmailModel { get; set; }
    }
}
