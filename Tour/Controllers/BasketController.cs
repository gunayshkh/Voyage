using Microsoft.AspNetCore.Mvc;

namespace Voyage.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
