using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Voyage.Areas.Admin.Models.ViewModels;
using Voyage.Areas.Admin.Utilities;
using Voyage.DAL;
using Voyage.DATA.Constants;
using Voyage.Areas.Admin.Utilities;
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
            var trips = await _db.Trips.Where(t=>!t.IsDeleted).ToListAsync();
            return View(trips);
        }
        public async Task<IActionResult> Details(int id)
        {
            var trip = await _db.Trips.Include(t=>t.City).Where(t=>!t.IsDeleted).FirstOrDefaultAsync(t => t.Id == id);
            var images = await _db.TripImages.Where(i => !i.IsMain && i.Id == id).ToListAsync();

            var services = await _db.Services.ToListAsync();
            if (trip == null) return NotFound();

            return View(new TripDetailViewModel { Trip = trip, Images = images, Services = services });
            
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateTourViewModel
            {
                City = await _db.Cities.ToListAsync()

            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTourViewModel model) 
        {
            if (!ModelState.IsValid) return View();

            var city = await _db.Cities.FirstOrDefaultAsync(c => c.Id == model.CityId);
            var newTrip = new Trip
            {
                Name = model.TourName,
                Description = model.TourDescription,
                Duration = model.Duration,
                Price = model.Price,
                Capacity = model.Capacity,
                City = city,
                Review = model.Review,
                AdditionalInfo = model.AdditionalInfo

              
            };


            if (model.Image != null)
            {
                if (!model.Image.ImageExtention())
                {
                    ModelState.AddModelError(nameof(CreateTourViewModel.Image), "File is not supported");
                    return View();
                }

                if (model.Image.CheckForSize(2048))
                {
                    ModelState.AddModelError(nameof(CreateTourViewModel.Image), "File size exceeds 2mb");
                    return View();
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "img"), model.Image);
                newTrip.ImageURL = imageName;
            }

            await _db.Trips.AddAsync(newTrip);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Tour");

        }
        public async Task<IActionResult> Update(int id)
        {
            var trip = await _db.Trips.Where(t=>!t.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.City = await _db.Cities.ToListAsync();
            if (trip == null) return NotFound();
            UpdateTourViewModel updateTourViewModel = new UpdateTourViewModel
            {
                Id = trip.Id,
                TourName = trip.Name,
                AdditionalInfo = trip.AdditionalInfo,
                TourDescription = trip.Description,
                Review = trip.Review,
                Price = trip.Price,
                Capacity = trip.Capacity,
                CityName = trip.CityName,
                CityId = trip.CityId,
                Duration = trip.Duration
                
            };
            
            return View(updateTourViewModel);
        }
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateTour(int id, UpdateTourViewModel model)
        {
            var trip = await _db.Trips.Include(t=>t.City).Where(t => !t.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
            var city = await _db.Cities.FirstOrDefaultAsync(c => c.Id == model.CityId);
            ViewBag.City = await _db.Cities.ToListAsync();



            if (trip == null) return NotFound();
            UpdateTourViewModel updateTourViewModel = new UpdateTourViewModel
            {
                Id = trip.Id,
                TourName = trip.Name,
                AdditionalInfo = trip.AdditionalInfo,
                TourDescription = trip.Description,
                Review = trip.Review,
                Price = trip.Price,
                Capacity = trip.Capacity,
                CityName = city.Name,
                Duration = trip.Duration,
                CityId = trip.CityId
              

            };
           // if (!ModelState.IsValid) return View(updateTourViewModel);

            trip.Name = model.TourName  ?? model.TourName.ToString();
            trip.Description = model.TourDescription ?? model.TourDescription.ToString();
          //  city.Name = model.CityName ?? model.CityName.ToString();
            trip.Price = model.Price;
            trip.Capacity = model.Capacity;
            trip.Duration = model.Duration;
            trip.AdditionalInfo = model.AdditionalInfo;
            trip.CityId = model.CityId;
            if (model.Image != null)
            {
                if (!model.Image.ImageExtention())
                {
                    ModelState.AddModelError(nameof(CreateTourViewModel.Image), "File is not supported");
                    return View();
                }

                if (model.Image.CheckForSize(2048))
                {
                    ModelState.AddModelError(nameof(CreateTourViewModel.Image), "File size exceeds 2mb");
                    return View();
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "img"), model.Image);
                trip.ImageURL = imageName;
            }

            _db.Trips.Update(trip);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }
        public async Task<IActionResult> Delete(int id)
        {
            Trip trip = await _db.Trips.Where(t => !t.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
            if (trip == null) return NotFound();
            TripDetailViewModel detailViewModel = new TripDetailViewModel
            {
                Trip = trip,

            };

            return View(trip);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> DeleteTour(int id)
        {
            var trip = await _db.Trips.Where(t => !t.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
            if (!ModelState.IsValid)  return BadRequest();
            trip.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
