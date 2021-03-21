namespace Animals
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            const string FINAL_COMMAND = "Beast!";

            string typeOfAnimal;
            while ((typeOfAnimal = Console.ReadLine()) != FINAL_COMMAND)
            {
                var animalArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);
                var gender = animalArgs[2];

                try
                {
                    Animal animal;
                    animal = CreateAnimal(typeOfAnimal, name, age, gender);

                    Console.WriteLine(animal.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Animal CreateAnimal(string typeOfAnimal, string name, int age, string gender)
        {
            const string DOG = "Dog";
            const string CAT = "Cat";
            const string FROG = "Frog";
            const string KITTEN = "Kitten";
            const string TOMCAT = "Tomcat";

            Animal animal;
            if (typeOfAnimal == DOG)
            {
                animal = new Dog(name, age, gender);
            }
            else if (typeOfAnimal == CAT)
            {
                animal = new Cat(name, age, gender);
            }
            else if (typeOfAnimal == FROG)
            {
                animal = new Frog(name, age, gender);
            }
            else if (typeOfAnimal == KITTEN)
            {
                animal = new Kitten(name, age);
            }
            else if (typeOfAnimal == TOMCAT)
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new Exception("Invalid input!");
            }

            return animal;
        }
    }
}
