namespace P06.Supermarket
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var queue = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    ClearQueue(queue);
                    continue;
                }

                queue.Enqueue(command);
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }

        private static void ClearQueue(Queue<string> queue)
        {

            foreach (var name in queue)
            {
                Console.WriteLine(name);
            }

            queue.Clear();

        }
    }
}
