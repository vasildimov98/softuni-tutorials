using System;
using System.Linq;

namespace _02._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console
                .ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = "";
            int points = 0;
            while ((command = Console.ReadLine()) != "Game over")
            {
                string[] data = command.Split(" ");

                if (data[0] == "Shoot")
                {
                    string[] data1 = data[1].Split("@");

                    int index = int.Parse(data1[1]);
                    int length = int.Parse(data1[2]);

                    length %= targets.Length;

                    if (index >= 0 && index < targets.Length)
                    {
                        if (data1[0] == "Left")
                        {
                            index -= length;

                            if (index < 0)
                            {
                                index = targets.Length + index;
                            }


                            if (targets[index] >= 5)
                            {
                                points += 5;
                                targets[index] -= 5;
                            }
                            else if (targets[index] > 0)
                            {
                                points += targets[index];
                                targets[index] = 0;
                            }
                        }
                        else if (data1[0] == "Right")
                        {
                            index += length;

                            if (index > targets.Length)
                            {
                                index = 0 + (index - targets.Length);
                            }

                            if (targets[index] >= 5)
                            {
                                points += 5;
                                targets[index] -= 5;
                            }
                            else if (targets[index] > 0)
                            {
                                points += targets[index];
                                targets[index] = 0;
                            }
                        }
                       
                    }
                }
                else if (data[0] == "Reverse")
                {
                    targets = targets.Reverse().ToArray();
                }
            }

            Console.WriteLine($"{string.Join(" - ", targets)}");

            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
