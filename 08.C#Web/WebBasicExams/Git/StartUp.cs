namespace Git
{
    using System.Threading.Tasks;

    using Git.Data;
    using Git.Services;
    using Microsoft.EntityFrameworkCore;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

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
                   .Add<IValidator, Validator>()
                   .Add<IUsersService, UsersService>()
                   .Add<IRepositoriesService, RepositoriesService>()
                   .Add<ICommitsService, CommitsService>())
               .WithConfiguration<ApplicationDbContext>(con =>
                    con.Database.Migrate())
               .Start();
    }
}
