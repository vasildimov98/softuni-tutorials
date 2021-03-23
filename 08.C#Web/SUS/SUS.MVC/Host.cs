namespace SUS.MVC
{
    using HTTP;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Host
    {
        public static async Task CreateHostAsync<T>(int port)
            where T : IMvcApplication
        {
            var mvcApplication = Activator.CreateInstance(typeof(T)) as IMvcApplication;

            var routeTable = new List<Route>();

            mvcApplication.ConfigureServices();
            mvcApplication.Configure(routeTable);

            var server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }
    }
}
