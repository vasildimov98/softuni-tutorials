namespace P05.Threeuple
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var personArgs = Console
                .ReadLine()
                .Split(' ', 4, StringSplitOptions.None)
                .ToArray();

            var firstName = personArgs[0];
            var lastName = personArgs[1];
            var address = personArgs[2];
            var town = personArgs[3];

            var fullName = $"{firstName} {lastName}";

            var personTuple = Threeuple<string, string, string>.Create(fullName, address, town);

            var beerCapacityArgs = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.None)
                .ToArray();

            var name = beerCapacityArgs[0];
            var litersOfBeer = int.Parse(beerCapacityArgs[1]);

            bool isDrunk;
            if (beerCapacityArgs[2] == "drunk")
            {
                isDrunk = true;
            }
            else
            {
                isDrunk = false;
            }

            var beerTuple = Threeuple<string, int, bool>.Create(name, litersOfBeer, isDrunk);

            var bankArgs = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.None)
                .ToArray();

            var accounter = bankArgs[0];
            var acountBalance = double.Parse(bankArgs[1]);
            var bankName = bankArgs[2];

            var bankTuple = Threeuple<string, double, string>.Create(accounter, acountBalance, bankName);

            PrintResult(personTuple, beerTuple, bankTuple);
        }

        private static void PrintResult(object personTuple, object beerTuple, object bankTuple)
        {
            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(bankTuple);
        }
    }
}
