using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Voyage.DAL;
using Voyage.Models.ViewModels;

namespace Voyage.Controllers
{
    public class AboutController : Controller
    {
        private readonly VoyageDbContext _db;

        public AboutController(VoyageDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            AboutViewModel about = new AboutViewModel()
            {
                DirectionSection = await _db.DirectionSection.FirstOrDefaultAsync(d => !d.IsDeleted),
                Directions = await _db.Directions.Take(6).ToListAsync(),
                Team = await _db.Team.ToListAsync(),
                AboutCompany = await _db.AboutCompany.FirstOrDefaultAsync(a=>!a.IsDeleted)
            

            };
            return View(about);
        }
    }
}
