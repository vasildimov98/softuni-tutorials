using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console
                .ReadLine()
                .Split()
                .ToList();

            string command = "";

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] allCommands = command.Split();

                string action = allCommands[0];

                if (action == "Delete")
                {
                    int index = int.Parse(allCommands[1]);

                    if (index >= -1 && index < words.Count - 1)
                    {
                        words.RemoveAt(index + 1);
                    }
                }
                else if (action == "Swap")
                {
                    string word1 = allCommands[1];
                    string word2 = allCommands[2];

                    if (words.Contains(word1) && words.Contains(word2))
                    {
                        int index1 = words.IndexOf(word1);
                        int index2 = words.IndexOf(word2);

                        words[index1] = word2;
                        words[index2] = word1;
                    }
                }
                else if (action == "Put")
                {
                    string word = allCommands[1];
                    int index = int.Parse(allCommands[2]);

                    if (index > 0 && index <= words.Count + 1)
                    {
                        words.Insert(index - 1, word);
                    }
                }
                else if (action == "Sort")
                {
                    words.Sort();
                    words.Reverse();
                }
                else if (action == "Replace")
                {
                    string word1 = allCommands[1];
                    string word2 = allCommands[2];

                    if (words.Contains(word2))
                    {
                        int index2 = words.IndexOf(word2);

                        words[index2] = word1;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
