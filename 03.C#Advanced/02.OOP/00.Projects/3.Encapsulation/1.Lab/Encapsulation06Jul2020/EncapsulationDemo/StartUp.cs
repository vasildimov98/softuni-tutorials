using System.Collections.Generic;
using System.Text;

namespace EncapsulationDemo
{
    public class StartUp
    {
        static void Main()
        {
            var msb = new MyStringBuilder();

            msb
                .AppendLine("Hello there")
                .AppendLine("What are you doing!")
                .AppendLine("I am Vasko!");

            var sb = new StringBuilder();

            Cat cat = null;
            try
            {
                cat = new Cat("Leo");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
    }
}
