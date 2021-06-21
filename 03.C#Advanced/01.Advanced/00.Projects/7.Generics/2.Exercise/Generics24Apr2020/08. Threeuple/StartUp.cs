using System;
using System.Linq;

namespace Threeuple
{
    class StartUp
    {
        static void Main()
        {
            var personInfo = Console
                .ReadLine()
                .Split(' ', 3, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var fullName = $"{personInfo[0]} {personInfo[1]}";

            var nextData = personInfo[2]
                .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var adress = nextData[0];
            var town = nextData[1];
            var threeuple1 = new Threeuple<string, string, string>(fullName, adress, town);

            var personBeerCapacity = Console
                .ReadLine()
                .Split();
            var name = personBeerCapacity[0];
            var beerCapacity = int.Parse(personBeerCapacity[1]);
            var drunkOrNot = personBeerCapacity[2];
            var isDrunk = DrunkOrNot(drunkOrNot);
            var threeuple2 = new Threeuple<string, int, bool>(name, beerCapacity, isDrunk);

            var personBankInfo = Console
                .ReadLine()
                .Split();
            var name1 = personBankInfo[0];
            var bankBalance = double.Parse(personBankInfo[1]);
            var bankName = personBankInfo[2];
            var threeuple3 = new Threeuple<string, double, string>(name1, bankBalance, bankName);

            Console.WriteLine(threeuple1);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);

        }

        static bool DrunkOrNot(string str)
        {
            if (str == "drunk")
            {
                return true;
            }
            return false;
        }

    }
}
