using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string command = "";

            double spendOnGames = 0;
            while ((command = Console.ReadLine()) != "Game Time")
            {
                
                if (command == "OutFall 4")
                {
                    if (currentBalance >= 39.99)
                    {
                        currentBalance -= 39.99;
                        spendOnGames += 39.99;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "CS: OG")
                {
                    if (currentBalance >= 15.99)
                    {
                        currentBalance -= 15.99;
                        spendOnGames += 15.99;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    if (currentBalance >= 19.99)
                    {
                        currentBalance -= 19.99;
                        spendOnGames += 19.99;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Honored 2")
                {
                    if (currentBalance >= 59.99)
                    {
                        currentBalance -= 59.99;
                        spendOnGames += 59.99;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch")
                {
                    if (currentBalance >= 29.99)
                    {
                        currentBalance -= 29.99;
                        spendOnGames += 29.99;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    if (currentBalance >= 39.99)
                    {
                        currentBalance -= 39.99;
                        spendOnGames += 39.99;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                if (currentBalance == 0.0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }

            Console.WriteLine($"Total spent: ${spendOnGames:F2}. Remaining: ${currentBalance:F2}");
        }
    }
}
