using Microsoft.AspNetCore.Mvc;

namespace Voyage.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
