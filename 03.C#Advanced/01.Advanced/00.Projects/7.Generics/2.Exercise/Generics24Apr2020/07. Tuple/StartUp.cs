using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        static void Main()
        {
            var personInfo = Console
                .ReadLine()
                .Split()
                .ToArray();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var adress = personInfo[2];

            var tuple1 = new Tuple<string, string>(fullName, adress);
            var beerCapacity = Console
               .ReadLine()
               .Split()
               .ToArray();
            var name = beerCapacity[0];
            var litersOfBeer = int.Parse(beerCapacity[1]);
            var tuple2 = new Tuple<string, int>(name, litersOfBeer);

            var types = Console
               .ReadLine()
               .Split()
               .ToArray();
            var integerNum = int.Parse(types[0]);
            var doubleNum = double.Parse(types[1]);
            var tuple3 = new Tuple<int, double>(integerNum, doubleNum);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
