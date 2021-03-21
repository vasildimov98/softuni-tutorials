namespace DefiningClasses
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var family = new Family();

            var numberOfPeople = int.Parse(Console.ReadLine());

            GetFamily(family, numberOfPeople);

            PrintPeopleMoreThanThirty(family);
        }

        private static void PrintPeopleMoreThanThirty(Family family)
        {
            var oldestMembers = family.GetAllPeopleOlderThanThirty();

            foreach (var person in oldestMembers)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

        private static void GetFamily(Family family, int numberOfPeople)
        {
            for (int i = 0; i < numberOfPeople; i++)
            {
                var personArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = personArgs[0];
                var age = int.Parse(personArgs[1]);

                var person = new Person(name, age);

                family.AddMember(person);
            }
        }
    }
}
