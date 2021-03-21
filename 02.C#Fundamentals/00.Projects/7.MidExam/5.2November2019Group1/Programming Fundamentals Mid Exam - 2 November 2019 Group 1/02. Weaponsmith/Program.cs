using System;
using System.Linq;

namespace _02._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weapon = Console
                .ReadLine()
                .Split("|");

            string command = "";

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] allCommands = command.Split();

                string action = allCommands[0];

                if (action == "Move")
                {
                    GetMovedArr(weapon, allCommands, action);
                }
                else if (action == "Check")
                {
                    CheckEvenOrOdd(weapon, allCommands);
                }
            }

            Console.WriteLine($"You crafted {string.Join("", weapon)}!");
        }

        private static void CheckEvenOrOdd(string[] weapon, string[] allCommands)
        {
            string evenOrOdd = allCommands[1];
            string result = "";
            if (evenOrOdd == "Even")
            {
                for (int i = 0; i < weapon.Length; i += 2)
                {
                    result += $"{weapon[i]} ";
                }
            }
            else
            {
                for (int i = 1; i < weapon.Length; i += 2)
                {
                    result += $"{weapon[i]} ";
                }
            }

            Console.WriteLine(result.Trim());
        }

        private static void GetMovedArr(string[] weapon, string[] allCommands, string action)
        {
                string position = allCommands[1];
                int index = int.Parse(allCommands[2]);

                if (position == "Left" && index - 1 >= 0 && index < weapon.Length)
                {
                    string temp = weapon[index - 1];
                    weapon[index - 1] = weapon[index];
                    weapon[index] = temp;
                }
                else if (position == "Right" && index >= 0 && index + 1 < weapon.Length)
                {
                    string temp = weapon[index + 1];
                    weapon[index + 1] = weapon[index];
                    weapon[index] = temp;
                }
        }
    }
}
