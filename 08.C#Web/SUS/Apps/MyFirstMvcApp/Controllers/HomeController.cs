namespace MyFirstMvcApp.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Text;

    using SUS.HTTP;
    using SUS.MVC;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
