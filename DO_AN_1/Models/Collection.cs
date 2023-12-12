using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("Collection")]
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}
