namespace P06.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        private static string[] names;
        private static bool[] locked;
        static void Main()
        {
            var people = Console
                .ReadLine()
                .Split(", ")
                .ToList();
            names = new string[people.Count];
            locked = new bool[people.Count];

            string input;
            while ((input = Console.ReadLine()) != "generate")
            {
                var lockedPosition = input.Split(" - ");
                var person = lockedPosition[0];
                var position = int.Parse(lockedPosition[1]) - 1;

                names[position] = person;
                locked[position] = true;
                people.Remove(person);
            }

            Permute(people);
        }

        private static void Permute(List<string> people, int currPerson = 0)
        {
            if (currPerson == people.Count)
            {
                var count = 0;
                for (int i = 0; i < names.Length; i++)
                {
                    if (locked[i]) continue;

                    names[i] = people[count++];
                }

                Console.WriteLine(string.Join(" ", names));
                return;
            }

            Permute(people, currPerson + 1);

            for (int personIndex = currPerson + 1; personIndex < people.Count; personIndex++)
            {
                Swap(people, currPerson, personIndex);
                Permute(people, currPerson + 1);
                Swap(people, currPerson, personIndex);
            }
        }

        private static void Swap(List<string> list, int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
