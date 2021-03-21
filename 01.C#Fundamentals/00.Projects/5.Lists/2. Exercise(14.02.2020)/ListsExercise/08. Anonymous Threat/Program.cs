using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console
                .ReadLine()
                .Split()
                .ToList();

            string commands = "";
            while ((commands = Console.ReadLine()) != "3:1")
            {

                List<string> allCommands = commands
                    .Split()
                    .ToList();

                string command = allCommands[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(allCommands[1]);
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex >= list.Count)
                    {
                        startIndex = 0;
                    }

                    int endIndex = int.Parse(allCommands[2]);
                    if (endIndex > list.Count - 1 || endIndex < 0)
                    {
                        endIndex = list.Count - 1;
                    }

                    string result = list[startIndex];
                    for (int i = startIndex + 1; i <= endIndex; i++)
                    {
                        result += list[i];
                    }

                    list[startIndex] = result;

                    for (int i = startIndex + 1; i <= endIndex; i++)
                    {
                        list.RemoveAt(startIndex + 1);
                    }

                    //Console.WriteLine(string.Join(" ", list));
                }
                else if (command == "divide")
                {
                    List<string> tempList = new List<string>();
                    int index = int.Parse(allCommands[1]);
                    int partition = int.Parse(allCommands[2]);
                    string word = list[index];

                    int parts = word.Length / partition;
                    list.RemoveAt(index);

                    for (int i = 0; i < partition; i++)
                    {
                        if (i == partition - 1)
                        {
                            tempList.Add(word.Substring(i * parts));
                        }
                        else
                        {
                            tempList.Add(word.Substring(i * parts, parts));
                        }
                    }
                    list.InsertRange(index, tempList);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
