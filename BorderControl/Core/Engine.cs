namespace BorderControl.Core
{
    using System;
    using System.Linq;
    using BorderControl.IO.Contracts;
    using BorderControl.Models;
    using System.Collections.Generic;
    using BorderControl.Contracts;

    class Engine : IEngine
    {
        private List<IBuyer> people;

        private IReadable reader;
        private IWritable writer;
        private Engine()
        {
            this.people = new List<IBuyer>();
        }

        public Engine(IReadable reader, IWritable writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            GetPeople();
            PurchaseFood();
            PrintFoodPurchase();
        }

        private void PrintFoodPurchase()
        {
            var foodPurchase = this.people
                .Select(p => p.Food)
                .Sum();

            writer.WriteLine(foodPurchase.ToString());
        }

        private void PurchaseFood()
        {
            var name = (string)null;

            while ((name = reader.ReadLine()) != "End")
            {
                var person = this.people
                    .FirstOrDefault(p => p.Name == name);

                if (person != null)
                {
                    person.BuyFood();
                }
            }
        }

        private void GetPeople()
        {
            var n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var cmdArg = reader
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmdArg.Length == 4)
                {
                    GetCitizen(cmdArg);
                }
                else if (cmdArg.Length == 3)
                {
                    GetRebel(cmdArg);
                }
            }
        }

        private void GetRebel(string[] arg)
        {
            var name = arg[0];
            var age = int.Parse(arg[1]);
            var group = arg[2];

            var rebel = new Rebel(name, age, group);

            this.people.Add(rebel);
        }

        private void GetCitizen(string[] arg)
        {
            var name = arg[0];
            var age = int.Parse(arg[1]);
            var id = arg[2];
            var birthdate = arg[3];

            var person = new Citizen(name, age, id, birthdate);

            this.people.Add(person);
        }
    }
}
