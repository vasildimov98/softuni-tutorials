namespace P01.Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            const int DATURA_VALUE = 40;
            const int CHERRY_VALUE = 60;
            const int SMOKE_VALUE = 120;

            var countOfDaturaBomb = 0;
            var countOfCherryBomb = 0;
            var countOfSmokeBomb = 0;

            var bombEffect = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var effect = new Queue<int>(bombEffect);

            var bombCasing = Console
              .ReadLine()
              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            var casing = new Stack<int>(bombCasing);

            while (effect.Any() && casing.Any())
            {
                var currEffect = effect.Peek();
                var currCasing = casing.Pop();

                var value = currEffect + currCasing;

                if (value == DATURA_VALUE)
                {
                    countOfDaturaBomb++;
                    effect.Dequeue();
                }
                else if (value == CHERRY_VALUE)
                {
                    countOfCherryBomb++;
                    effect.Dequeue();
                }
                else if (value == SMOKE_VALUE)
                {
                    countOfSmokeBomb++;
                    effect.Dequeue();
                }
                else
                {
                    casing.Push(currCasing - 5);
                }

                if (countOfDaturaBomb >= 3 && countOfCherryBomb >= 3 && countOfSmokeBomb >= 3)
                {
                    break;
                }
            }

            if (countOfDaturaBomb >= 3 && countOfCherryBomb >= 3 && countOfSmokeBomb >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            var effectsLeft = effect.Count > 0 ?
                string.Join(", ", effect) :
                "empty";

            Console.WriteLine($"Bomb Effects: {effectsLeft}");

            var casingLeft = casing.Count > 0 ?
               string.Join(", ", casing) :
               "empty";

            Console.WriteLine($"Bomb Casings: {casingLeft}");

            Console.WriteLine($"Cherry Bombs: {countOfCherryBomb}");
            Console.WriteLine($"Datura Bombs: {countOfDaturaBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {countOfSmokeBomb}");
        }
    }
}
