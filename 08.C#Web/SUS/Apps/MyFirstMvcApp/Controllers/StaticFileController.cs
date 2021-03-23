namespace MyFirstMvcApp.Controllers
{
    using System.IO;

    using SUS.MVC;
    using SUS.HTTP;

    public class StaticFileController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return this.File("image/vnd.microsoft.icon", "favicon.ico");
        }

        public HttpResponse CustomCss(HttpRequest request)
        {
            return this.File("text/css", @"css\custom.css");
        }

        public HttpResponse BootstrapMin(HttpRequest request)
        {
            return this.File("text/css", @"css\bootstrap.min.css");
        }

        public HttpResponse BootstrapBundleMin(HttpRequest request)
        {
            return this.File("text/javascript", @"js\bootstrap.bundle.min.js");
        }

        public HttpResponse CustomJavaScript(HttpRequest request)
        {
            return this.File("text/javascript", @"\js\custom.js");
        }
    }
}
