using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class StartUp
    {
        static void Main()
        {
            Func<string, bool> predicate = n => char.IsUpper(n[0]);

            var arr = Console
                 .ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Where(predicate)
                 .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, arr));
        }
    }
}
