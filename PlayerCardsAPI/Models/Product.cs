using System.ComponentModel.DataAnnotations;

namespace PlayerCardsAPI.Models
{
    public class Product
    {
        [Key]

        public int ProductID { get; set; }

        public string CardName { get; set; }
        
        public string CardType { get; set; }
       
        public double CardPrice { get; set; }

        public String Imageurl { get; set; }
        

        //Nav property for related Registrations
        public ICollection<Purchase> Purchases { get; set; }
    }

   
}
