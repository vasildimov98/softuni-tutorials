using System;
using System.Collections;
using System.Collections.Generic;

namespace _07._Distance_in_Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] lab = new string[n, n];
            lab = GetStringArr(n);

            bool[,] visited = new bool[lab.GetLength(0), lab.GetLength(1)];
            int row = 0;
            int col = 0;
            GetStart(n, lab, ref row, ref col);

            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(new Cell(row, col, 0));

            while (queue.Count != 0)
            {
                Cell current = queue.Dequeue();
                row = current.Row;
                col = current.Col;
                visited[row, col] = true;

                if (lab[row, col] != "*")
                {
                    lab[row, col] = current.Moves.ToString();
                }
                //up
                if (row - 1 >= 0 && lab[row - 1, col] != "x" && !visited[row - 1, col])
                {
                    queue.Enqueue(new Cell(row - 1, col, current.Moves + 1));
                }

                //right
                if (col + 1 < lab.GetLength(1) && lab[row, col + 1] != "x" && !visited[row, col + 1])
                {
                    queue.Enqueue(new Cell(row, col + 1, current.Moves + 1));
                }

                //down
                if (row + 1 < lab.GetLength(0) && lab[row + 1, col] != "x" && !visited[row + 1, col])
                {
                    queue.Enqueue(new Cell(row + 1, col, current.Moves + 1));
                }

                //left
                if (col - 1 >= 0 && lab[row, col - 1] != "x" && !visited[row, col - 1])
                {
                    queue.Enqueue(new Cell(row, col - 1, current.Moves + 1));
                }
            }

            PrintLab(lab, n);
        }

        private static string[,] GetStringArr(int n)
        {
            string[,] lab = new string[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] arr = Console
                      .ReadLine()
                      .ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    lab[i, j] = arr[j].ToString();
                }
            }
            return lab;
        }

        private static void PrintLab(string[,] lab, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (lab[i, j] == "0")
                    {
                        Console.Write("u");
                    }
                    else
                    {
                        Console.Write(lab[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void GetStart(int n, string[,] lab, ref int row, ref int col)
        {
            bool found = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (lab[i, j] == "*")
                    {
                        row = i;
                        col = j;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }
        }
    }
    class Cell
    {
        public Cell(int row, int col, int moves)
        {
            Row = row;
            Col = col;
            Moves = moves;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Moves { get; set; }
    }
}
