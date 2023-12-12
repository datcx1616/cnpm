using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("products")]
    public class products
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public long? price { get; set; }
        public string? image { get; set; }
        public int? categoryid { get; set; }
        public string? content { get; set; }
        public string? Class { get; set; }
        public bool? isActive { get; set; }
    }
}
