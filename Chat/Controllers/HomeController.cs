using Chat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateUser()
        {
            await _userManager.CreateAsync(new AppUser { Email = "Jesus@mail.ru", UserName = "Jesus" },"Jesus123@");
            await _userManager.CreateAsync(new AppUser { Email = "Nicat@mail.ru", UserName = "Nicat" },"Nicat123@");
            await _userManager.CreateAsync(new AppUser { Email = "Sineray@mail.ru", UserName = "Sineray" },"Sineray123@");
            return Json("ok");
        }

 
    }
}