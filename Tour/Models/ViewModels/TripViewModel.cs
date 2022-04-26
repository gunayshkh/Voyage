using System.Collections.Generic;
using Voyage.Models.Entities;

namespace Voyage.Models.ViewModels
{
    public class TripViewModel
    {
        public int Id { get; set; }
        public List<Trip> Trips { get; set; }

        public string ImageURL { get; set; }
        public List<TripImage> Images { get; set; }
        public BasketViewModel BasketViewModel { get; set; }


    }
}
