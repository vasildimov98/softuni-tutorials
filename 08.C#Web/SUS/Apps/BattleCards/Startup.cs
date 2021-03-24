namespace BattleCards
{
    using Microsoft.EntityFrameworkCore;

    using Models.Data;
    using SUS.MVCFramework;

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
