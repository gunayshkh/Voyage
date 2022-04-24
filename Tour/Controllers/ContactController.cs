using Microsoft.AspNetCore.Mvc;

namespace Voyage.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
