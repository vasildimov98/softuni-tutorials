using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var songs = new Queue<string>();
            FillQueue(songs, input);

            while (songs.Count != 0)
            {
                var data = Console
                    .ReadLine()
                    .Split(" ", 2)
                    .ToArray();

                if (data[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (data[0] == "Add")
                {
                    if (!songs.Contains(data[1]))
                    {
                        songs.Enqueue(data[1]);
                    }
                    else
                    {
                        Console.WriteLine($"{data[1]} is already contained!");
                    }
                }
                else if (data[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }

        private static void FillQueue(Queue<string> queue, string[] input)
        {
            foreach (var song in input)
            {
                queue.Enqueue(song);
            }
        }
    }
}
