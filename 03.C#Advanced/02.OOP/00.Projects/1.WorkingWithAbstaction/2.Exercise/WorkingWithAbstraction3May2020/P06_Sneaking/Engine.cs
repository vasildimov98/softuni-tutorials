using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_Sneaking
{
    public class Engine
    {
        private char[][] matrix;

        private int samRow;
        private int samCol;

        private int nikoladzeRow;
        private int nikoladzeCol;

        private Queue<int> enemiesRowAndCols;

        public Engine()
        {
            this.enemiesRowAndCols = new Queue<int>();
        }
        public void RunStartUp()
        {
            var rows = int.Parse(Console.ReadLine());

            matrix = new char[rows][];
            this.FillMatrix();

            var direction = Console.ReadLine();

            var samIsDead = false;
            var nikoladzeisDead = false;

            foreach (var move in direction)
            {
                samIsDead = TraverseEnemyRowCol();

                if (samIsDead || nikoladzeisDead)
                {
                    break;
                }

                var tempSamRow = samRow;
                var tempSamCol = samCol;
                switch (move)
                {
                    case 'U':
                        tempSamRow--;
                        break;
                    case 'D':
                        tempSamRow++;
                        break;
                    case 'L':
                        tempSamCol--;
                        break;
                    case 'R':
                        tempSamCol++;
                        break;
                    default:
                        continue;
                }

                var currentPosition = matrix[this.samRow][this.samCol];

                if (tempSamRow != nikoladzeRow)
                {
                    samIsDead = this.CheckIfSamIsDead(samIsDead, this.samRow, this.samCol);
                }
                else if (tempSamRow == nikoladzeRow)
                {
                    nikoladzeisDead = this.KillNikoladze();
                }

                if (samIsDead)
                {
                    break;
                }

                ChangePositionOfSam(tempSamRow, tempSamCol);

                if (nikoladzeisDead)
                {
                    break;
                }
            }

            PrintResult(samIsDead, nikoladzeisDead);
        }

        private void ChangePositionOfSam(int tempSamRow, int tempSamCol)
        {
            this.matrix[this.samRow][this.samCol] = '.';
            this.matrix[tempSamRow][tempSamCol] = 'S';
            samRow = tempSamRow;
            this.samCol = tempSamCol;
        }

        private bool KillNikoladze()
        {
            bool nikoladzeisDead;
            matrix[nikoladzeRow][nikoladzeCol] = 'X';
            nikoladzeisDead = true;
            return nikoladzeisDead;
        }

        private bool CheckIfSamIsDead(bool samIsDead, int row, int col)
        {
            var count = this.enemiesRowAndCols.Count;

            for (int i = 0; i < count; i += 2)
            {
                var currEnemyRow = this.enemiesRowAndCols.Dequeue();
                var currEnemyCol = this.enemiesRowAndCols.Dequeue();

                if (currEnemyRow == row)
                {
                    var symbol = this.matrix[currEnemyRow][currEnemyCol];

                    if (symbol == 'd' && currEnemyCol > col)
                    {
                        this.matrix[row][col] = 'X';
                        samIsDead = true;
                    }
                    else if (symbol == 'b' && currEnemyCol < col)
                    {
                        this.matrix[row][col] = 'X';
                        samIsDead = true;
                    }
                }

                this.enemiesRowAndCols.Enqueue(currEnemyRow);
                this.enemiesRowAndCols.Enqueue(currEnemyCol);
            }

            return samIsDead;
        }

        private void PrintResult(bool samIsDead, bool nikoladzeisDead)
        {
            if (samIsDead)
            {
                Console.WriteLine($"Sam died at {this.samRow}, {this.samCol}");
            }
            else if (nikoladzeisDead)
            {
                Console.WriteLine("Nikoladze killed!");
            }

            PrintMatrix();
        }

        private bool TraverseEnemyRowCol()
        {
            var enemyCount = this.enemiesRowAndCols.Count;
            for (int i = 0; i < enemyCount; i += 2)
            {
                var enemyRow = enemiesRowAndCols.Dequeue();
                var enemyCol = enemiesRowAndCols.Dequeue();

                var tempRow = enemyRow;
                var tempCol = enemyCol;

                var symbol = matrix[tempRow][tempCol];
                if (symbol == 'd')
                {
                    if (LookForTheEdge(tempRow, tempCol - 1))
                    {
                        tempCol--;

                        MoveEnemy(enemyRow,
                        enemyCol,
                        tempRow,
                        tempCol,
                        symbol);
                    }
                    else
                    {
                        matrix[tempRow][tempCol] = 'b';
                    }

                    this.enemiesRowAndCols.Enqueue(tempRow);
                    this.enemiesRowAndCols.Enqueue(tempCol);
                }
                else if (symbol == 'b')
                {
                    if (LookForTheEdge(tempRow, tempCol + 1))
                    {
                        tempCol++;

                        MoveEnemy(enemyRow,
                        enemyCol,
                        tempRow,
                        tempCol,
                        symbol);
                    }
                    else if (tempCol == matrix[tempRow].Length - 1)
                    {
                        matrix[tempRow][tempCol] = 'd';
                    }

                    this.enemiesRowAndCols.Enqueue(tempRow);
                    this.enemiesRowAndCols.Enqueue(tempCol);
                }
            }

            return false;
        }

        private void MoveEnemy(int enemyRow,
            int enemyCol,
            int tempRow,
            int tempCol,
            char symbol)
        {
            matrix[enemyRow][enemyCol] = '.';
            matrix[tempRow][tempCol] = symbol;
        }

        private void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(matrix[row]);
            }
        }
        private void FillMatrix()
        {
            for (int row = 0; row < this.matrix.Length; row++)
            {
                var roomCol = Console
                        .ReadLine()
                        .ToCharArray();

                this.matrix[row] = roomCol;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        this.samRow = row;
                        this.samCol = col;
                    }
                    else if (matrix[row][col] == 'N')
                    {
                        this.nikoladzeRow = row;
                        this.nikoladzeCol = col;
                    }
                    else if (matrix[row][col] == 'b' || matrix[row][col] == 'd')
                    {
                        this.enemiesRowAndCols.Enqueue(row);
                        this.enemiesRowAndCols.Enqueue(col);
                    }
                }
            }
        }

        private bool LookForTheEdge(int row, int col)
        {
            if (col < 0 || col >= matrix[row].Length)
            {
                return false;
            }

            return true;
        }
    }
}
