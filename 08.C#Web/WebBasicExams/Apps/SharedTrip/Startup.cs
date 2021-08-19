namespace SharedTrip
{
    using System.Threading.Tasks;

    using SharedTrip.Data;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Services;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<ApplicationDbContext>()
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IValidator, Validator>()
                    .Add<IUsersService, UsersService>()
                    .Add<ITripsService, TripsService>())
                .WithConfiguration<ApplicationDbContext>(con => con.Database
                .Migrate())
                .Start();
    }
}
