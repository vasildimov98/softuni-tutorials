using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    public class StartUp
    {
        static void Main()
        {
            string command;
            var people = new List<Person>();
            while ((command = Console.ReadLine()) != "END")
            {
                var data = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = data[0];
                var age = int.Parse(data[1]);
                var town = data[2];

                var person = new Person(name, age, town);

                people.Add(person);
            }

            var index = int.Parse(Console.ReadLine());

            var personToLookFor = people[index - 1];

            var count = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToLookFor) == 0)
                {
                    count++;
                }
            }

            if (count == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                var noMatchCount = people.Count - count;
                Console.WriteLine($"{count} {noMatchCount} {people.Count}");
            }
        }
    }
}
