namespace P03.Knight_sTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int currTourMove = 1;

        private static int[][] chessboard;
        private static Point currPoint = new Point(0, 0);

        static void Main()
        {
            ReadInput();
            SolveKnightTour();
            PrintChessboard();
        }

        private static void PrintChessboard()
        {
            foreach (var row in chessboard)
                Console.WriteLine(string.Join(" ", row.Select(r => r.ToString().PadLeft(3))));
        }

        private static void SolveKnightTour()
        {
            var currCandidates = FindPotentialMoves(currPoint);
            chessboard[currPoint.Row][currPoint.Col] = currTourMove++;


            while (currCandidates.Count != 0)
            {
                var minNextMoves = int.MaxValue;
                Point bestCanditate = null;

                foreach (var canditate in currCandidates)
                {
                    var currCandidateMoves = FindPotentialMoves(canditate).Count;

                    if (currCandidateMoves < minNextMoves)
                    {
                        minNextMoves = currCandidateMoves;
                        bestCanditate = canditate;
                    }
                }

                currPoint = bestCanditate;
                chessboard[currPoint.Row][currPoint.Col] = currTourMove++;
                currCandidates = FindPotentialMoves(currPoint);
            }
        }

        private static List<Point> FindPotentialMoves(Point point)
        {
            var potentialMoves = new List<Point>
            {
                new Point(point.Row + 1, point.Col + 2),
                new Point(point.Row - 1, point.Col + 2),
                new Point(point.Row + 1, point.Col - 2),
                new Point(point.Row - 1, point.Col - 2),
                new Point(point.Row + 2, point.Col + 1),
                new Point(point.Row + 2, point.Col - 1),
                new Point(point.Row - 2, point.Col + 1),
                new Point(point.Row - 2, point.Col - 1)
            };

            return potentialMoves
                .Where(p => IsInsideBorder(p)
                && chessboard[p.Row][p.Col] == 0)
                .ToList();
        }

        private static bool IsInsideBorder(Point p)
        {
            return p.Row >= 0
                && p.Row < chessboard.Length
                && p.Col >= 0
                && p.Col < chessboard[p.Row].Length;
        }

        private static void ReadInput()
        {
            var boardSize = int.Parse(Console.ReadLine());
            chessboard = new int[boardSize][];

            for (int i = 0; i < boardSize; i++)
                chessboard[i] = new int[boardSize];
        }
    }

    internal class Point
    {
        public Point(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; }
        public int Col { get; }
    }
}
