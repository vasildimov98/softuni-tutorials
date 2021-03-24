namespace BattleCards.Controllers
{
    using SUS.HTTP;
    using SUS.MVCFramework;

    using ViewModels;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/cards/all");
            }

            return this.View();
        }

        public HttpResponse About()
        {
            this.SingInUser("about");

            return View();
        }
    }
}
