using CarRentalWebsite.Data.Abstract;
using CarRentalWebsite.Data.Concrete;
using CarRentalWebsite.Models;
using CarRentalWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebsite.Controllers;

public class AdminController : Controller
{
    private readonly ICarRepository _carRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;

    public AdminController(ICarRepository carRepository, ICategoryRepository categoryRepository,
        IUserRepository userRepository)
    {
        _carRepository = carRepository;
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
    }

    public async Task<IActionResult> CarList(string searchString)
    {
        if (User.Identity!.Name != "admin") return RedirectToAction("Index", "Home");

        var cars = await _carRepository.Cars.ToListAsync();
        if (!string.IsNullOrEmpty(searchString))
        {
            ViewBag.searchString = searchString;
            cars = cars.Where(c => c.Title!.ToLower().Contains(searchString!.ToLower())).ToList();
        }

        return View(cars);

    }

    [HttpGet]
    public async Task<IActionResult> CreateCar()
    {
        if (User.Identity!.Name != "admin")
            return RedirectToAction("Index", "Home");

        ViewBag.TypeCategory = await _categoryRepository.Categories
            .Where(x => x.TypeCategory != null)
            .Select(x => x.TypeCategory)
            .Distinct()
            .ToListAsync();

        ViewBag.BrandCategory = await _categoryRepository.Categories
            .Where(x => x.BrandCategory != null)
            .Select(x => x.BrandCategory)
            .Distinct()
            .ToListAsync();

        ViewBag.SeatCategory = await _categoryRepository.Categories
            .Where(x => x.SeatCategory != null)
            .Select(x => x.SeatCategory)
            .Distinct()
            .ToListAsync();

        return View(new CarViewModel { IsActive = true });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCar(CarViewModel viewModel)
    {
        if (User.Identity!.Name != "admin")
            return RedirectToAction("Index", "Home");

        if (!ModelState.IsValid)
        {
            ViewBag.TypeCategory = await _categoryRepository.Categories
                .Where(x => x.TypeCategory != null)
                .Select(x => x.TypeCategory)
                .Distinct()
                .ToListAsync();

            ViewBag.BrandCategory = await _categoryRepository.Categories
                .Where(x => x.BrandCategory != null)
                .Select(x => x.BrandCategory)
                .Distinct()
                .ToListAsync();

            ViewBag.SeatCategory = await _categoryRepository.Categories
                .Where(x => x.SeatCategory != null)
                .Select(x => x.SeatCategory)
                .Distinct()
                .ToListAsync();

            return View(viewModel);
        }

        var car = new Car
        {
            Title = viewModel.Title,
            Url = viewModel.Title != null ? viewModel.Title.ToLower().Replace(" ", "-") : string.Empty,
            Brand = viewModel.BrandCategory,
            Model = viewModel.Model,
            Type = viewModel.TypeCategory,
            Seats = viewModel.Seats,
            RentPrice = viewModel.RentPrice,
            IsActive = viewModel.IsActive,
            Categories = new List<Category>()
        };

        if (viewModel.ImageFile != null)
        {
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
            var extension = Path.GetExtension(viewModel.ImageFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("ImageFile", "Only .jpg .png,.jpeg extensions allowed.");
                return View(viewModel);
            }

            var randomFileName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

            try
            {
                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await viewModel.ImageFile.CopyToAsync(stream);
                }

                car.Image = randomFileName;
            }
            catch
            {
                ModelState.AddModelError("ImageFile", "There were a problem uploading the file.");
                return View(viewModel);
            }
        }

        var typeCategory = await _categoryRepository.Categories
            .FirstOrDefaultAsync(c => c.TypeCategory == viewModel.TypeCategory);
        if (typeCategory != null)
            car.Categories.Add(typeCategory);

        var brandCategory = await _categoryRepository.Categories
            .FirstOrDefaultAsync(c => c.BrandCategory == viewModel.BrandCategory);
        if (brandCategory != null)
            car.Categories.Add(brandCategory);

        var seatCategory = await _categoryRepository.Categories
            .FirstOrDefaultAsync(c => c.SeatCategory == viewModel.Seats);
        if (seatCategory != null)
            car.Categories.Add(seatCategory);

        _carRepository.AddCar(car);
        return RedirectToAction("CarList");
    }

