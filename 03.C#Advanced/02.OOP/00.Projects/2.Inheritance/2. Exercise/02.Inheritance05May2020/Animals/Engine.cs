namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const string INVALID_EXEPTION = "Invalid input!";
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            this.GetAllAnimals();
           
           this.PrintResult();
        }

        private void PrintResult()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private void GetAllAnimals()
        {
            string type;
            while ((type = Console.ReadLine()) != "Beast!")
            {
                var animal = (Animal)null;

                try
                {
                    animal = GetAnimal(type);
                }
                catch (Exception)
                {

                    Console.WriteLine(INVALID_EXEPTION);
                    continue;
                }

                if (animal != null)
                {
                    this.animals.Add(animal);
                }
            }
        }

        private static Animal GetAnimal(string type)
        {
            var animal = (Animal)null;
            if (type == "Dog")
            {
                var animalArgs = GetArguments();

                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);
                var gender = animalArgs[2];

                animal = new Dog(name, age, gender);
            }
            else if (type == "Cat")
            {
                var animalArgs = GetArguments();

                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);
                var gender = animalArgs[2];

                animal = new Cat(name, age, gender);
            }
            else if (type == "Frog")
            {
                var animalArgs = GetArguments();

                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);
                var gender = animalArgs[2];

                animal = new Frog(name, age, gender);
            }
            else if (type == "Kittens")
            {
                var animalArgs = GetArguments();

                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);

                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                var animalArgs = GetArguments();

                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);

                animal = new Tomcat(name, age);
            }

            return animal;
        }

        private static string[] GetArguments()
        {
            return Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
