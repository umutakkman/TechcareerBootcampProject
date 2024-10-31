using Microsoft.EntityFrameworkCore;
using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Concrete.EfCore
{

    public static class SeedData
    {

        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<SiteContext>();

            if (context != null)
            {
                try
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }

                    if (!context.Categories.Any())
                    {
                        context.Categories.AddRange(
                            new Category() { BrandCategory = "Mercedes-Benz" },
                            new Category() { BrandCategory = "BMW" },
                            new Category() { BrandCategory = "Volkswagen" },
                            new Category() { TypeCategory = "SUV" },
                            new Category() { TypeCategory = "Sedan" },
                            new Category() { SeatCategory = 2 },
                            new Category() { SeatCategory = 4 }
                        );
                        context.SaveChanges();
                    }

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(
                            new User() { Username = "umutakman", Password = "umutakman", Email = "umutakman@gmail.com", NameSurname = "Umut Akman"},
                            new User() { Username = "bugrayildirim", Password = "bugrayildirim", Email = "bugrayildirim@gmail.com", NameSurname = "Buğra Yıldırım" },
                            new User() { Username = "admin", Password = "123456789"}
                        );
                        context.SaveChanges();
                    }

                    if (!context.Cars.Any())
                    {
                        context.Cars.AddRange(
                            new Car() { 
                                Title = "Mercedes-Benz G-Class",
                                Url = "mercedes-benz-g-class", 
                                Brand = "Mercedes-Benz", 
                                Type = "SUV",
                                Model = "G-Class", 
                                Image = "g-class.png", 
                                Seats = 4, 
                                RentPrice = 1500, 
                                IsActive = true, 
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Mercedes-Benz" || c.TypeCategory == "SUV" || c.SeatCategory == 4)
                                    .ToList()
                            },
                            new Car() { 
                                Title = "BMW 5 Series",
                                Url = "bmw-5-series",
                                Brand = "BMW",
                                Type = "Sedan",
                                Model = "5 Series", 
                                Image = "m5.png", 
                                Seats = 4, 
                                RentPrice = 1000, 
                                IsActive = true, 
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "BMW" || c.TypeCategory == "Sedan" || c.SeatCategory == 4)
                                    .ToList()
                            },
                            new Car() { 
                                Title = "Volkswagen Golf",
                                Url = "volkswagen-golf", 
                                Brand = "Volkswagen", 
                                Type = "SUV",
                                Model = "Tiguan", 
                                Image = "golf.png", 
                                Seats = 4, 
                                RentPrice = 800, 
                                IsActive = true, 
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Volkswagen" || c.TypeCategory == "SUV" || c.SeatCategory == 4)
                                    .ToList()
                            }
                        );
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                }
            }
        }
    }
}