using System.Collections.Generic;
using Voyage.Models.Entities;

namespace Voyage.Models.ViewModels
{
    public class TripViewModel
    {
        public List<Trip> Trips { get; set; }

        public string ImageURL { get; set; }
        public List<TripImage> Images { get; set; }

      
    }
}
