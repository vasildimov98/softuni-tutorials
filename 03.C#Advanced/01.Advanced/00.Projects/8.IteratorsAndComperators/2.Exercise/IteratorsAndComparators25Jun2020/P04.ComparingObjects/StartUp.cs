namespace P04.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();

            AddPeople(people);

            var index = int.Parse(Console.ReadLine());

            var personToCompareWith = people[index - 1];

            var count = 0;
            foreach (var person in people)
            {
                if (personToCompareWith.CompareTo(person) == 0)
                {
                    count++;
                }
            }

            Print(people, count);
        }

        private static void Print(List<Person> people, int count)
        {
            if (count == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{count} {people.Count - count} {people.Count}");
            }
        }

        private static void AddPeople(List<Person> list)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var args = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = args[0];
                var age = int.Parse(args[1]);
                var town = args[2];

                var person = new Person(name, age, town);

                list.Add(person);
            }
        }
    }
}
