using System.Collections.Generic;
using Voyage.Models.Entities;

namespace Voyage.Models.ViewModels
{
    public class LayoutViewModel
    {
        public List<HeaderLayout> Header { get; set; }
        public Logo LogoURL { get; set; }
        public List<NavigationLink> Links { get; set; }
        public List<FooterLayout> Footer { get; set; }
        public List<UsefulLink> UsefulLinks { get; set; }
    }
}
