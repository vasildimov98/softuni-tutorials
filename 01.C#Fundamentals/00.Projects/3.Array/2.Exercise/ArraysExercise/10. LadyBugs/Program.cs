using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] indexes = Console
            .ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
            int[] arr = new int[fieldSize];

            GetIntialField(fieldSize, indexes, arr);

            //Console.WriteLine(string.Join(" ", arr));

            PrintAfterEnd(arr);
        }

        private static void PrintAfterEnd(int[] arr)
        {
            while (true)
            {
                string[] command = Console
                    .ReadLine()
                    .Split();

                if (command[0] == "end")
                {
                    Console.WriteLine(string.Join(" ", arr));
                    return;
                }

                int ladybugIndex = int.Parse(command[0]);

                if (ladybugIndex >= arr.Length || ladybugIndex < 0)
                {
                    continue;
                }

                string direction = command[1];
                int flyLength = int.Parse(command[2]);

                if (flyLength == 0)
                {
                    continue;
                }


                if (flyLength < 0 && direction == "left")
                {
                    flyLength = Math.Abs(flyLength);
                    direction = "right";
                }
                else if (flyLength < 0 && direction == "right")
                {
                    flyLength = Math.Abs(flyLength);
                    direction = "left";
                }

                if (direction == "right")
                {
                    GetNewRightArr(arr, ladybugIndex, flyLength);
                    //Console.WriteLine(string.Join(" ", arr));
                }
                else if (direction == "left")
                {
                    GetNewLeftArr(arr, ladybugIndex, flyLength);
                    //Console.WriteLine(string.Join(" ", arr));
                }
            }
        }

        static void GetNewRightArr(int[] arr, int ladybugIndex, int flyLength)
        {
            if (flyLength > arr.Length - ladybugIndex - 1)
            {
                arr[ladybugIndex] = 0;
            }
            else if (arr[ladybugIndex] == 1)
            {
                for (int nextIndx = ladybugIndex + flyLength; nextIndx < arr.Length + flyLength; nextIndx += flyLength)
                {

                    if (nextIndx >= arr.Length)
                    {
                        arr[ladybugIndex] = 0;
                        break;
                    }
                    else if (arr[nextIndx] == 0)
                    {
                        arr[nextIndx] = 1;
                        arr[ladybugIndex] = 0;
                        break;
                    }
                }
            }
        }

        static void GetNewLeftArr(int[] arr, int ladybugIndex, int flyLength)
        {
            if (flyLength > ladybugIndex)
            {
                arr[ladybugIndex] = 0;
            }
            else if (arr[ladybugIndex] == 1)
            {
                for (int privIndx = ladybugIndex - flyLength; privIndx >= -flyLength; privIndx -= flyLength)
                {
                    if (privIndx <= -1)
                    {
                        arr[ladybugIndex] = 0;
                        break;
                    }
                    else if (arr[privIndx] == 0)
                    {
                        arr[privIndx] = 1;
                        arr[ladybugIndex] = 0;
                        break;
                    }
                }

            }
        }

        static void GetIntialField(int fieldSize, int[] indexes, int[] arr)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                int curr = indexes[i];
                for (int j = 0; j < fieldSize; j++)
                {
                    if (curr == j)
                    {
                        arr[j] = 1;
                        break;
                    }
                }
            }
        }
    }
}
