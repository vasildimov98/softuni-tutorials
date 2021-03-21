namespace P13.Snake
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static char[] snake;

        private static readonly HashSet<string> visited = new HashSet<string>();
        private static readonly HashSet<string> marked = new HashSet<string>();
        private static readonly HashSet<string> equalSnakes = new HashSet<string>();
        
        static void Main()
        {
            var slots = int.Parse(Console.ReadLine());
            snake = new char[slots];

            var startRow = 0;
            var startCol = 0;
            var currSnakeIndex = 0;
            GenerateAllPossibleWays(startRow, startCol, currSnakeIndex, 'S');

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(Environment.NewLine, marked));
            Console.WriteLine($"Snakes count = {marked.Count}");
        }

        private static void GenerateAllPossibleWays(int currRow,
            int currCol,
            int currSnakeIndex,
            char direction)
        {
            if (currSnakeIndex == snake.Length)
            {
                MarkedAllEqualSnake();
                return;
            }

            var position = $"{currRow}{currCol}";

            if (visited.Contains(position)) return;

            visited.Add(position);

            snake[currSnakeIndex] = direction;

            GenerateAllPossibleWays(currRow, currCol + 1, currSnakeIndex + 1, 'R');
            GenerateAllPossibleWays(currRow + 1, currCol, currSnakeIndex + 1, 'D');
            GenerateAllPossibleWays(currRow, currCol - 1, currSnakeIndex + 1, 'L');
            GenerateAllPossibleWays(currRow - 1, currCol, currSnakeIndex + 1, 'U'); 

            visited.Remove(position);
        }

        private static void MarkedAllEqualSnake()
        {
            var currSnake = new string(snake);
            if (equalSnakes.Contains(currSnake)) return;

            marked.Add(currSnake);

            var reverseSnake = ReverseSnake(currSnake);
            var flippedSnake = FlippedSnake(currSnake);
            var reverseFlippedSnake = ReverseSnake(flippedSnake);

            for (int i = 0; i < 4; i++)
            {
                equalSnakes.Add(currSnake);
                currSnake = RotateSnake(currSnake);

                equalSnakes.Add(reverseSnake);
                reverseSnake = RotateSnake(reverseSnake);

                equalSnakes.Add(flippedSnake);
                flippedSnake = RotateSnake(flippedSnake);

                equalSnakes.Add(reverseFlippedSnake);
                reverseFlippedSnake = RotateSnake(reverseFlippedSnake);
            }
        }

        private static string ReverseSnake(string currSnake)
        {
            var newSnake = new char[currSnake.Length];

            newSnake[0] = 'S';

            for (int i = 1; i < currSnake.Length; i++)
                newSnake[i] = currSnake[currSnake.Length - i];

            return new string(newSnake);
        }

        private static string FlippedSnake(string currSnake)
        {
            var newSnake = new char[currSnake.Length];

            for (int i = 0; i < currSnake.Length; i++)
            {
                switch (currSnake[i])
                {
                    case 'D':
                        newSnake[i] = 'U';
                        break;
                    case 'U':
                        newSnake[i] = 'D';
                        break;
                    default:
                        newSnake[i] = currSnake[i];
                        break;
                }
            }

            return new string(newSnake);
        }

        private static string RotateSnake(string currSnake)
        {
            var newSnake = new char[currSnake.Length];

            for (int i = 0; i < currSnake.Length; i++)
            {
                switch (currSnake[i])
                {
                    case 'R':
                        newSnake[i] = 'D';
                        break;
                    case 'D':
                        newSnake[i] = 'L';
                        break;
                    case 'L':
                        newSnake[i] = 'U';
                        break;
                    case 'U':
                        newSnake[i] = 'R';
                        break;
                    default:
                        newSnake[i] = currSnake[i];
                        break;
                }
            }

            return new string(newSnake);
        }
    }
}
