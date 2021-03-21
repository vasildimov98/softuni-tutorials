using System;

namespace _12._TriFunction
{
    class StartUp
    {
        static void Main()
        {
            Func<string, int, bool> firstFunc = (x, y) =>
            {
                var sum = 0;
                foreach (var chr in x)
                {
                    sum += chr;
                }

                if (sum >= y)
                {
                    return true;
                }
                return false;
            };

            
            var length = int.Parse(Console.ReadLine());
            var names = Console
                .ReadLine()
                .Split();

            foreach (var name in names)
            {
             Func<Func<string, int, bool>, string> secondFunc = x =>
                {
                    var result = string.Empty;

                    if (x(name, length))
                    {
                        result = name;
                    }

                    return result;
                };

                var result = secondFunc(firstFunc);

                if (result.Length != 0)
                {
                    Console.WriteLine(result);
                    break;
                }
            }
        }
    }
}
