namespace MyFirstMvcApp
{
    using System.Threading.Tasks;

    using SUS.MVC;

    public class Program
    {
        public static async Task Main()
        {
            await Host.CreateHostAsync<Startup>(8080);
        }
    }
}
