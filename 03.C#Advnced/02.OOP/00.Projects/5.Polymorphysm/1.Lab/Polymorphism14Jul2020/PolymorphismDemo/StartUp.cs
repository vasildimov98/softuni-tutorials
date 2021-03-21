namespace PolymorphismDemo
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            IAnimal ianimal = new Person("Pesho");
            Mammal mammal = new Person("Pesho");
            Person person = new Person("Pesho");
            Monkey monkey = new Monkey("Pesho");

            Console.WriteLine(ianimal.Sleep());
            Console.WriteLine(mammal.Name);
            Console.WriteLine(person.Speak("Hi!"));

            var list = new List<IAnimal>
            {
                ianimal,
                mammal,
                person,
                monkey
            };

            foreach (var animal in list)
            {
                Console.WriteLine(animal.GetType().Name);
            }

            if (ianimal is Mammal castMammal)
            {
                Console.WriteLine(castMammal.Name);
            }

            if (int.Parse(Console.ReadLine()) is 20)
            {
                Console.WriteLine("They match!");
            }

            if (ianimal is var varMammal)
            {
                Console.WriteLine(varMammal.Sleep());
            }

            var square = new Square();
            var rectangle = new Rectangle();

            Console.WriteLine(rectangle.Area());
            Console.WriteLine(square.Area());
        }
    }
}
