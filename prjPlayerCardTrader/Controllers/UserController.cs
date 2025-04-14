using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using prjPlayerCardTrader.Data;
using prjPlayerCardTrader.Models;
using static prjPlayerCardTrader.Data.ApplicationDbConnect;

namespace prjPlayerCardTrader.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbConnect _db;

        public UserController(ApplicationDbConnect db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var conn = _db.GetConnection();
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Users WHERE Email = @Email AND Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Password", model.Password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                HttpContext.Session.SetInt32("UserID", (int)reader["UserID"]);
                HttpContext.Session.SetString("FirstName", (string)reader["FirstName"].ToString());
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login.");
            return View(model);
        }
    }
}
