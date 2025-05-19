using System.ComponentModel.DataAnnotations;

namespace prjPlayerCardTrader.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public decimal CardPrice { get; set; }
        public string Imageurl { get; set; }
    }


}
