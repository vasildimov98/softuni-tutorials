namespace SUS.MVCFramework
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

            var serviceCollection = new ServiceCollection();

            var routeTable = new List<Route>();

            mvcApplication.ConfigureServices(serviceCollection);
            mvcApplication.Configure(routeTable);

            LoadStaticFileRoute(routeTable);
            LoadPageRoutes(mvcApplication, routeTable, serviceCollection);

            var server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }

        private static void LoadPageRoutes(IMvcApplication mvcApplication, List<Route> routeTable, IServiceCollection serviceCollection)
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

                    routeTable.Add(new Route(url, method, RegisterAction(serviceCollection, controllerType, methodType)));
                }
            }
        }

        private static Func<HttpRequest, HttpResponse> RegisterAction(IServiceCollection serviceCollection, Type controllerType, MethodInfo methodType)
        {
            return (request) =>
            {
                var controller = serviceCollection.CreateInstance(controllerType) as Controller;

                controller.Request = request;

                var parameters = new List<object>();

                foreach (var parameter in methodType.GetParameters())
                {
                    var parameterValueAsString = GetParameterValue(request, parameter.Name);
                    var parameterValue = Convert.ChangeType(parameterValueAsString, parameter.ParameterType);

                    if (parameterValue == null 
                    && parameter.ParameterType != typeof(string))
                    {
                        parameterValue = Activator.CreateInstance(parameter.ParameterType);

                        var properties = parameter.ParameterType.GetProperties();

                        foreach (var property in properties)
                        {
                            var propertyValueAsString = GetParameterValue(request, property.Name);
                            var propertyValue = Convert.ChangeType(propertyValueAsString, property.PropertyType);
                            property.SetValue(parameterValue, propertyValue);
                        }
                    }

                    parameters.Add(parameterValue);
                }

                var response = methodType.Invoke(controller, parameters.ToArray()) as HttpResponse;

                return response;
            };
        }

        private static object GetParameterValue(HttpRequest request, string parameterName)
        {
            parameterName = parameterName.ToLower();
            if (request.FormData.Any(x => x.Key.ToLower() == parameterName))
            {
                return request.FormData
                    .FirstOrDefault(x => x.Key.ToLower() == parameterName).Value;
            }

            if (request.QueryStringData.Any(x => x.Key.ToLower() == parameterName))
            {
                return request.QueryStringData
                    .FirstOrDefault(x => x.Key.ToLower() == parameterName).Value;
            }

            return null;
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
