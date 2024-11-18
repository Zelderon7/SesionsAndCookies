using Microsoft.AspNetCore.Mvc;
using SessionAndCookies.Models;
using System.Diagnostics;

namespace SessionAndCookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Storing the user name in the session
        [HttpPost]
        public IActionResult SetUserName(string userName)
        {
            HttpContext.Session.SetString("UserName", userName);
            return RedirectToAction("Index");
        }

        public IActionResult SetCookie(string preference)
        {
           Response.Cookies.Append("UserPreference", preference, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7),
                HttpOnly = true,
                IsEssential = true
            });

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            // Извличане на UserPreference от бисквитката
            if (Request.Cookies.TryGetValue("UserPreference", out string userPreference))
            {
                ViewBag.UserPreference = userPreference;
            }
            else
            {
                ViewBag.UserPreference = "Default"; // Стойност по подразбиране, ако няма зададена бисквитка
            }

            ViewBag.UserName = HttpContext.Session.GetString("UserName"); // Вземане на името от сесията, ако е налично
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
