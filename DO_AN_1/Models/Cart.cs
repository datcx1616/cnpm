using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO_AN_1.Models
{
    [Table("Carts")]
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public int UserID { get; set; }
    }
}
