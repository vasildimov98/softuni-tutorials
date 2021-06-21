namespace P03.ShoppingSpree.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P03.ShoppingSpree.Modules;

    public class Engine
    {
        private List<Person> people;
        private List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            GetAllPeople();
            GetAllProducts();
            GetAllShoppings();
            PrintResult();
        }

        private void PrintResult()
        {
            foreach (var person in this.people)
            {
                Console.WriteLine(person);
            }
        }

        private void GetAllShoppings()
        {
            string commad;
            while ((commad = Console.ReadLine()) != "END")
            {
                var buyingArg = commad
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var name = buyingArg[0];
                    var productName = buyingArg[1];

                    var person = this.people
                        .FirstOrDefault(p => p.Name == name);
                    var product = this.products
                        .FirstOrDefault(pr => pr.Name == productName);

                    var msg = person.AddProduct(product);
                    Console.WriteLine(msg);
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }

        private void GetAllProducts()
        {

            var productsArg = Console
                         .ReadLine()
                         .Split(';', StringSplitOptions.RemoveEmptyEntries)
                         .ToArray();
            for (int i = 0; i < productsArg.Length; i++)
            {
                var productArg = productsArg[i]
                    .Split('=', StringSplitOptions.None)
                    .ToArray();

                var name = productArg[0];
                var cost = int.Parse(productArg[1]);

                var product = new Product(name, cost);

                this.products.Add(product);
            }
        }

        private void GetAllPeople()
        {
            var peopleArg = Console
                     .ReadLine()
                     .Split(';', StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

            for (int i = 0; i < peopleArg.Length; i++)
            {
                var personArg = peopleArg[i]
                    .Split('=', StringSplitOptions.None)
                    .ToArray();

                var name = personArg[0];
                var money = int.Parse(personArg[1]);

                var person = new Person(name, money);

                this.people.Add(person);
            }
        }
    }
}
