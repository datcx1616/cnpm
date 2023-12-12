using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? controllerName { get; set; }
        public string? actionName { get; set; }
        public int parent { get; set; }
        public int itemOrder { get; set; }
        public bool? isActive { get; set; }
       public string? Link { get; set; }
        public int? Levels { get; set; }
        public int? Position { get; set; }
    }
}
