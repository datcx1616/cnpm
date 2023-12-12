using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("view_Cart_Product")]
    public class view_Cart_Product
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public int UserID { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
}
