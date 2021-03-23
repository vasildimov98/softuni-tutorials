namespace MyFirstMvcApp
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.MVC;

    using Controllers;
    using SUS.HTTP;

    public class Program
    {
        public static async Task Main()
        {
            var routes = new List<Route>
            {
                new Route("/", HttpMethod.GET, new HomeController().Index),
                new Route("/users/login", HttpMethod.GET, new UsersController().Login),
                new Route("/users/login", HttpMethod.POST, new UsersController().DoLogin),
                new Route("/users/register", HttpMethod.GET, new UsersController().Register),
                new Route("/cards/add", HttpMethod.GET, new CardsController().Add),
                new Route("/cards/all", HttpMethod.GET, new CardsController().All),
                new Route("/cards/collection", HttpMethod.GET, new CardsController().Collection),

                new Route("/favicon.ico", HttpMethod.GET, new StaticFileController().Favicon),
                new Route("/css/custom.css", HttpMethod.GET, new StaticFileController().CustomCss),
                new Route("/css/bootstrap.min.css", HttpMethod.GET, new StaticFileController().BootstrapMin),
                new Route("/js/bootstrap.bundle.min.js", HttpMethod.GET, new StaticFileController().Favicon),
                new Route("/js/custom.js", HttpMethod.GET, new StaticFileController().CustomJavaScript),
            };

            await Host.CreateHostAsync(routes, 8080);
        }
    }
}
