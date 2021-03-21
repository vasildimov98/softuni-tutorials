using System;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "For Azeroth")
            {
                string[] data = command
                    .Split(" ", StringSplitOptions.None);
                string action = data[0];

                if (action == "GladiatorStance")
                {
                    skill = skill.ToUpper();
                    Console.WriteLine(skill);
                }
                else if (action == "DefensiveStance")
                {
                    skill = skill.ToLower();
                    Console.WriteLine(skill);
                }
                else if (action == "Dispel")
                {
                    int index = int.Parse(data[1]);
                    char letter = char.Parse(data[2]);

                    if (index >= 0 && index < skill.Length)
                    {
                        char[] tempChar = skill.ToCharArray();
                        tempChar[index] = letter;
                        skill = new string(tempChar);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }
                else if (action == "Target")
                {
                    if (data[1] == "Change")
                    {
                        string substring1 = data[2];
                        string substring2 = data[3];

                        skill = skill.Replace(substring1, substring2);

                        Console.WriteLine(skill);
                    }
                    else if (data[1] == "Remove")
                    {
                        string substring = data[2];
                        skill = skill.Replace(substring, "");
                        Console.WriteLine(skill);
                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist!");
                    }
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }
        }
    }
}
