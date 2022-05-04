using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tour.Models;
using Voyage.DAL;
using Voyage.Models.ViewModels;

namespace Tour.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VoyageDbContext _db;

        public HomeController(ILogger<HomeController> logger, VoyageDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {

            var vm = new HomeIndexViewModel()
            {
                Slider = await _db.Sliders.FirstOrDefaultAsync(),
                TripList = await _db.Trips.Include(t=>t.City).Where(t=>!t.IsDeleted).Take(6).ToListAsync()
            };
           
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
