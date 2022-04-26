using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Voyage.Models;
using Voyage.Models.Entities;

namespace Voyage.DAL
{

    public class VoyageDbContext: IdentityDbContext<User>
    {
        public VoyageDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }    
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripImage> TripImages { get; set; }

        public DbSet<NavigationLink> Links { get; set; }
        public DbSet<Logo> Logo { get; set; }
        public DbSet<HeaderLayout> HeaderLayouts { get; set; }
        public DbSet<FooterLayout> FooterLayouts { get; set; }
        public DbSet<UsefulLink> UsefulLinks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubService> SubServices { get; set; }

        public DbSet<TourService> TourServices { get; set; }

        public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }
        public DbSet<Booking> Bookings { get; set; }






    }
}
