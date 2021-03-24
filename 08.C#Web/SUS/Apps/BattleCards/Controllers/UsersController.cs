namespace BattleCards.Controllers
{
    using SUS.HTTP;
    using SUS.MVCFramework;

    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return View();
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        internal HttpResponse DoLogin()
        {
            // Read Data
            // Validate Data
            // Save Data
            return Redirect("/");
        }
    }
}
