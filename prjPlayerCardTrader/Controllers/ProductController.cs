using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using prjPlayerCardTrader.Data;
using prjPlayerCardTrader.Models;
using static prjPlayerCardTrader.Data.ApplicationDbConnect;

namespace prjPlayerCardTrader.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _config;

        public ProductController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            var products = new List<Product>();

            using var conn = _config.GetConnectionString("");
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Products", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductID = (int)reader["ProductID"],
                    CardType = reader["CardType"].ToString(),
                    CardName = reader["CardName"].ToString(),
                    CardPrice = Convert.ToDouble(reader["CardPrice"]),
                    Imageurl = reader["ImageUrl"].ToString()
                });
            }

            return View(products);
        }
    }
}
