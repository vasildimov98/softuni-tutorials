namespace SUS.MVCFramework
{
    using System.Collections.Generic;

    using HTTP;

    public interface IMvcApplication
    {
        void ConfigureServices(IServiceCollection serviceCollection);

        void Configure(ICollection<Route> routes);
    }
}
