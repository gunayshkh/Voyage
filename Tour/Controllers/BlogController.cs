using Microsoft.AspNetCore.Mvc;

namespace Voyage.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
