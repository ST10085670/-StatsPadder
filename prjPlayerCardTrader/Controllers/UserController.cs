using Microsoft.AspNetCore.Mvc;
using prjPlayerCardTrader.Models;

namespace prjPlayerCardTrader.Controllers
{
    public class UserController : Controller
    {

        private readonly HttpClient _httpClient;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _httpClient.PostAsJsonAsync("api/auth/login", model);

            if (response.IsSuccessStatusCode)
            {
                // Redirect to home after login
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
    }
}
