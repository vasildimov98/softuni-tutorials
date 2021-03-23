namespace SUS.MVC
{
    using System.Collections.Generic;

    using SUS.HTTP;

    public interface IMvcApplication
    {
        void ConfigureServices();

        void Configure(List<Route> routeTable);
    }
}
