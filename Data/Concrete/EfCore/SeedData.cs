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
                            new Category() { BrandCategory = "Audi" },
                            new Category() { BrandCategory = "BMW" },
                            new Category() { BrandCategory = "Toyota" },
                            new Category() { BrandCategory = "Honda" },
                            new Category() { BrandCategory = "Ford" },
                            new Category() { BrandCategory = "Chevrolet" },
                            new Category() { BrandCategory = "Porsche" },
                            new Category() { BrandCategory = "Volkswagen" },
                            new Category() { BrandCategory = "Nissan" },
                            new Category() { BrandCategory = "Tesla" },
                            new Category() { BrandCategory = "Lamborghini" },
                            new Category() { BrandCategory = "Jeep" },
                            new Category() { BrandCategory = "Hyundai" },
                            new Category() { BrandCategory = "Land Rover" },
                            new Category() { TypeCategory = "SUV" },
                            new Category() { TypeCategory = "Sedan" },
                            new Category() { TypeCategory = "Coupe" },
                            new Category() { SeatCategory = 2 },
                            new Category() { SeatCategory = 4 },
                            new Category() { SeatCategory = 5 },
                            new Category() { SeatCategory = 7 }

                        );
                        context.SaveChanges();
                    }

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(
                            new User() { Username = "umutakman", Password = "umutakman", Email = "umutakman@gmail.com", NameSurname = "Umut Akman" },
                            new User() { Username = "admin", Password = "123456789" }
                        );
                        context.SaveChanges();
                    }

                    if (!context.Cars.Any())
                    {
                        context.Cars.AddRange(
                            new Car()
                            {
                                Title = "Audi Q7",
                                Url = "audi-q7",
                                Brand = "Audi",
                                Type = "SUV",
                                Model = "Q7",
                                Image = "q7.png",
                                Seats = 7,
                                RentPrice = 1200,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Audi" || c.TypeCategory == "SUV" || c.SeatCategory == 7)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "BMW X5",
                                Url = "bmw-x5",
                                Brand = "BMW",
                                Type = "SUV",
                                Model = "X5",
                                Image = "x5.png",
                                Seats = 5,
                                RentPrice = 1300,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "BMW" || c.TypeCategory == "SUV" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Mercedes-Benz C-Class",
                                Url = "mercedes-benz-c-class",
                                Brand = "Mercedes-Benz",
                                Type = "Sedan",
                                Model = "C-Class",
                                Image = "c-class.png",
                                Seats = 5,
                                RentPrice = 1100,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Mercedes-Benz" || c.TypeCategory == "Sedan" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Toyota Corolla",
                                Url = "toyota-corolla",
                                Brand = "Toyota",
                                Type = "Sedan",
                                Model = "Corolla",
                                Image = "corolla.png",
                                Seats = 5,
                                RentPrice = 800,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Toyota" || c.TypeCategory == "Sedan" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Honda CR-V",
                                Url = "honda-cr-v",
                                Brand = "Honda",
                                Type = "SUV",
                                Model = "CR-V",
                                Image = "cr-v.png",
                                Seats = 5,
                                RentPrice = 950,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Honda" || c.TypeCategory == "SUV" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Ford Mustang",
                                Url = "ford-mustang",
                                Brand = "Ford",
                                Type = "Coupe",
                                Model = "Mustang",
                                Image = "mustang.png",
                                Seats = 4,
                                RentPrice = 1400,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Ford" || c.TypeCategory == "Coupe" || c.SeatCategory == 4)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Chevrolet Tahoe",
                                Url = "chevrolet-tahoe",
                                Brand = "Chevrolet",
                                Type = "SUV",
                                Model = "Tahoe",
                                Image = "tahoe.png",
                                Seats = 7,
                                RentPrice = 1300,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Chevrolet" || c.TypeCategory == "SUV" || c.SeatCategory == 7)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Porsche 911",
                                Url = "porsche-911",
                                Brand = "Porsche",
                                Type = "Coupe",
                                Model = "911",
                                Image = "911.png",
                                Seats = 2,
                                RentPrice = 1600,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Porsche" || c.TypeCategory == "Coupe" || c.SeatCategory == 2)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Volkswagen Tiguan",
                                Url = "volkswagen-tiguan",
                                Brand = "Volkswagen",
                                Type = "SUV",
                                Model = "Tiguan",
                                Image = "tiguan.png",
                                Seats = 5,
                                RentPrice = 1000,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Volkswagen" || c.TypeCategory == "SUV" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Nissan Altima",
                                Url = "nissan-altima",
                                Brand = "Nissan",
                                Type = "Sedan",
                                Model = "Altima",
                                Image = "altima.png",
                                Seats = 5,
                                RentPrice = 850,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Nissan" || c.TypeCategory == "Sedan" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Tesla Model 3",
                                Url = "tesla-model-3",
                                Brand = "Tesla",
                                Type = "Sedan",
                                Model = "Model 3",
                                Image = "model-3.png",
                                Seats = 5,
                                RentPrice = 1500,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Tesla" || c.TypeCategory == "Sedan" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Lamborghini Huracan",
                                Url = "lamborghini-huracan",
                                Brand = "Lamborghini",
                                Type = "Coupe",
                                Model = "Huracan",
                                Image = "huracan.png",
                                Seats = 2,
                                RentPrice = 2000,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Lamborghini" || c.TypeCategory == "Coupe" || c.SeatCategory == 2)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Jeep Wrangler",
                                Url = "jeep-wrangler",
                                Brand = "Jeep",
                                Type = "SUV",
                                Model = "Wrangler",
                                Image = "wrangler.png",
                                Seats = 5,
                                RentPrice = 1200,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Jeep" || c.TypeCategory == "SUV" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Hyundai Elantra",
                                Url = "hyundai-elantra",
                                Brand = "Hyundai",
                                Type = "Sedan",
                                Model = "Elantra",
                                Image = "elantra.png",
                                Seats = 5,
                                RentPrice = 750,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Hyundai" || c.TypeCategory == "Sedan" || c.SeatCategory == 5)
                                    .ToList()
                            },
                            new Car()
                            {
                                Title = "Range Rover Evoque",
                                Url = "range-rover-evoque",
                                Brand = "Land Rover",
                                Type = "SUV",
                                Model = "Evoque",
                                Image = "evoque.png",
                                Seats = 5,
                                RentPrice = 1400,
                                IsActive = true,
                                Categories = context.Categories
                                    .Where(c => c.BrandCategory == "Land Rover" || c.TypeCategory == "SUV" || c.SeatCategory == 5)
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