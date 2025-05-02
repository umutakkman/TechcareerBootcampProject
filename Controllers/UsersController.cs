using System.Security.Claims;
using CarRentalWebsite.Data.Abstract;
using CarRentalWebsite.Models;
using CarRentalWebsite.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebsite.Controllers;

public class UsersController : Controller
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Login()
    {
        if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var isUser =
                await _userRepository.Users.FirstOrDefaultAsync(x =>
                    x.Username == model.Username && x.Password == model.Password);

            if (isUser != null)
            {
                var userClaims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, isUser.UserID.ToString()),
                    new(ClaimTypes.Name, isUser.Username ?? ""),
                    new(ClaimTypes.GivenName, isUser.NameSurname ?? ""),
                    new(ClaimTypes.Email, isUser.Email ?? "")
                };

                if (isUser.Username == "admin") userClaims.Add(new Claim(ClaimTypes.Role, "Admin"));

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties { IsPersistent = true };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync
                (
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Login info is not correct.");
            return View(model);
        }

        return View(model);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userRepository.Users.FirstOrDefaultAsync(x =>
                x.Username == model.Username || x.Email == model.Email);

            if (user == null)
            {
                _userRepository.AddUser(new User
                {
                    NameSurname = model.NameSurname,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                });
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Username or email is already in use.");
        }

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Profile()
    {
        return View();
    }
}