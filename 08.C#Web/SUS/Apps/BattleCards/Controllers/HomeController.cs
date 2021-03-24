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
            if (this.IsUserSignIn())
            {
                return this.Redirect("/cards/all");
            }

            return this.View();
        }
    }
}
