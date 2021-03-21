using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console
                 .ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            int sum = 0;

            sum = SumOfRemovedElements(list, sum);

            Console.WriteLine(sum);
        }

        private static int SumOfRemovedElements(List<int> list, int sum)
        {
            while (list.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removed = 0;
                if (index < 0)
                {
                    removed = list[0];
                    sum += list[0];
                    list[0] = list[list.Count - 1];

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= removed)
                        {
                            list[i] += removed;
                        }
                        else if (list[i] > removed)
                        {
                            list[i] -= removed;
                        }
                    }
                }
                else if (index >= 0 && index < list.Count)
                {
                    removed = list[index];
                    sum += list[index];
                    list.RemoveAt(index);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= removed)
                        {
                            list[i] += removed;
                        }
                        else if (list[i] > removed)
                        {
                            list[i] -= removed;
                        }
                    }
                }
                else
                {
                    removed = list[list.Count - 1];
                    sum += list[list.Count - 1];
                    list[list.Count - 1] = list[0];

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= removed)
                        {
                            list[i] += removed;
                        }
                        else if (list[i] > removed)
                        {
                            list[i] -= removed;
                        }
                    }
                }
            }

            return sum;
        }
    }
}