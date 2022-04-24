using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Voyage.DAL;
using Voyage.Models.ViewModels;

namespace Voyage.ViewComponents
{
    public class FooterViewComponent : ViewComponent

    {
        private readonly VoyageDbContext _db;

        public FooterViewComponent(VoyageDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var footer = _db.FooterLayouts.Where(f=>!f.IsDeleted).ToList();
            var useful = _db.UsefulLinks.Where(u=>!u.IsDeleted).ToList();
            return View(new LayoutViewModel { Footer = footer, UsefulLinks = useful});
        }
    }
}
