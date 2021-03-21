using System;
using System.Collections.Generic;

namespace _05._Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, List<int>>> dragonsData = new Dictionary<string, SortedDictionary<string, List<int>>>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console
                    .ReadLine()
                    .Split();

                string type = data[0];
                string name = data[1];
                string damage = data[2];
                string health = data[3];
                string armor = data[4];

                if (!dragonsData.ContainsKey(type))
                {
                    dragonsData[type] = new SortedDictionary<string, List<int>>();
                    dragonsData[type][name] = new List<int>();
                    int tempDamage = 0;
                    int tempHealth = 0;
                    int tempArmor = 0;

                    if (damage == "null")
                    {
                        damage = "45";
                        tempDamage = int.Parse(damage);
                    }
                    else
                    {
                        tempDamage = int.Parse(damage);
                    }

                    if (health == "null")
                    {
                        health = "250";
                        tempHealth = int.Parse(health);
                    }
                    else
                    {
                        tempHealth = int.Parse(health);
                    }

                    if (armor == "null")
                    {
                        armor = "10";
                        tempArmor = int.Parse(armor);
                    }
                    else
                    {
                        tempArmor = int.Parse(armor);
                    }

                    dragonsData[type][name].Add(tempDamage);
                    dragonsData[type][name].Add(tempHealth);
                    dragonsData[type][name].Add(tempArmor);
                }
                else
                {
                    dragonsData[type][name] = new List<int>();
                    int tempDamage = 0;
                    int tempHealth = 0;
                    int tempArmor = 0;

                    if (damage == "null")
                    {
                        damage = "45";
                        tempDamage = int.Parse(damage);
                    }
                    else
                    {
                        tempDamage = int.Parse(damage);
                    }

                    if (health == "null")
                    {
                        health = "250";
                        tempHealth = int.Parse(health);
                    }
                    else
                    {
                        tempHealth = int.Parse(health);
                    }

                    if (armor == "null")
                    {
                        armor = "10";
                        tempArmor = int.Parse(armor);
                    }
                    else
                    {
                        tempArmor = int.Parse(armor);
                    }

                    dragonsData[type][name].Add(tempDamage);
                    dragonsData[type][name].Add(tempHealth);
                    dragonsData[type][name].Add(tempArmor);
                }
            }

            foreach (var type in dragonsData)
            {
                double sumDamage = 0;
                double sumHealth = 0;
                double sumArmor = 0;

                foreach (var stat in type.Value)
                {
                    sumDamage += stat.Value[0];
                    sumHealth += stat.Value[1];
                    sumArmor += stat.Value[2];
                }

                double averageDamage = sumDamage / type.Value.Count;
                double averageHealth = sumHealth / type.Value.Count;
                double averageArmor = sumArmor / type.Value.Count;

                Console.WriteLine($"{type.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");
                foreach (var dragon in type.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}
