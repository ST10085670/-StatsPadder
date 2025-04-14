using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjPlayerCardTrader.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        public DateTime PurDate { get; set; }

        //Nav properties for relationships

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
