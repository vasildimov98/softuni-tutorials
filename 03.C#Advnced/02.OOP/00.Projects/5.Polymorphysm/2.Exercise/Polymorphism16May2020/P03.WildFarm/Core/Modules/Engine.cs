namespace P03.WildFarm.Core.Modules
{
    using System.Linq;
    using System.Collections.Generic;

    using P03.WildFarm.Contract;
    using P03.WildFarm.Core.Contracts;
    using P03.WildFarm.Factories;
    using P03.WildFarm.IO.Contracts;

    public class Engine : IEngine
    {
        private ICollection<IAnimal> animals = new List<IAnimal>();

        private IReadable reader;
        private IWritable writer;
        public Engine(IReadable readable, IWritable writable)
        {
            this.reader = readable;
            this.writer = writable;
        }
        public void Run()
        {
            GetAllAnimal();
            PrintAllAnimals();
        }

        private void PrintAllAnimals()
        {
            foreach (var animal in this.animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }

        private void GetAllAnimal()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                var animalArg = command
                     .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

                var animalType = animalArg[0];
                var animalName = animalArg[1];
                var animalWeight = double.Parse(animalArg[2]);

                IAnimal animal;
                animal = ProduceAnimal(animalArg, animalType, animalName, animalWeight);

                var foodArg = reader
                    .ReadLine()
                    .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var foodType = foodArg[0];
                var foodQuantity = int.Parse(foodArg[1]);

                FeedAnimal(animal, foodType, foodQuantity);

                this.animals.Add(animal);
            }
        }

        private void FeedAnimal(IAnimal animal, string foodType, int foodQuantity)
        {
            writer.WriteLine(animal.AskForFood());

            var type = animal.GetType().Name;
            if (type == "Hen")
            {
                animal.Eat(foodQuantity);
            }
            else if (type == "Mouse")
            {
                if (foodType == "Vegetable" || foodType == "Fruit")
                {
                    animal.Eat(foodQuantity);
                }
                else
                {
                    writer.WriteLine($"{type} does not eat {foodType}!");
                }
            }
            else if (type == "Cat")
            {
                if (foodType == "Vegetable" || foodType == "Meat")
                {
                    animal.Eat(foodQuantity);
                }
                else
                {
                    writer.WriteLine($"{type} does not eat {foodType}!");
                }
            }
            else if ((type == "Tiger" || type == "Dog" || type == "Owl"))
            {
                if (foodType == "Meat")
                {
                    animal.Eat(foodQuantity);
                }
                else
                {
                    writer.WriteLine($"{type} does not eat {foodType}!");
                }
            }
        }

        private static IAnimal ProduceAnimal(string[] animalArg, string type, string name, double weight)
        {
            IAnimal animal;
            if (type == "Cat" || type == "Tiger")
            {
                var livingRegion = animalArg[3];
                var breed = animalArg[4];
                animal = AnimalFactory
                    .CreateFelines(type,
                    name,
                    weight,
                    livingRegion,
                    breed);
            }
            else if (type == "Owl" || type == "Hen")
            {
                double wingSize = double.Parse(animalArg[3]);
                animal = AnimalFactory
                    .CreateBirds(type, name, weight, wingSize);
            }
            else
            {
                var livingRegion = animalArg[3];
                animal = AnimalFactory
                    .CreateMammals(type, name, weight, livingRegion);
            }

            return animal;
        }
    }
}
