using Microsoft.AspNetCore.Mvc;

namespace FinalTaskShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
