namespace BattleCards
{
    using System.Threading.Tasks;

    using SUS.MVCFramework;

    public class Program
    {
        public static async Task Main()
        {
            await Host.CreateHostAsync<Startup>(8080);
        }
    }
}
