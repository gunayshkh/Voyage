using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Voyage.DAL;
using Voyage.Models.ViewModels;

namespace Voyage.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly VoyageDbContext _db;

        public HeaderViewComponent(VoyageDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var links = _db.Links.ToList();
            var header = _db.HeaderLayouts.ToList();
            var logo = _db.Logo.FirstOrDefault();
            return View(new LayoutViewModel { Header = header, Links = links, LogoURL= logo});

        }
    }
}
