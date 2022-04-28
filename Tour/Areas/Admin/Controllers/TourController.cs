using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Voyage.DAL;
using Voyage.Models.ViewModels;

namespace Voyage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TourController:Controller
    {
        private readonly VoyageDbContext _db;

        public TourController(VoyageDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var trips = await _db.Trips.ToListAsync();
            return View(trips);
        }
        public async Task<IActionResult> Details(int id)
        {
            var trip = await _db.Trips.FirstOrDefaultAsync(t => t.Id == id);
            var images = await _db.TripImages.Where(i => !i.IsMain && i.Id == id).ToListAsync();

            var services = await _db.Services.ToListAsync();
            if (trip == null) return NotFound();

            return View(new TripDetailViewModel { Trip = trip, Images = images, Services = services });
            return View();
        }
    }
}
