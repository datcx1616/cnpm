
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? View { get; set; }
        public bool? IsHot { get; set; }
        public string? Link { get; set; }
        public bool? IsActive { get; set; }
        public int PostOrder { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }
    }
}
