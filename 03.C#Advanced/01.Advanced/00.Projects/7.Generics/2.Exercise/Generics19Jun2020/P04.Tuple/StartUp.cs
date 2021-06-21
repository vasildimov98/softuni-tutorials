namespace P04.Tuple
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var personArgs = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.None)
                .ToArray();

            var firstName = personArgs[0];
            var lastName = personArgs[1];
            var address = personArgs[2];

            var fullName = $"{firstName} {lastName}";

            var personTuple = MyTuple<string, string>.Create(fullName, address);

            var beerCapacityArgs = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.None)
                .ToArray();

            var name = beerCapacityArgs[0];
            var litersOfBeer = int.Parse(beerCapacityArgs[1]);

            var beerTuple = MyTuple<string, int>.Create(name, litersOfBeer);

            var uselessArg = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.None)
                .ToArray();

            var firstUseless = int.Parse(uselessArg[0]);
            var secondUseless = double.Parse(uselessArg[1]);

            var uselessTuple = MyTuple<int, double>.Create(firstUseless, secondUseless);

            PrintResult(personTuple, beerTuple, uselessTuple);
        }

        private static void PrintResult(MyTuple<string, string> personTuple, MyTuple<string, int> beerTuple, MyTuple<int, double> uselessTuple)
        {
            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(uselessTuple);
        }

        //private static Tuple<T1, T2> CreateTuple<T1, T2>(T1 firstArg, T2 secondArg)
        //{
        //    return new Tuple<T1, T2>(firstArg, secondArg);
        //}

        private static void TupleDemo()
        {
            var primes = GetPrimeNumbers();
            Console.WriteLine("Prime numbers less than 20: " +
                              "{0}, {1}, {2}, {3}, {4}, {5}, {6}, and {7}",
                              primes.Item1, primes.Item2, primes.Item3,
                              primes.Item4, primes.Item5, primes.Item6,
                              primes.Item7, primes.Rest.Item1);

            Console.WriteLine(primes.Item1.Key);
            Console.WriteLine(primes.Item1.Value);
        }

        public static Tuple<KeyValuePair<string, int>, string, int, int, int, int, int, Tuple<int>> GetPrimeNumbers()
        {
            return Tuple.Create(new KeyValuePair<string, int>("Vasko", 22), "Sofia", 5, 7, 11, 13, 17, 19);
        }
    }
}
