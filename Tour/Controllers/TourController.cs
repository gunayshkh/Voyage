using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyage.DAL;
using Voyage.Models.Entities;
using Voyage.Models.ViewModels;

namespace Voyage.Controllers
{
    public class TourController : Controller
    {
        private readonly VoyageDbContext _db;

        public TourController(VoyageDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var trip = await _db.Trips.Take(6).ToListAsync();
           // var images = await _db.TripImages.FirstOrDefaultAsync(i=>i.IsDeleted);

            return View(new TripViewModel { Trips = trip});
        }

        //Get
        public async Task<IActionResult> Detail(int? id)
        {
            var trip = await _db.Trips.FirstOrDefaultAsync(t => t.Id == id);
            var images = await _db.TripImages.Where(i => !i.IsMain && i.Id == id).ToListAsync();
           
            var services = await _db.Services.ToListAsync();
            if (trip == null) return NotFound();

            return View(new TripDetailViewModel { Trip = trip, Images = images, Services = services });
        }
    }
}
