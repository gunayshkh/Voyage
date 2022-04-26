using System;
using System.Collections.Generic;
using Voyage.Models.Entities;

namespace Voyage.Models.ViewModels
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public Trip Trip { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TripAttendant Attendant { get; set; }
        public int Count { get; set; }
    }
}
