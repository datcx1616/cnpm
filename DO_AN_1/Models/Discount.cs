using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Image { get; set; }
    }
}
