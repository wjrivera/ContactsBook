using System.ComponentModel.DataAnnotations;

namespace ContactsBook.Models
{
    public class EmailModel
    {
        [Key]
        public int EmailId { get; set; }
        public string LocalPart { get; set; }
        public string Domain { get; set; }
    }
}
