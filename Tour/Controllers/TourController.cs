using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Voyage.DAL;
using Voyage.Models.Entities;
using Voyage.Models.ViewModels;

namespace Voyage.Controllers
{
    public class TourController : Controller
    {
        private readonly VoyageDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public TourController(VoyageDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var trip = await _db.Trips.Include(t=>t.City).Where(t=>!t.IsDeleted).Take(6).ToListAsync();
           // var images = await _db.TripImages.FirstOrDefaultAsync(i=>i.IsDeleted);

            return View(new TripViewModel { Trips = trip});
        }

        //Get
        public async Task<IActionResult> Detail(int? id)
        {
            var trip = await _db.Trips.Include(t => t.City).FirstOrDefaultAsync(t => t.Id == id);
            var images = await _db.TripImages.Where(i => !i.IsMain && i.Id == id).ToListAsync();
           
            var services = await _db.Services.ToListAsync();
            if (trip == null) return NotFound();

            return View(new TripDetailViewModel { Trip = trip, Images = images, Services = services });
        }
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(TripDetailViewModel model)
        {
            // if (!User.Identity.IsAuthenticated) return RedirectToAction(nameof(AccountController.Login), "Account");
            var trip = await _db.Trips.FirstOrDefaultAsync(t => t.Id == model.TripId);
            var images = await _db.TripImages.Where(i => !i.IsMain && i.Id == model.TripId).ToListAsync();

            var services = await _db.Services.ToListAsync();



            TripDetailViewModel tdvm = new TripDetailViewModel { Trip = trip, Images = images, Services = services, BookingViewModel = new() };
           
            if (!ModelState.IsValid) return View(tdvm);


            //dates
            //capacity 

            //int capacityResult = tdvm.BookingViewModel.Tour.Capacity - tdvm.BookingViewModel.Guests;

            //if (capacityResult > 20)
            //{
            //    ModelState.AddModelError("", "you cannot book for this trip");

            //}
            //else 
            //{ 
            //    return View(tdvm);
            //}

            await _db.Bookings.AddAsync(new Booking
            {
                StartDate = model.BookingViewModel.StartDate,
                EndDate = model.BookingViewModel.StartDate.AddDays(trip.Duration),
                Trip = trip,
               // User = await _userManager.Users.FirstOrDefaultAsync(u => u.ClaimTypes.NameIdentifier == u.Id),

            });
            await _db.SaveChangesAsync();





            return RedirectToAction("Basket", "AddToCart");

        }
    }
    }

