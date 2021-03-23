namespace MyFirstMvcApp.Controllers
{
    using SUS.MVC;
    using SUS.HTTP;

    public class CardsController : Controller
    {
        public HttpResponse All(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Add(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Collection(HttpRequest request)
        {
            return this.View();
        }
    }
}
