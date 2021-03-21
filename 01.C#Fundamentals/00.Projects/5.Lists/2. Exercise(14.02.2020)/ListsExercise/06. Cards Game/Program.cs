using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> deck1 = Console
             .ReadLine()
             .Split()
             .Select(int.Parse)
             .ToList();

        List<int> deck2 = Console
             .ReadLine()
             .Split()
             .Select(int.Parse)
             .ToList();

        GetWinningDeck(deck1, deck2);

        if (deck1.Count > 0)
        {
            int sum = deck1.Sum();
            Console.WriteLine($"First player wins! Sum: {sum}");
        }
        else
        {
            int sum = deck2.Sum();
            Console.WriteLine($"Second player wins! Sum: {sum}");
        }
    }

    static void GetWinningDeck(List<int> deck1, List<int> deck2)
    {
        while (deck1.Count > 0 && deck2.Count > 0)
        {
            int card1 = deck1[0];
            int card2 = deck2[0];
            int max = Math.Max(card1, card2);
            if (card1 == card2)
            {
                deck1.RemoveAt(0);
                deck2.RemoveAt(0);
            }
            else if (max == card1)
            {
                deck1.Add(card1);
                deck1.Add(card2);
                deck1.RemoveAt(0);
                deck2.RemoveAt(0);
            }
            else
            {
                deck2.Add(card2);
                deck2.Add(card1);
                deck2.RemoveAt(0);
                deck1.RemoveAt(0);
            }
        }
    }
}