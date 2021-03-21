using System;
using System.Collections.Generic;

namespace _05._Shopping_Spree
{
    class Program
    {
        static void Main()
        {
            string[] dataForPersons = Console
                .ReadLine()
                .Split(";");

            List<Person> people = new List<Person>();
            List<Products> products = new List<Products>();
            for (int i = 0; i < dataForPersons.Length; i++)
            {
                string[] data = dataForPersons[i].Split("=");
            
                string name = data[0];
                double money = double.Parse(data[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
            string[] dataForProducts = Console
                .ReadLine()
                .Split(";");

            for (int i = 0; i < dataForProducts.Length; i++)
            {
                if (dataForProducts[i] != "")
                {
                    string[] data = dataForProducts[i].Split("=");

                    string name = data[0];
                    double money = double.Parse(data[1]);

                    Products product = new Products(name, money);
                    products.Add(product);
                }
            }

            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();

                string name = data[0];
                string product = data[1];

                double cost = 0;

                foreach (var produc in products)
                {
                    if (produc.Name == product)
                    {
                        cost = produc.Cost;
                        break;
                    }
                }

                foreach (var person in people)
                {
                    if (person.Name == name)
                    {
                        if (person.Money >= cost)
                        {
                            person.AddProducts(product, cost);
                            Console.WriteLine($"{person.Name} bought {product}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{person.Name} can't afford {product}");
                            break;
                        }
                    }
                }
            }

            foreach (var person in people)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                }
            }
        }
    }

    class Person
    {
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        public string Name { get; set; }

        public double Money { get; set; }

        public List<string> BagOfProducts { get; set; }

        public void AddProducts(string product, double cost)
        {
            Money -= cost;
            BagOfProducts.Add(product);
        }
    }

    class Products
    {
        public Products(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
