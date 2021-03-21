using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            foreach (var ticket in input)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    string left = new string(ticket.Take(10).ToArray());
                    string right = new string(ticket.Skip(10).ToArray());

                    string[] winers = new string[] { "@", "#", "\\$", "\\^" };
                    bool winningTickets = false;
                    foreach (var symbol in winers)
                    {
                        Regex regex = new Regex($"{symbol}{{6,}}");
                        Match leftSize = regex.Match(left);
                        if (leftSize.Success)
                        {
                            Match rightSize = regex.Match(right);
                            if (rightSize.Success)
                            {
                                winningTickets = true;

                                int length1 = leftSize.Value.Length;
                                int length2 = rightSize.Value.Length;
                                string jackpot = length1 == 10 && length2 == 10
                                    ? " Jackpot!"
                                    : string.Empty;

                                Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(length1, length2)}{symbol.Trim('\\')}{jackpot}");

                                break;
                            }
                        }
                    }

                    if (!winningTickets)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}
