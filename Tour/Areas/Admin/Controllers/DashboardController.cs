using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Voyage.DAL;

namespace Voyage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly VoyageDbContext _db;

        public DashboardController(VoyageDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            //var trips = await _db.Trips.ToListAsync();
            return View();
        }
    }
}
