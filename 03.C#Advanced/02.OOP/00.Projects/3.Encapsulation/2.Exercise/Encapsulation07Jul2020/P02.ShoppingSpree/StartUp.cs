namespace P02.ShoppingSpree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var peopleInfo = Console
                .ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var productsInfo = Console
                .ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            try
            {
                AddPeople(people, peopleInfo);
                AddProducts(products, productsInfo);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);

                return;
            }

            BuyAllProducts(people, products);

            PrintInformationAboutPeople(people);
        }

        private static void PrintInformationAboutPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void BuyAllProducts(List<Person> people, List<Product> products)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var args = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var personName = args[0];
                var productName = args[1];
                try
                {
                    BuyProduct(people, products, personName, productName);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (ArgumentNullException)
                {
                    continue;
                }
            }
        }

        private static void BuyProduct(List<Person> people, List<Product> products, string personName, string productName)
        {
            var person = people
                .FirstOrDefault(p => p.Name == personName);
            var product = products
                .FirstOrDefault(pr => pr.Name == productName);

            if (person == null || product == null)
            {
                throw new ArgumentNullException();
            }

            var msg = person.BuyProduct(product);

            Console.WriteLine(msg);
        }

        private static void AddPeople(List<Person> people, string[] peopleInfo)
        {
            foreach (var personInfo in peopleInfo)
            {
                var personArgs = personInfo
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = personArgs[0];
                var money = int.Parse(personArgs[1]);

                var person = new Person(name, money);

                people.Add(person);
            }
        }

        private static void AddProducts(List<Product> products, string[] productsInfo)
        {
            foreach (var productInfo in productsInfo)
            {
                var productArgs = productInfo
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = productArgs[0];
                var cost = int.Parse(productArgs[1]);

                var product = new Product(name, cost);

                products.Add(product);
            }
        }
    }
}
