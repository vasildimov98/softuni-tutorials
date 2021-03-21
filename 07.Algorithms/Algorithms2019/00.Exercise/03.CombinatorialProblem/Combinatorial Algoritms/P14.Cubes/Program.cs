namespace P14.Cubes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int countOfCubes = 1;
        private static string[] setOfColors;
        private static HashSet<string> rotations = new HashSet<string>();
        static void Main()
        {
            setOfColors = Console
                .ReadLine()
                .Split()
                .OrderBy(x => x)
                .ToArray();

            RotateCube();
            Permutate(0, setOfColors.Length - 1);

            Console.WriteLine(countOfCubes);
        }

        private static void RotateCube()
        {
            for (int z = 0; z < 4; z++)
            {
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        var currCube = string.Join(" ", setOfColors);
                        rotations.Add(currCube);

                        RotateX();
                    }

                    RotateY();
                }

                RotateZ();
            }
        }

        private static void RotateZ()
        {
            Swap(6, 9);
            Swap(7, 6);
            Swap(11, 7);

            Swap(5, 10);
            Swap(8, 5);
            Swap(3, 8);

            Swap(2, 4);
            Swap(1, 2);
            Swap(0, 1);
        }

        private static void RotateY()
        {
            Swap(3, 1);
            Swap(7, 3);
            Swap(8, 7);

            Swap(11, 0);
            Swap(6, 11);
            Swap(2, 6);

            Swap(10, 4);
            Swap(9, 10);
            Swap(5, 9);
        }

        private static void RotateX()
        {
            Swap(10, 0);
            Swap(11, 10);
            Swap(3, 11);

            Swap(9, 4);
            Swap(7, 9);
            Swap(1, 7);

            Swap(5, 2);
            Swap(6, 5);
            Swap(8, 6);
        }

        private static void Permutate(int startIndex, int endIndex)
        {
            PrintCurrPermute();
            for (int leftIndex = endIndex - 1; leftIndex >= startIndex; leftIndex--)
            {
                for (int rightIndex = leftIndex + 1; rightIndex <= endIndex; rightIndex++)
                    if (setOfColors[leftIndex] != setOfColors[rightIndex])
                    {
                        Swap(leftIndex, rightIndex);
                        Permutate(leftIndex + 1, endIndex);
                    }

                var firstElement = setOfColors[leftIndex];
                for (int i = leftIndex; i <= endIndex - 1; i++)
                    setOfColors[i] = setOfColors[i + 1];
                setOfColors[endIndex] = firstElement;
            }
        }

        private static void Swap(int leftIndex, int rightIndex)
        {
            var temp = setOfColors[leftIndex];
            setOfColors[leftIndex] = setOfColors[rightIndex];
            setOfColors[rightIndex] = temp;
        }

        private static void PrintCurrPermute()
        {
            var currCube = string.Join(" ", setOfColors);
            if (!rotations.Contains(currCube))
            {
                countOfCubes++;
                RotateCube();
            }
        }
    }
}
