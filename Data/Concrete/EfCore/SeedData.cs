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
                            new Category() { CategoryName = "SUV" },
                            new Category() { CategoryName = "Sedan" },
                            new Category() { CategoryName = "Hatchback" },
                            new Category() { CategoryName = "Cabrio" },
                            new Category() { CategoryName = "Coupe" }
                        );
                        context.SaveChanges();
                    }

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(
                            new User() { Username = "umutakman", Name = "Umut", Surname = "Akman" },
                            new User() { Username = "bugrayildirim", Name = "Bugra", Surname = "Yildirim" }
                        );
                        context.SaveChanges();
                    }

                    if (!context.Cars.Any())
                    {
                        context.Cars.AddRange(
                            new Car() { Title = "Mercedes-Benz G-Class", Brand = "Mercedes-Benz", Model = "G-Class", Image="g-class.png", Seats = 4, RentPrice = 1500, IsActive = true },
                            new Car() { Title = "BMW 5 Series", Brand = "BMW", Model = "5 Series", Image="m5.png", Seats = 4,  RentPrice = 1000, IsActive = true },
                            new Car() { Title = "Volkswagen Golf", Brand = "Volkswagen", Model = "Golf", Image="golf.png", Seats = 4, RentPrice = 500, IsActive = true }
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