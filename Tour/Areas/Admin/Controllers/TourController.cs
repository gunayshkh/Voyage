using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Voyage.Areas.Admin.Models.ViewModels;
using Voyage.DAL;
using Voyage.Models;
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
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTourViewModel model) 
        {
            if (!ModelState.IsValid) return View(nameof(Create));

            var newTrip = new Trip
            {
                Name = model.TourName,
                Description = model.TourDescription,
                Duration = model.Duration,
                Price = model.Price,
                Capacity = model.Capacity,
                City = model.City,
                Review = model.Review
            };

            if (model.Image != null)
            {
                if (true)
                {

                }

            }
            return View();

        }
        public async Task<IActionResult> Update(int id)
        {
            return View();
        }
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateTour(int id)
        {
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(nameof(Delete));
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> DeleteTour(int id)
        {
            return View(nameof(Delete));
        }
    }
}
