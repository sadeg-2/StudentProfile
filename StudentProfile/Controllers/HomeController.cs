using CMS.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using STD.Infrastructure.Services.Users;
using StudentProfile.Models;
using System.Diagnostics;

namespace StudentProfile.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IUserService userService):base(userService)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Profile() {
            var user = await _userService.GetUserById(userId);          
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}