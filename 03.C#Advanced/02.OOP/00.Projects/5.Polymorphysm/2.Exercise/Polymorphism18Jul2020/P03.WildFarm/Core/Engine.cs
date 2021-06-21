namespace P03.WildFarm.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using Factories;
    using IO.Contracts;
    using Repositories;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly AnimalRepository animalRepository;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.animalRepository = new AnimalRepository();
        }

        public void Run()
        {
            this.ProceedCommand();
            this.PrintInformationAboutAnimal();
        }

        private void PrintInformationAboutAnimal()
        {
            this.writer.WriteLine(this.animalRepository.ToString());
        }

        private void ProceedCommand()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                var animalArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var animalType = animalArg[0];
                var animalName = animalArg[1];
                var animalWeight = double.Parse(animalArg[2]);

                var animal = this.GetAnimal(animalArg, animalType, animalName, animalWeight);
                this.animalRepository.Add(animal);

                var foodArgs = this.reader
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var foodType = foodArgs[0];
                var foodQuantity = int.Parse(foodArgs[1]);

                try
                {
                    var food = FoodFactory.CreateFood(foodType, foodQuantity);

                    writer.WriteLine(animal.ProduceSound);
                    animal.Eat(food);
                }
                catch (Exception ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }
        }

        private IAnimal GetAnimal(string[] animalArg, string type, string name, double weight)
        {
            IAnimal animal;
            if (type == "Cat" || type == "Tiger")
            {
                var livingRegion = animalArg[3];
                var breed = animalArg[4];

                animal = AnimalFactory.CreateFelines(type, name, weight, livingRegion, breed);
            }
            else if (type == "Owl" || type == "Hen")
            {
                var wingSize = double.Parse(animalArg[3]);

                animal = AnimalFactory.CreateBirds(type, name, weight, wingSize);
            }
            else
            {
                var livingRegion = animalArg[3];

                animal = AnimalFactory.CreateMammal(type, name, weight, livingRegion);
            }

            return animal;
        }
    }
}
