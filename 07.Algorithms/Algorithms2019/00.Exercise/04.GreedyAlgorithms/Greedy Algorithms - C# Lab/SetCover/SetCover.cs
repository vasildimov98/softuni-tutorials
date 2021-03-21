namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetCover
    {
        public static void Main()
        {
            var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            var sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            var list = new List<int[]>();

            var setToHashSet = new HashSet<int[]>(sets);
            var universeToHashSet = new HashSet<int>(universe);
            while (universe.Count > 0 && sets.Count > 0)
            {
                var currGreedySet = setToHashSet
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .First();

                setToHashSet.Remove(currGreedySet);

                foreach (var number in currGreedySet)
                    universe.Remove(number);

                list.Add(currGreedySet);
            }

            return list;
        }
    }
}
