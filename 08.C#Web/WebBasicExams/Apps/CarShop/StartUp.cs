namespace CarShop
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using Microsoft.EntityFrameworkCore;

    using CarShop.Data;
    using MyWebServer.Results.Views;
    using CarShop.Services;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<ApplicationDbContext>()
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IValidator,Validator>()
                    .Add<IUsersService, UsersService>()
                    .Add<ICarsService, CarsService>()
                    .Add<IIssuesService, IssuesService>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database
                        .Migrate())
                .Start();
    }
}
