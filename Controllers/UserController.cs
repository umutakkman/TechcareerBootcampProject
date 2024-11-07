using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TechcareerBootcampFest4Project.Data.Abstract;
using TechcareerBootcampFest4Project.Models;

namespace TechcareerBootcampFest4Project.Controllers{

    public class UsersController : Controller{

        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model){
            if(ModelState.IsValid)
            {
                var isUser = await _userRepository.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);
                
                if(isUser != null)
                {
                    var userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, isUser.UserID.ToString()),
                        new Claim(ClaimTypes.Name, isUser.Username ?? ""),
                        new Claim(ClaimTypes.GivenName, isUser.NameSurname ?? ""),
                        new Claim(ClaimTypes.Email, isUser.Email ?? "")
                    };

                    if(isUser.Username == "admin")
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties{IsPersistent = true};

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync
                    (
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("","Giriş bilgileri yanlış.");
                    return View(model);
                }
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
            if(ModelState.IsValid)
            {
                var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.Username == model.Username || x.Email == model.Email);

                if(user == null)
                {
                    _userRepository.AddUser(new Entity.User
                    {
                        NameSurname = model.NameSurname,
                        Username = model.Username,
                        Email = model.Email,
                        Password = model.Password
                    });
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı adı veya email adresi kullanılmaktadır.");
                }
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
}