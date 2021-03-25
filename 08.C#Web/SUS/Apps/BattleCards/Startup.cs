namespace BattleCards
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Services;
    using Models.Data;

    using SUS.HTTP;
    using SUS.MVCFramework;


    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<ICardService, CardService>();
        }

        public void Configure(ICollection<Route> routes)
        {
            new BattleCardsDbContext().Database.Migrate();
        }
    }
}
