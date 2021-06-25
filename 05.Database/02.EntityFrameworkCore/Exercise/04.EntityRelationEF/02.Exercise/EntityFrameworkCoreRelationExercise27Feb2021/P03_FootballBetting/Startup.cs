namespace P03_FootballBetting
{
    using Data;

    public class Startup
    {
        public static void Main()
        {
            var context = new FootballBettingContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //System.Console.WriteLine("Database created!!!");
        }
    }
}
