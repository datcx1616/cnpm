using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("Posts")]
    public class Posts
    {
        [Key]
        public int id { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
        public string? image { get; set; }
        public DateTime? createdAt { get; set; }
        public int? View { get; set; }
        public bool? IsHot { get; set; }
    }
}
