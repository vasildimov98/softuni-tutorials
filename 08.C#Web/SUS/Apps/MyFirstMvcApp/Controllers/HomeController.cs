namespace MyFirstMvcApp.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Text;

    using SUS.HTTP;
    using SUS.MVC;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
