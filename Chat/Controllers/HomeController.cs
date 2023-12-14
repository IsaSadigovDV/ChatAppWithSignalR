using Chat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Chat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> appUsers = await _userManager.Users.ToListAsync();
            return View(appUsers);
        }

        public async Task<IActionResult> CreateUser()
        {
            await _userManager.CreateAsync(new AppUser { Email = "Jesus@mail.ru", UserName = "Jesus" },"Jesus123@");
            await _userManager.CreateAsync(new AppUser { Email = "Nicat@mail.ru", UserName = "Nicat" },"Nicat123@");
            await _userManager.CreateAsync(new AppUser { Email = "Semral@mail.ru", UserName = "Semral" },"Semral123@");
            return Json("ok");
        }

 
    }
}