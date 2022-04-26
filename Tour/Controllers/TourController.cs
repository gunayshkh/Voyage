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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(TripDetailViewModel model)
        {
            // if (!User.Identity.IsAuthenticated) return RedirectToAction(nameof(AccountController.Login), "Account");
            var trip = await _db.Trips.FirstOrDefaultAsync(t => t.Id == model.TripId);
            var images = await _db.TripImages.Where(i => !i.IsMain && i.Id == model.TripId).ToListAsync();

            var services = await _db.Services.ToListAsync();



            TripDetailViewModel tdvm = new TripDetailViewModel { Trip = trip, Images = images, Services = services, BookingViewModel = new() };
           
            if (!ModelState.IsValid) return View(tdvm);

            int result = DateTime.Compare(tdvm.BookingViewModel.StartDate, tdvm.BookingViewModel.EndDate);
            //< 0 − If date1 is earlier than date2.
            // 0 − If date1 is the same as date2.
            // > 0 − If date1 is later than date2.

            if (result! < 0)
            {
                ModelState.AddModelError("", "EndDate cannot be earlier than start date");
                return View(tdvm);
            }

            //dates
            //capacity 

            int capacityResult = tdvm.BookingViewModel.Tour.Capacity - tdvm.BookingViewModel.Guests;

            if (capacityResult > 20)
            {
                ModelState.AddModelError("", "you cannot book for this trip");

            }
            else 
            { 
                return View(tdvm);
            }
            if (tdvm.BookingViewModel.EndDate < tdvm.BookingViewModel.StartDate)
            {

            }

            await _db.Bookings.AddAsync(new Booking
            {
                StartDate = model.BookingViewModel.StartDate,
                EndDate = model.BookingViewModel.EndDate,
                Trip = trip,
                User = await _userManager.Users.FirstOrDefaultAsync(u => ClaimTypes.NameIdentifier == u.Id),

            });
            await _db.SaveChangesAsync();





            return RedirectToAction(nameof(Index), new { id = trip.Id });

        }
    }
    }

