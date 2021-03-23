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
        }
    }
}
