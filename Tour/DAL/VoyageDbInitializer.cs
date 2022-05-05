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
                        new City(){Name ="Astara", Country = Azerbaijan},
                        new City(){Name ="Goygol", Country = Azerbaijan}



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
                if (!db.UsefulLinks.Any())
                {
                    db.UsefulLinks.AddRange(new List<UsefulLink>()
                    {
                        new UsefulLink() {ActionName = "Login", ControllerName = "Account", Name = "Login"} ,
                        new UsefulLink() {ActionName = "Index", ControllerName = "About", Name = "About"},
                        new UsefulLink() {ActionName = "Register", ControllerName = "Account", Name = "Register"},
                        new UsefulLink() {ActionName = "Index", ControllerName = "Blog", Name = "Blog"}

                    });
                    await db.SaveChangesAsync();
                }

                //About
                if (!db.AboutCompany.Any())
                {
                    var team = db.Team.Where(t => t.JobTitle == "Ceo").FirstOrDefault();
                    db.AboutCompany.AddRange(new List<AboutCompany>()
                    { new AboutCompany()
                         {
                             Title ="what to do in Azerbaijan",
                             Description = "Select your travel preferences and get personalized " +
                             "recommendations for your trip to Azerbaijan. ",
                             ImageURL = "caspian.jpg",
                             AdditionalInfo = "If you've been scrolling through our trail notes for the newly launched TCT sections in Azerbaijan and" +
                             " dreaming about a trip to the easter Greater Caucasus... we've got news for you. This June, " +
                             "we’ll be hosting the first ever TCT supporters' trek in Azerbaijan!" +
                             "Along the way, we’ll run into pirs (holy sites) and mosques, old fortresses, nomadic graveyards, " +
                             "and shepherd settlements. We'll indulge in delicious and fresh local cuisine. We'll meet locals from a wide range of " +
                             "Caucasian ethnolinguistic backgrounds. And we'll have an absolutely unforgettable " +
                             "adventure on a stunning route through the eastern Greater Caucasus",
                             Team = team
                          }
                    });
                    await db.SaveChangesAsync();
                }

                //DirectionSection

                if (!db.DirectionSection.Any())
                {
                    db.DirectionSection.AddRange(new List<DirectionSection>()
                    { new DirectionSection()
                    {
                              MainTitle = "get inspired by Azerbaijan",
                              Description= "Here in Azerbaijan you can count on the help" +
                              " of our generous people in every step of your journey.",
                              ImageURL = "camping_2.jpg"
                    }
                 
                });
                    await db.SaveChangesAsync();

                }

                //Directions
                if (!db.Directions.Any())
                {
                    db.Directions.AddRange(new List<Direction>()
                    {
                        new Direction()
                        {
                            Title = "Baku",
                            Description = "Known as the City of Winds, there are two main" +
                            " gusts to look out for in Baku – the warmer Gilavar blowing from the south," +
                            " and the cool Khazri sweeping down from the north.",
                             ImageURL = "baku.jpg"
                        },
                        new Direction()
                        {   
                            Title = "Guba",
                            Description = "Unlike elsewhere, Guba’s traditional pakhlava sweets are actually usually cooked by men.",
                            ImageURL = "guba.jpg"

                        },
                        new Direction()
                        {
                            Title = "Shaki",
                            Description = "In 2008 Sheki became a member of the League of Historical Cities, a Japan-based NGO strengthening links between historic cities, alongside cities such as Rome, Paris, Athens and Jerusalem.",
                            ImageURL= "shaki.jpg"
                        },
                        new Direction()
                        {
                            Title="Nakhchivan",
                            Description ="Known locally as the 'Museum of Mineral Springs', Nakhchivan is home to 250 springs as well as famous water brands Sirab and Badamli. ",
                            ImageURL=   "nakhchivan.jpg"

                        },
                        new Direction()
                        {
                            Title = "Khizi",
                            Description="The landscapes of Khizi are an astonishing mix of pristine forests, 2,000-metre high mountains, Caspian Sea shoreline and semi-desert plains.",
                            ImageURL="khizi.jpg"
                        },
                        new Direction()
                        {
                            Title = "Gusar",
                            Description = "Azerbaijan’s highest peak, the 4,466-metre (14,652 ft) high Mount Bazarduzu is located in the Gusar region.  ",
                            ImageURL="gusar.jpg"
                        },
                        new Direction()
                        {
                            Title ="Shamakhi",
                            Description ="Then the capital of the legendary state of the Shirvanshahs, Shamakhi was destroyed by a terrible earthquake in 1192.",
                            ImageURL = "shamakhi.jpg"

                        }

                    });
                    await db.SaveChangesAsync();
                        
                }

                //Team

                if (!db.Team.Any())
                {
                    db.Team.AddRange(new List<Team>()
                    {
                        new Team()
                        {
                            FullName = "Abbas Mammadov",
                            JobTitle = "Ceo",
                            ImageURL = "1.jpg"
                        },
                        new Team()
                        {
                            FullName="Elnara Guliyeva",
                            JobTitle="Marketing",
                            ImageURL="2.jpg"
                        },
                        new Team()
                        {
                            FullName = "John Nash",
                            JobTitle = "Finance",
                            ImageURL = "3.jpg"
                        },
                        new Team()
                        {
                            FullName ="Anna Amazon",
                            JobTitle="Guide",
                            ImageURL="4.jpg"
                        },
                        new Team()
                        {
                            FullName="Bob Marley",
                            JobTitle="Guide",
                            ImageURL="5.jpg"
                        }

                    });
                    await db.SaveChangesAsync();

                }
            }
        }
    }
}
