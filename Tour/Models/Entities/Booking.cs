using System;

namespace Voyage.Models.Entities
{
    public class Booking:BaseEntity
    {
        public User User { get; set; }
        public Trip Trip { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
