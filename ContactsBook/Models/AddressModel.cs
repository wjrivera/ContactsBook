using System.ComponentModel.DataAnnotations;

namespace ContactsBook.Models
{
    public class AddressModel
    {
        [Key]
        public int AddressId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
