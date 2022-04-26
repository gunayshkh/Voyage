using System.Collections.Generic;
using Voyage.Models.Entities;

namespace Voyage.Models.ViewModels
{
    public class TripDetailViewModel
    {
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public List<TripImage> Images { get; set; }
        public List<Service> Services { get; set; }
        public BookingViewModel BookingViewModel { get; set; }
        public BasketViewModel BasketViewModel { get; set; }
    }
}
