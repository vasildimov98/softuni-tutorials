namespace BattleCards.Controllers
{
    using SUS.MVC;
    using SUS.HTTP;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return View();
        }
    }
}
