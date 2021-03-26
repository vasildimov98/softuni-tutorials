namespace AspNetCoreMVC.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class InformationController : Controller
    {
        public class DataViewModel
        {
            public int Year { get; set; }

            public int Month { get; set; }

            public int Day { get; set; }
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Table(int year, int month, int day)
        {
            this.ViewBag.StringTest = "Hello World";
            this.ViewBag.IntTest = 21;
            this.ViewBag.DecimalTest = 21.123M;

            var model = new DataViewModel
            {
                Year = year,
                Month = month,
                Day = day
            };

            return this.View(model);
        }

    }
}
