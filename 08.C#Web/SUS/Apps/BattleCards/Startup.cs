namespace BattleCards
{
    using Microsoft.EntityFrameworkCore;

    using SUS.MVC;
    using Models.Data;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {

        }

        public void Configure()
        {
            new BattleCardsDbContext().Database.Migrate();
        }
    }
}
