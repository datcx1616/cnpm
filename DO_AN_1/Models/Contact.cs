
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int categoryid { get; set; }
        public string? Content { get; set; }
        public string? Class { get; set; }
    }
}
