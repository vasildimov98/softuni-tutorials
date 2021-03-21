using System;
using System.Linq;
using System.Text;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string codes = "";
            StringBuilder type = new StringBuilder();
            StringBuilder coordinates = new StringBuilder();
            while ((codes = Console.ReadLine()) != "find")
            {
                int indexKey = 0;

                for (int i = 0; i < codes.Length; i++)
                {
                    char currChar = (char)(codes[i] - key[indexKey]);
                    indexKey++;

                    if (indexKey >= key.Length)
                    {
                        indexKey = 0;
                    }

                    if (currChar == '&')
                    {
                        i++;
                        currChar = (char)(codes[i] - key[indexKey]);
                        indexKey++;

                        if (indexKey >= key.Length)
                        {
                            indexKey = 0;
                        }

                        while (currChar != '&')
                        {
                            type.Append(currChar);
                            i++;
                            currChar = (char)(codes[i] - key[indexKey]);
                            indexKey++;

                            if (indexKey >= key.Length)
                            {
                                indexKey = 0;
                            }
                        }
                    }

                    if (currChar == '<')
                    {
                        i++;
                        currChar = (char)(codes[i] - key[indexKey]);
                        indexKey++;

                        if (indexKey >= key.Length)
                        {
                            indexKey = 0;
                        }

                        while (currChar != '>')
                        {
                            coordinates.Append(currChar);
                            i++;
                            currChar = (char)(codes[i] - key[indexKey]);
                            indexKey++;

                            if (indexKey >= key.Length)
                            {
                                indexKey = 0;
                            }
                        }
                    }

                    if (type.Length > 0 && coordinates.Length > 0)
                    {
                        Console.WriteLine($"Found {type} at {coordinates}");
                        type.Clear();
                        coordinates.Clear();
                    }
                }
            }
        }
    }
}
