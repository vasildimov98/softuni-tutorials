namespace SUS.MVC
{
    using HTTP;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Host
    {
        public static async Task CreateHostAsync(List<Route> routes, int port)
        {
            var server = new HttpServer(routes);

            await server.StartAsync(port);
        }
    }
}
