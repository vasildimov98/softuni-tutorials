using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            Dictionary<string, Dictionary<string, int>> playersInfo = new Dictionary<string, Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "Season end")
            {
                if (command.Contains("->"))
                {
                    string[] data = Regex.Split(command, " -> ");
                    string player = data[0];
                    string position = data[1];
                    int skills = int.Parse(data[2]);

                    if (!playersInfo.ContainsKey(player))
                    {
                        playersInfo.Add(player, new Dictionary<string, int>());
                    }
                    if (!playersInfo[player].ContainsKey(position))
                    {
                        playersInfo[player].Add(position, 0);
                    }
                    if (playersInfo[player][position] <= skills)
                    {
                        playersInfo[player][position] = skills;

                    }
                }
                else
                {
                    string[] data = Regex.Split(command, " vs ").ToArray();
                    string player1 = data[0];
                    string player2 = data[1];

                    if (!playersInfo.ContainsKey(player1) || !playersInfo.ContainsKey(player2))
                    {
                        continue;
                    }

                    foreach (var position in playersInfo[player1])
                    {
                        if (playersInfo[player2].ContainsKey(position.Key))
                        {
                            int totalSkill1 = playersInfo[player1].Values.Sum();
                            int totalSkill2 = playersInfo[player2].Values.Sum();

                            if (totalSkill1 > totalSkill2)
                            {
                                playersInfo.Remove(player2);
                            }
                            else if (totalSkill2 > totalSkill1)
                            {
                                playersInfo.Remove(player1);
                            }
                            break;
                        }
                    }
                }
            }

            foreach (var player in playersInfo.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var men in player.Value.OrderByDescending(x => x.Value).ThenBy(c => c.Key))
                {
                    Console.WriteLine($"- {men.Key} <::> {men.Value}");
                }
            }
        }
    }
}