    [HttpGet]
    public async Task<IActionResult> EditCar(int id)
    {
        if (User.Identity!.Name != "admin")
            return RedirectToAction("Index", "Home");

        var car = await _carRepository.Cars.Include(c => c.Categories)
            .FirstOrDefaultAsync(c => c.CarID == id);
        if (car == null)
            return NotFound();

        ViewBag.TypeCategory = await _categoryRepository.Categories
            .Where(x => x.TypeCategory != null)
            .Select(x => x.TypeCategory)
            .Distinct()
            .ToListAsync();

        ViewBag.BrandCategory = await _categoryRepository.Categories
            .Where(x => x.BrandCategory != null)
            .Select(x => x.BrandCategory)
            .Distinct()
            .ToListAsync();

        ViewBag.SeatCategory = await _categoryRepository.Categories
            .Where(x => x.SeatCategory != null)
            .Select(x => x.SeatCategory)
            .Distinct()
            .ToListAsync();

        var viewModel = new CarViewModel
        {
            CarID = car.CarID,
            Title = car.Title,
            ExistingImage = car.Image,
            BrandCategory = car.Brand,
            TypeCategory = car.Type,
            Model = car.Model,
            Seats = car.Seats,
            RentPrice = car.RentPrice,
            IsActive = car.IsActive
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCar(int id, CarViewModel viewModel)
    {
        if (User.Identity!.Name != "admin")
            return RedirectToAction("Index", "Home");

        if (!ModelState.IsValid)
        {
            ViewBag.BrandCategory = new SelectList(
                await _categoryRepository.Categories
                    .Where(x => x.BrandCategory != null)
                    .Select(x => x.BrandCategory)
                    .Distinct()
                    .ToListAsync()
            );

            ViewBag.TypeCategory = new SelectList(
                await _categoryRepository.Categories
                    .Where(x => x.TypeCategory != null)
                    .Select(x => x.TypeCategory)
                    .Distinct()
                    .ToListAsync()
            );

            ViewBag.SeatCategory = new SelectList(
                await _categoryRepository.Categories
                    .Where(x => x.SeatCategory != null)
                    .Select(x => x.SeatCategory)
                    .Distinct()
                    .ToListAsync()
            );

            return View(viewModel);
        }

        var existingCar = await _carRepository.Cars
            .Include(c => c.Categories)
            .FirstOrDefaultAsync(c => c.CarID == id);

        if (existingCar == null)
            return NotFound();

        existingCar.Title = viewModel.Title;
        existingCar.Model = viewModel.Model;
        existingCar.Brand = viewModel.BrandCategory;
        existingCar.Type = viewModel.TypeCategory;
        existingCar.Seats = viewModel.Seats;
        existingCar.RentPrice = viewModel.RentPrice;
        existingCar.IsActive = viewModel.IsActive;

        if (viewModel.ImageFile != null)
        {
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
            var extension = Path.GetExtension(viewModel.ImageFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("ImageFile", "Only .jpg .png,.jpeg extensions are allowed.");
                return View(viewModel);
            }

            var randomFileName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

            try
            {
                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await viewModel.ImageFile.CopyToAsync(stream);
                }

                existingCar.Image = randomFileName;
            }
            catch
            {
                ModelState.AddModelError("ImageFile", "There were a problem uploading the file.");
                return View(viewModel);
            }
        }

        existingCar.Categories.Clear();

        var typeCategory = await _categoryRepository.Categories
            .FirstOrDefaultAsync(c => c.TypeCategory == viewModel.TypeCategory);
        if (typeCategory != null)
            existingCar.Categories.Add(typeCategory);

        var brandCategory = await _categoryRepository.Categories
            .FirstOrDefaultAsync(c => c.BrandCategory == viewModel.BrandCategory);
        if (brandCategory != null)
            existingCar.Categories.Add(brandCategory);

        var seatCategory = await _categoryRepository.Categories
            .FirstOrDefaultAsync(c => c.SeatCategory == viewModel.Seats);
        if (seatCategory != null)
            existingCar.Categories.Add(seatCategory);

        _carRepository.UpdateCar(existingCar);
        return RedirectToAction("CarList");
    }

    public async Task<IActionResult> DeleteCar(int id)
    {
        if (User.Identity!.Name != "admin") 
            return RedirectToAction("Index", "Home");

        var car = await _carRepository.Cars.FirstOrDefaultAsync(c => c.CarID == id);
        if (car == null) return NotFound();

        return View(car);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCar(int id, Car car)
    {
        if (User.Identity!.Name != "admin") return RedirectToAction("Index", "Home");
        var existingCar = await _carRepository.Cars.FirstOrDefaultAsync(c => c.CarID == id);
        if (existingCar == null) return NotFound();

        _carRepository.DeleteCar(existingCar);
        return RedirectToAction("CarList");

    }

    public async Task<IActionResult> UserList(string searchString)
    {
        if (User.Identity!.Name == "admin")
        {
            var users = await _userRepository.Users.ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.searchString = searchString;
                users = users.Where(c => c.Username!.ToLower().Contains(searchString!.ToLower())).ToList();
            }

            users = users.Where(c => c.Username != "admin").ToList();
            return View(users);
        }

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> DeleteUser(int id)
    {
        if (User.Identity!.Name != "admin") return RedirectToAction("Index", "Home");
        var user = await _userRepository.Users.FirstOrDefaultAsync(c => c.UserID == id);
        if (user == null) return NotFound();

        return View(user);

    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(int id, Car car)
    {
        if (User.Identity!.Name != "admin") return RedirectToAction("Index", "Home");
        var existingUser = await _userRepository.Users.FirstOrDefaultAsync(c => c.UserID == id);
        if (existingUser == null) return NotFound();

        _userRepository.DeleteUser(existingUser);
        return RedirectToAction("UserList");

    }
}