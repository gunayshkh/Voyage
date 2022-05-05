using System.Collections.Generic;
using Voyage.Models.Entities;

namespace Voyage.Models.ViewModels
{
    public class TripViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Trip> Trips { get; set; }

        public string ImageURL { get; set; }
        public List<TripImage> Images { get; set; }
        public BasketViewModel BasketViewModel { get; set; }

        public string Description { get; set; }
        public string AdditionalInfo { get; set; }
        public int Duration { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }

    }
}
