namespace P05.EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            AddPeople(numberOfPeople, people);

            var peopleHashSet = new HashSet<Person>(people);
            var peopleSortedSet = new SortedSet<Person>(people);

            Print(peopleHashSet.Count, peopleSortedSet.Count);
        }

        private static void Print(int peopleHashSetCount, int peopleSortedSetCount)
        {
            Console.WriteLine(peopleHashSetCount);
            Console.WriteLine(peopleSortedSetCount);
        }

        private static void AddPeople(int n, List<Person> list)
        {
            for (int i = 0; i < n; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = args[0];
                var age = int.Parse(args[1]);

                var person = new Person(name, age);

                list.Add(person);
            }
        }
    }
}
