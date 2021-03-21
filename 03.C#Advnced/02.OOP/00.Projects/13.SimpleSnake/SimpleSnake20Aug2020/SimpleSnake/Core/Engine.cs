namespace SimpleSnake.Core
{
    using System;
    using System.Threading;

    using Enums;
    using Contracts;
    using GameObjects.Points;
    using GameObjects.Points.Contracts;

    public class Engine : IEngine
    {
        private const string PLAYER_POINTS = "Player points:";
        private const string PLAYER_LEVEL = "Player level:";
        private const string WOULD_YOU_LIKE_TO_CONTINIUE_QUESTION
            = "Would you like to continue? y/n";
        private const string GAME_OVER_MASSAGE
             = "Game over!";
        private const int NUM_OF_POSSIBLE_DIRECTIONS = 4;
        private const int HUNDRED_MILLISECONDS = 100;

        private int oldPoints;
        private double sleepTime;

        private readonly Wall wall;
        private readonly Snake snake;

        private Direction direction;
        private readonly IPoint[] pointsOfDirections;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;

            this.direction = new Direction();
            this.pointsOfDirections = new IPoint[NUM_OF_POSSIBLE_DIRECTIONS];

            this.sleepTime = HUNDRED_MILLISECONDS;

            this.ShowStatistics();
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                var currIndexOfDirection = (int)this.direction;

                var isMoving = this.snake
                    .IsMoving(this.pointsOfDirections[currIndexOfDirection]);

                if (this.snake.Points > this.oldPoints)
                {
                    this.ShowStatistics();
                    this.oldPoints = this.snake.Points;
                }

                if (!isMoving)
                {
                    this.AskUserForRestart();
                }

                this.sleepTime -= 0.01;

                Thread.Sleep((int)this.sleepTime);
            }
        }

        private void ShowStatistics()
        {
            var leftX = this.wall.LeftX + 1;
            var topY = 0;

            Console.SetCursorPosition(leftX, topY);
            Console.Write($"{PLAYER_POINTS} {this.snake.Points}");
            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write($"{PLAYER_LEVEL} {this.snake.Level}");
        }

        private void AskUserForRestart()
        {
            var leftX = this.wall.LeftX + 1;
            var topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write(WOULD_YOU_LIKE_TO_CONTINIUE_QUESTION);

            var input = Console.ReadLine();

            var positiveAnswer = "y";
            if (input == positiveAnswer)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            var leftX = 10;
            var topY = 10;

            Console.SetCursorPosition(leftX, topY);
            Console.Write(GAME_OVER_MASSAGE);

            Environment.Exit(0);
        }

        private void GetNextDirection()
        {
            var userInput = Console.ReadKey();

            this.ChangeDirections(userInput);

            Console.CursorVisible = false;
        }

        private void ChangeDirections(ConsoleKeyInfo userInput)
        {
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right
                    && this.direction != Direction.Left)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left
                    && this.direction != Direction.Right)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow
                && this.direction != Direction.Up)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow
                && this.direction != Direction.Down)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }
        }

        private void CreateDirections()
        {
            //right
            this.pointsOfDirections[0] = new Point(1, 0);

            //left
            this.pointsOfDirections[1] = new Point(-1, 0);

            //down
            this.pointsOfDirections[2] = new Point(0, 1);

            //up
            this.pointsOfDirections[3] = new Point(0, -1);
        }
    }
}
