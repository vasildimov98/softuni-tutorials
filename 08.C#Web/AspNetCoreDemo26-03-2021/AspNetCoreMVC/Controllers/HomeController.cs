namespace AspNetCoreMVC.Controllers
{
    using System.Diagnostics;
    using AspNetCoreMVC.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Models;
    using ViewModels;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) 
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About(int year, int month, int day)
        {
            this.ViewBag.Year = year;
            this.ViewBag.Month = month;
            this.ViewBag.Day = day;
            this.ViewBag.Day = "Day is string";

            this.ViewData["year"] = year;
            this.ViewData["year"] = "Year is string";
            this.ViewData["month"] = month;
            this.ViewData["day"] = day;

            var model = new DataViewModel
            {
                Year = year,
                Month = month,
                Day = day
            };

            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
