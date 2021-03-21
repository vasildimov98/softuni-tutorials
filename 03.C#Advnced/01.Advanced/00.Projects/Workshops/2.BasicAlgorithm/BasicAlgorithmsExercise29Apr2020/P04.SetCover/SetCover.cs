using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        int[] universe = new[] { 1, 2, 3, 4, 5 };
        int[][] sets = new[]
        {
                new[] { 1 },
                new[] { 2, 4, },
                new[] { 5 },
                new[] { 3 }
            };

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (int[] set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        var possibleSets = new List<int[]>();

        while (universe.Count > 0)
        {
            var maxSet = sets
                .OrderByDescending(set => set
                .Count(universe.Contains))
                .First();
                
            foreach (var number in maxSet)
            {
                universe.Remove(number);
            }

            possibleSets.Add(maxSet);
            sets.Remove(maxSet);
        }
        return possibleSets;
    }
}
