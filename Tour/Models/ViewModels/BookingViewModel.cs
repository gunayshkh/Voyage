using System;
using System.ComponentModel.DataAnnotations;

namespace Voyage.Models.ViewModels
{
    public class BookingViewModel
    {
        public int TripId { get; set; }
        public int FullName { get; set; }
        public Trip Trip { get; set; }
        public int Guests { get; set; }
        public int Capacity { get; set; }
        public int UserId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
