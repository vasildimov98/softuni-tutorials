using System;
using System.Linq;

namespace _2._Tasks_Planner
{
    class Program
    {
        static void Main()
        {
            int[] timeOfEachTask = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] allCommands = command.Split();

                string action = allCommands[0];

                if (action == "Complete")
                {
                    CompleteTask(timeOfEachTask, allCommands);
                }
                else if (action == "Change")
                {
                    ChangeTime(timeOfEachTask, allCommands);
                }
                else if (action == "Drop")
                {
                    DropTask(timeOfEachTask, allCommands);
                }
                else if (action == "Count")
                {
                    CountTask(timeOfEachTask, allCommands);
                }
            }

            timeOfEachTask = timeOfEachTask.Where(a => a > 0).ToArray();

            Console.WriteLine(string.Join(" ", timeOfEachTask));
        }

        private static void CountTask(int[] timeOfEachTask, string[] allCommands)
        {
            string what = allCommands[1];
            if (what == "Completed")
            {
                int[] countOfComplete = timeOfEachTask.Where(a => a == 0).ToArray();

                Console.WriteLine(countOfComplete.Length);
            }
            else if (what == "Incomplete")
            {
                int[] countOfIncomplete = timeOfEachTask.Where(a => a > 0).ToArray();

                Console.WriteLine(countOfIncomplete.Length);
            }
            else if (what == "Dropped")
            {
                int[] countOfDropped = timeOfEachTask.Where(a => a < 0).ToArray();

                Console.WriteLine(countOfDropped.Length);
            }
        }

        private static void DropTask(int[] timeOfEachTask, string[] allCommands)
        {
            int index = int.Parse(allCommands[1]);
            if (index >= 0 && index < timeOfEachTask.Length)
            {
                timeOfEachTask[index] = -1;
            }
        }

        private static void ChangeTime(int[] timeOfEachTask, string[] allCommands)
        {
            int index = int.Parse(allCommands[1]);
            int time = int.Parse(allCommands[2]);

            if (index >= 0 && index < timeOfEachTask.Length)
            {
                timeOfEachTask[index] = time;
            }
        }

        private static void CompleteTask(int[] timeOfEachTask, string[] allCommands)
        {
            int index = int.Parse(allCommands[1]);

            if (index >= 0 && index < timeOfEachTask.Length)
            {
                timeOfEachTask[index] = 0;
            }
        }
    }
}
