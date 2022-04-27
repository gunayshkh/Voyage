using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Voyage.DATA.Constants;
using Voyage.Models.Entities;

namespace Voyage.DAL
{
    public class VoyageDbInitializer
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<VoyageDbContext>();
                db.Database.EnsureCreated();
                // db.Database.Migrate();
                //Roles
                if (!db.Roles.Any())
                {
                    db.Roles.Add(new IdentityRole { Name = RoleConstants.Moderator, NormalizedName = RoleConstants.Moderator.ToUpper() });
                    db.Roles.Add(new IdentityRole { Name = RoleConstants.SuperAdmin, NormalizedName = RoleConstants.SuperAdmin.ToUpper() });
                    db.Roles.Add(new IdentityRole { Name = RoleConstants.User, NormalizedName = RoleConstants.User.ToUpper() });

                }

                await db.SaveChangesAsync();

                //Logo
                if (!db.Logo.Any())
                {
                    db.Logo.AddRange(new Logo()
                    {
                        LogoURL = "voyage.svg"
                    });
                    await db.SaveChangesAsync();
                }

                //Slider Index Page
                if (!db.Sliders.Any())
                {
                    db.Sliders.AddRange(new List<Slider>()
                    {
                       new Slider()
                       {
                           Name ="Voyage Adventures",
                           VideoURL = "voyage.mp4",
                           Description = "Choose from a wide range of places to stay and tours to enjoy for the ultimate Azerbaijan travel experience"
                       }

                    });
                    await db.SaveChangesAsync();

                }

                // Navigation Links
                if (!db.Links.Any())
                {
                    db.Links.AddRange(new List<NavigationLink>() 
                    {
                        new NavigationLink()
                        {
                            Name = "Home",
                            ActionName = "Index",
                            ControllerName = "Home"

                        },

                        new NavigationLink()
                        {
                            Name = "About",
                            ActionName = "Index",
                            ControllerName = "About"
                            
                        },
                          new NavigationLink()
                        {
                            Name = "Tour",
                            ActionName = "Index",
                            ControllerName = "Tour"

                        },
                            new NavigationLink()
                        {
                            Name = "Service",
                            ActionName = "Index",
                            ControllerName = "Service"

                        },
                              new NavigationLink()
                        {
                            Name = "Blog",
                            ActionName = "Index",
                            ControllerName = "Blog"

                        }

                    });
                    await db.SaveChangesAsync();
                }

                //Services
                if (!db.Services.Any())
                {
                    db.Services.AddRange(new List<Service>()
                    {
                        new Service() {Name = "Food" },
                        new Service() {Name = "Drinks"},
                        new Service() {Name = "Accomodation"},
                        new Service() {Name = "Equipment"}

                    });
                    await db.SaveChangesAsync();
                }

                //SubServices
                if (!db.SubServices.Any())
                {
                    db.SubServices.AddRange(new List<SubService>()
                    {
                        new SubService(){Name = "Breakfast"},
                        new SubService(){Name = "Lunch"},
                        new SubService(){Name = "Dinner"},
                        new SubService(){Name = "Snacks"},
                        new SubService(){Name = "Water"},
                        new SubService(){Name = "Tea"},
                        new SubService(){Name = "Bed"},
                        new SubService(){Name = "Sport Equipments"}
                        

                    });
                    await db.SaveChangesAsync();

                }

                //Cities
                if (!db.Cities.Any())
                {
                    Country Azerbaijan = db.Countries.FirstOrDefault(c => c.Name == "Azerbaijan");
                    db.Cities.AddRange(new List<City>()
                    {
                        new City(){Name = "Zagatala", Country = Azerbaijan}, 
                        new City(){Name ="Shaki", Country = Azerbaijan},
                        new City(){Name ="Gakh", Country = Azerbaijan},
                        new City(){Name ="Lankaran", Country = Azerbaijan},
                        new City(){Name ="Astara", Country = Azerbaijan}

                    });
                   await db.SaveChangesAsync();
                }
                //Countries
                if (!db.Countries.Any())
                {
                    db.Countries.AddRange(new List<Country>()
                    {
                        new Country(){Name = "Azerbaijan"}
                    });
                    await db.SaveChangesAsync();
                }

                //UsefulLinks for Footer component
                if (db.UsefulLinks.Any())
                {
                    db.UsefulLinks.AddRange(new List<UsefulLink>()
                    {
                        new UsefulLink() { ActionName = "Login", ControllerName = "Account", Name = "Login"} ,
                        new UsefulLink() {ActionName = "About", ControllerName = "Home", Name = "About"},
                        new UsefulLink() {ActionName = "Register", ControllerName = "Account", Name = "Register"}
                    });
                    await db.SaveChangesAsync();
                }
                


            }
        }
    }
}
