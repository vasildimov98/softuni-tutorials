namespace P02.ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<Task> tasks;
        private static readonly HashSet<Task> optionalTask = new HashSet<Task>();
        static void Main()
        {
            ReadTasks();

            SolveSalution();
        }

        private static void SolveSalution()
        {
            var totalValue = 0;

            var longestDeadLine = tasks
                .OrderByDescending(t => t.DeadLine)
                .First().DeadLine;

            var currIndex = 0;
            while (longestDeadLine != 0)
            {
                var currHighestValueTask = tasks[currIndex++];
                longestDeadLine--;

                optionalTask.Add(currHighestValueTask);
                totalValue += currHighestValueTask.Value;
            }

            PrintResult(totalValue);
        }

        private static void PrintResult(int totalValue)
        {
            var printResult = optionalTask
                .OrderBy(t => t.DeadLine)
                .ThenByDescending(t => t.Value)
                .Select(t => t.Number);

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", printResult)}");
            Console.WriteLine($"Total value: {totalValue}");
        }

        private static void ReadTasks()
        {
            var totalTask = int
                .Parse(
                    Console
                    .ReadLine()
                    .Split()[1]);

            tasks = new List<Task>();

            for (int i = 0; i < totalTask; i++)
            {
                var taskArgs = Console
                    .ReadLine()
                    .Split()
                    .ToArray();

                tasks.Add(new Task
                {
                    Number = i + 1,
                    Value = int.Parse(taskArgs[0]),
                    DeadLine = int.Parse(taskArgs[2])
                });
            }

            tasks = tasks
                .OrderByDescending(t => t.Value)
                .ToList();
        }
    }

    internal class Task
    {
        public int Number { get; set; }
        public int Value { get; set; }
        public int DeadLine { get; set; }
    }
}
