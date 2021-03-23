namespace MyFirstMvcApp
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.MVC;
    using SUS.HTTP;

    using Controllers;

    public class Program
    {
        public static async Task Main()
        {
            await Host.CreateHostAsync(new Startup(), 8080);
        }
    }
}
