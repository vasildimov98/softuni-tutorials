namespace MyFirstMvcApp
{
    using System.Collections.Generic;

    using SUS.MVC;
    using SUS.HTTP;
    using Controllers;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
        }

        public void Configure(List<Route> routeTable)
        {
            routeTable.Add(new Route("/", HttpMethod.GET, new HomeController().Index));
            routeTable.Add(new Route("/users/login", HttpMethod.GET, new UsersController().Login));
            routeTable.Add(new Route("/users/login", HttpMethod.POST, new UsersController().DoLogin));
            routeTable.Add(new Route("/users/register", HttpMethod.GET, new UsersController().Register));
            routeTable.Add(new Route("/cards/add", HttpMethod.GET, new CardsController().Add));
            routeTable.Add(new Route("/cards/all", HttpMethod.GET, new CardsController().All));
            routeTable.Add(new Route("/cards/collection", HttpMethod.GET, new CardsController().Collection));
            routeTable.Add(new Route("/favicon.ico", HttpMethod.GET, new StaticFileController().Favicon));
            routeTable.Add(new Route("/css/custom.css", HttpMethod.GET, new StaticFileController().CustomCss));
            routeTable.Add(new Route("/css/bootstrap.min.css", HttpMethod.GET, new StaticFileController().BootstrapMin));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", HttpMethod.GET, new StaticFileController().Favicon));
            routeTable.Add(new Route("/js/custom.js", HttpMethod.GET, new StaticFileController().CustomJavaScript));
        }
    }
}
