namespace MyFirstMvcApp.Controllers
{
    using SUS.MVC;
    using SUS.HTTP;

    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        internal HttpResponse DoLogin()
        {
            // Read Data
            // Validate Data
            // Save Data
            return this.Redirect("/");
        }
    }
}
