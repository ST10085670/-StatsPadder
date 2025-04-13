using Microsoft.AspNetCore.Mvc;
using prjPlayerCardTrader.Models;

namespace prjPlayerCardTrader.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> Index()
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
            return View(products);
        }
    }
}
