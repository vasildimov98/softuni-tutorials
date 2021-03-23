namespace BattleCards.Controllers
{
    using SUS.MVC;
    using SUS.HTTP;

    using ViewModels;

    public class CardsController : Controller
    {
        public HttpResponse All()
        {
            return View();
        }

        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var viewModel = new DoAddViewModel
            {
                Name = this.Request.FormData["name"],
                Attack = int.Parse(this.Request.FormData["attack"]),
                Health = int.Parse(this.Request.FormData["health"]),
            };

            return View(viewModel);
        }

        public HttpResponse Collection()
        {
            return View();
        }

    }
}
