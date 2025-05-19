using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using prjPlayerCardTrader.Data;
using prjPlayerCardTrader.Models;
using System.Configuration;
using System.Data;
using static prjPlayerCardTrader.Data.ApplicationDbConnect;

namespace prjPlayerCardTrader.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbConnect _db;
        private readonly IConfiguration _configuration;

        public ProductController(ApplicationDbConnect db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }


        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            var connect = _configuration.GetConnectionString("SQL_CONNECTION_STRING");

            try
            {
                using (var connection = new SqlConnection(connect))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM Products";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    ProductID = reader.GetInt32(0),
                                    CardName = reader.GetString(1),
                                    CardType = reader.GetString(2),
                                    CardPrice = reader.GetDecimal(3),
                                    Imageurl = reader.GetString(4)
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest($"Error: {ex.Message}");
            }

            return View(products); // ✅ This will now render your Razor view
        }

    }
}
