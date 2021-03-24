namespace BattleCards.Controllers
{
    using SUS.HTTP;
    using SUS.MVCFramework;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return View();
        }
    }
}
