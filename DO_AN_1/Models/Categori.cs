using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table ("Categories")]
    public class Categori
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? controllerName { get; set; }
        public string? actionName { get; set; }
        public string? Images { get; set; }
        public int? itemOrder { get; set; }
        public bool? isActive { get; set; }
        public bool? ItHot { get; set; }
        public int? parent { get; set; }
    }
}
