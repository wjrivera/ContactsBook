using System.ComponentModel.DataAnnotations;

namespace ContactsBook.Models
{
    public class PhoneModel
    {
        [Key]
        public int PhoneId { get; set; }
        public int AreaCode { get; set; }
        public int Prefix { get; set; }
        public int Number { get; set; }
    }
}
