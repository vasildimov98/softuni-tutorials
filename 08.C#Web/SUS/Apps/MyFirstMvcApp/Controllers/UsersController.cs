namespace MyFirstMvcApp.Controllers
{
    using SUS.MVC;
    using SUS.HTTP;

    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }

        internal HttpResponse DoLogin(HttpRequest arg)
        {
            // Read Data
            // Validate Data
            // Save Data
            return this.Redirect("/");
        }
    }
}
