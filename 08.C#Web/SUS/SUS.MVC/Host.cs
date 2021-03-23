namespace SUS.MVC
{
    using HTTP;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Host
    {
        public static async Task CreateHostAsync(IMvcApplication mvcApplication, int port)
        {
            var routeTable = new List<Route>();

            mvcApplication.ConfigureServices();
            mvcApplication.Configure(routeTable);

            var server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }
    }
}
