using Microsoft.AspNetCore.Mvc;
using prjPlayerCardTrader.Models;
using System.Diagnostics;

namespace prjPlayerCardTrader.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains("UserID"))
                return RedirectToAction("Index", "User");

            ViewBag.Name = HttpContext.Session.GetString("FirstName");
            return View();
        }
    }
}
