using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Voyage.DAL;

namespace Voyage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController: Controller
    {
        private readonly VoyageDbContext _db;

        public UserController(VoyageDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
