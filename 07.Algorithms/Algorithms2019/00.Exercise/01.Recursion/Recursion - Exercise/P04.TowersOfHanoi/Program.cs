namespace P04.TowersOfHanoi
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        private const int ONE_DISK_LEFT = 1;

        private static int stepsTaken = 0;

        private static Stack<int> source;
        private readonly static Stack<int> destination = new Stack<int>();
        private readonly static Stack<int> spare = new Stack<int>();
        static void Main()
        {
            var numbersOfDisks = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, numbersOfDisks).Reverse());

            PrintPegs();
            SolveTheTowerOfHanoi(numbersOfDisks, source, destination, spare);
        }

        private static void SolveTheTowerOfHanoi(int numbersOfDisks,
            Stack<int> sourcePeg,
            Stack<int> destinationPeg,
            Stack<int> sparePeg)
        {
            if (numbersOfDisks == ONE_DISK_LEFT)
            {
                MoveDiskFromSourceToDestination(sourcePeg, destinationPeg);
                return;
            }

            SolveTheTowerOfHanoi(numbersOfDisks - 1, sourcePeg, sparePeg, destinationPeg);
            MoveDiskFromSourceToDestination(sourcePeg, destinationPeg);
            SolveTheTowerOfHanoi(numbersOfDisks - 1, sparePeg, destinationPeg, sourcePeg);
        }

        private static void MoveDiskFromSourceToDestination(Stack<int> sourcePeg, Stack<int> destinationPeg)
        {
            destinationPeg.Push(sourcePeg.Pop());
            Console.WriteLine($"Step #{++stepsTaken}: Moved disk");
            PrintPegs();
        }

        private static void PrintPegs()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");

            Console.WriteLine();
        }
    }
}
