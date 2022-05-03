using System.Collections.Generic;
using Voyage.Models.Entities;

namespace Voyage.Models.ViewModels
{
    public class AboutViewModel
    {
        public List<Team> Team { get; set; }
        public AboutCompany AboutCompany { get; set; }
        public List<Direction> Directions { get; set; }
        public DirectionSection DirectionSection { get; set; }
    }
}
