namespace P08.SetCover
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            var universe = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var setsCount = int.Parse(Console.ReadLine());
            var sets = new List<int[]>();
            for (int i = 0; i < setsCount; i++)
            {
                var set = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                sets.Add(set);
            }

            var selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                var currentSet = sets
                    .OrderByDescending(s => s
                        .Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(currentSet);
                sets.Remove(currentSet);
                universe
                    .RemoveAll(e => currentSet.Contains(e));
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}
