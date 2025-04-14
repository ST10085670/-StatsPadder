using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using prjPlayerCardTrader.Data;
using prjPlayerCardTrader.Models;
using static prjPlayerCardTrader.Data.ApplicationDbConnect;

namespace prjPlayerCardTrader.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbConnect _db;

        public ProductController(ApplicationDbConnect db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var products = new List<Product>();

            using var conn = _db.GetConnection();
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Products", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductID = (int)reader["ProductID"],
                    CardName = reader["Name"].ToString(),
                    CardType = reader["Description"].ToString(),
                    CardPrice = (double)reader["Price"],
                    Imageurl = reader["Image"].ToString()

                });
            }

            return View(products);
        }
    }
}
