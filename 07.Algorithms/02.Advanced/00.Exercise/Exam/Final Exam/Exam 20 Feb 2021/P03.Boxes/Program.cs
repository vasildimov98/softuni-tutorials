namespace P03.Boxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static (int Width, int Depth, int Height)[] sequence;
        private static int[] length;
        private static int[] previous;
        static void Main()
        {
            ReadInput();
            var lastIndex = FindLIS();
            var path = ReconstructPath(lastIndex);
            Console.WriteLine(string.Join(Environment.NewLine, path));
        }

        private static Stack<string> ReconstructPath(int lastIndex)
        {
            var output = new Stack<string>();

            while (lastIndex != -1)
            {
                var (Width, Depth, Height) = sequence[lastIndex];

                var pushValue = $"{Width} {Depth} {Height}";
                output.Push(pushValue);
                lastIndex = previous[lastIndex];
            }

            return output;
        }

        private static void ReadInput()
        {
            var boxes = int.Parse(Console.ReadLine());
            sequence = new (int Width, int Depth, int Height)[boxes];

            for (int i = 0; i < boxes; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                sequence[i] = (args[0], args[1], args[2]);
            }
        }

        private static int FindLIS()
        {
            length = new int[sequence.Length];
            previous = new int[sequence.Length];

            var maxLength = 0;
            var lastIndex = -1;
            for (int i = 0; i < sequence.Length; i++)
            {
                length[i] = 1;
                previous[i] = -1;

                var currentBox = sequence[i];
                for (int j = 0; j < i; j++)
                {
                    var previousBox = sequence[j];

                    if (PreviousBoxIsSmaller(previousBox, currentBox)
                        && length[j] + 1 > length[i])
                    {
                        length[i] = length[j] + 1;
                        previous[i] = j;
                    }
                }

                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    lastIndex = i;
                }
            }

            return lastIndex;
        }

        private static bool PreviousBoxIsSmaller((int Width, int Depth, int Height) pr,
            (int Width, int Depth, int Height) cr)
        {
            return pr.Width < cr.Width
                && pr.Depth < cr.Depth
                && pr.Height < cr.Height;
        }
    }
}
