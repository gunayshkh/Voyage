using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Voyage.DAL;
using Voyage.Models;
using Voyage.Models.ViewModels;

namespace Voyage.Controllers
{
    public class BasketController : Controller
    {
        private readonly VoyageDbContext _db;

        public BasketController(VoyageDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToBasket(int id)
        {
            
            Trip trip = await _db.Trips.FindAsync(id);
            List<BasketViewModel> basket;
            var basketJson = Request.Cookies["basket"];
            if (string.IsNullOrEmpty(basketJson))
            {
                basket = new List<BasketViewModel>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketViewModel>>(basketJson);
            }
            BasketViewModel existTrip = basket.Find(t => t.Id == id);
            if (existTrip == null)
            {
                BasketViewModel basketViewModel = new BasketViewModel();
                basketViewModel.Id = id;
                basketViewModel.Name = trip.Name;
                basketViewModel.Price = trip.Price;
                basketViewModel.StartDate = trip.StartDate;
                basketViewModel.EndDate = trip.EndDate;

                basket.Add(basketViewModel);

            }
            else
            {
                existTrip.Count++;
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return RedirectToAction("Index", "Tour");
        }

        public async Task<IActionResult> GetBasket()
        {
            List<BasketViewModel> basket = JsonConvert.DeserializeObject<List<BasketViewModel>>(Request.Cookies["basket"]);
            var json = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("append", json);
            return View(basket);
        }
    }
}
