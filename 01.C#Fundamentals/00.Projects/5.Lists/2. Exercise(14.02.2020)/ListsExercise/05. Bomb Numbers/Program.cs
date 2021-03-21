using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
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

            List<int> commands = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int number = commands[0];
            int power = commands[1];
            
            GetNewList(list, number, power);
            list = list.Where(x =>x != number).ToList();
            Console.WriteLine(list.Sum());
        }

        static void GetNewList(List<int> list, int number, int power)
        {
            int lastIndex = list.Count - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                if (list[i] == number)
                {
                    int removeIndex = i - power;
                    int stopPoint = i + power;
                    if (i == 0)
                    {
                        stopPoint = power;
                        i--;
                    }

                    if (stopPoint > list.Count -1)
                    {
                        stopPoint = list.Count - 1;
                    }

                    if (removeIndex < 0)
                    {
                        removeIndex = 0;
                    }
                    for (int index = removeIndex; index <= stopPoint; index++)
                    {
                        list.RemoveAt(removeIndex);
                        lastIndex--;
                    }
                }
            }
        }
    }
}
