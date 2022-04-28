﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Voyage.Models.Entities;

namespace Voyage.Areas.Admin.Models.ViewModels
{
    public class CreateTourViewModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public string TourName { get; set;}
        [Required]
        public string TourDescription { get; set;} = string.Empty;
        [Required]
        public IFormFile Image { get; set; }
        public IFormFile Images { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "AdditionalInfo")]
        public string AdditionalInfo { get; set; }
        [Required (ErrorMessage="Choose from 1 to 5"), Display(Name = "Review")]
        public decimal Review { get; set; }
        [Required(ErrorMessage="Can select up to 7 days")]
        public int Duration { get; set; }
        [Required, Display(Name = "Capacity")]
        public int Capacity { get; set; }


        public City City { get; set; }
        public ICollection<TripImage> TripImages { get; set; }






    }
}
