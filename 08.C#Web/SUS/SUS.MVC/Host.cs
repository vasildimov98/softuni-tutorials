namespace SUS.MVC
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using HTTP;

    public static class Host
    {
        private const string StaticFileFolderName = "wwwroot";

        public static async Task CreateHostAsync<T>(int port)
            where T : IMvcApplication
        {
            var mvcApplication = Activator.CreateInstance(typeof(T)) as IMvcApplication;

            var routeTable = new List<Route>();

            mvcApplication.ConfigureServices();
            mvcApplication.Configure(routeTable);
            LoadStaticFiles(routeTable);

            Console.WriteLine("All register files");
            foreach (var registerRoute in routeTable)
            {
                Console.WriteLine(registerRoute.Path + " " + registerRoute.Method);
            }

            Console.WriteLine(new string('=', 100));

            var server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }

        private static void LoadStaticFiles(List<Route> routeTable)
        {
            var staticFiles = Directory.GetFiles(StaticFileFolderName, "*", SearchOption.AllDirectories);

            foreach (var staticFile in staticFiles)
            {
                var filePath = staticFile
                   .Replace(StaticFileFolderName, string.Empty)
                   .Replace("\\", "/");

                routeTable.Add(new Route(filePath, HttpMethod.GET, (request) =>
                {
                    var fileInfo = new FileInfo(staticFile);

                    var contentType = fileInfo.Extension switch
                    {
                        ".ico" => "image/vnd.microsoft.icon",
                        ".css" => "text/css",
                        ".js" => "text/javascript",
                        ".jpg" => "image/jpg",
                        ".jpeg" => "image/jpg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        ".html" => "text/html",
                        _ => "text/plain"
                    };

                    var fileBytes = File.ReadAllBytes(staticFile);

                    var response = new HttpResponse(contentType, fileBytes);

                    return response;
                }));
            }
        }
    }
}
