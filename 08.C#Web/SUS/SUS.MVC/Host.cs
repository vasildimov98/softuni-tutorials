namespace SUS.MVC
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using HTTP;
    using System.Linq;
    using System.Reflection;

    public static class Host
    {
        private const string StaticFileFolderName = "wwwroot";

        public static async Task CreateHostAsync<T>(int port)
            where T : IMvcApplication
        {
            var mvcApplication = Activator.CreateInstance(typeof(T)) as IMvcApplication;

            var routeTable = new List<Route>();

            LoadStaticFileRoute(routeTable);
            LoadPageRoutes(mvcApplication, routeTable);

            mvcApplication.ConfigureServices();
            mvcApplication.Configure();

            var server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }

        private static void LoadPageRoutes(IMvcApplication mvcApplication, List<Route> routeTable)
        {
            var controllerTypes = mvcApplication
                            .GetType().Assembly
                            .GetTypes()
                            .Where(x => x.IsClass
                                && !x.IsAbstract
                                && x.IsSubclassOf(typeof(Controller)));

            foreach (var controllerType in controllerTypes)
            {
                var controllerMethods = controllerType
                    .GetMethods()
                    .Where(x => x.DeclaringType == controllerType
                        && x.IsPublic
                        && !x.IsStatic
                        && !x.IsConstructor
                        && !x.IsAbstract
                        && !x.IsSpecialName);

                foreach (var methodType in controllerMethods)
                {
                    var url = '/'
                         + controllerType.Name
                                .Replace("Controller", string.Empty)
                         + '/'
                         + methodType.Name;

                    var customAttribute = methodType
                        .GetCustomAttribute(typeof(HttpBaseAttribute)) as HttpBaseAttribute;

                    var method = HttpMethod.GET;

                    if (!string.IsNullOrWhiteSpace(customAttribute?.Url))
                    {
                        url = customAttribute.Url;
                        method = customAttribute.Method;
                    }

                    routeTable.Add(new Route(url, method, (request) =>
                    {
                        var controller = Activator.CreateInstance(controllerType) as Controller;

                        controller.Request = request;

                        var response = methodType.Invoke(controller, new object[] { }) as HttpResponse;

                        return response;
                    }));
                }
            }
        }

        private static void LoadStaticFileRoute(List<Route> routeTable)
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
