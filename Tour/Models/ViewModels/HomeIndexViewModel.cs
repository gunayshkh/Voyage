using System.Collections.Generic;
using Voyage.Models.Entities;

namespace Voyage.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public Slider Slider { get; set; }
        public List<Trip> TripList { get; set; }
    }
}
