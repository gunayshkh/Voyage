using System;
using System.Collections.Generic;
using Voyage.DATA.Enum;
using Voyage.Models.Entities;

namespace Voyage.Models
{
    public class Trip:BaseEntity
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string AdditionalInfo { get; set; }
        public int Duration { get; set; }
        public string CityName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public decimal Review { get; set; }
        
        public TripIntensity Level { get; set; }
        public decimal Price { get; set; }
        public ICollection<TripImage> Images { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }



    }
}
