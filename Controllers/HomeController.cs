using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TechcareerBootcampFest4Project.Data.Abstract;
using TechcareerBootcampFest4Project.Data.Concrete.EfCore;
using TechcareerBootcampFest4Project.Entity;
using TechcareerBootcampFest4Project.Models;

namespace TechcareerBootcampFest4Project.Controllers{

    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ICarRepository carRepository, ICategoryRepository categoryRepository)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(string searchString, string brand, string type, int? seats, int? minPrice, int? maxPrice)
        {
            var cars = _carRepository.Cars.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                    ViewBag.searchString = searchString;
                    cars = cars.Where(c => c.Title!.ToLower().Contains(searchString!)).ToList();
            }

            if (!string.IsNullOrEmpty(brand))
            {
                ViewBag.brand = brand;
                cars = cars.Where(c => c.Brand == brand).ToList();
            }

            if (!string.IsNullOrEmpty(type))
            {
                ViewBag.type = type;
                cars = cars.Where(c => c.Type == type).ToList();
            }

            if (seats > 0)
            {
                ViewBag.seats = seats;
                cars = cars.Where(c => c.Seats == seats).ToList();
            }
            if (minPrice > 0)
            {
                cars = cars.Where(c => c.RentPrice >= minPrice).ToList();
            }
            if (maxPrice > 0)
            {
                cars = cars.Where(c => c.RentPrice <= maxPrice).ToList();
            }
        
            var model = new CarFilterViewModel
            {
                Cars = cars,
                Categories = _categoryRepository.Categories.ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _carRepository.Cars.FirstOrDefaultAsync(i => i.Url == url));
        }
    }
}