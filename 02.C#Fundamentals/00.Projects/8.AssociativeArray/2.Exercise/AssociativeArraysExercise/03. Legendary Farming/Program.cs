using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main()
        {

            Dictionary<string, int> keyDictionary = new Dictionary<string, int>();
            keyDictionary.Add("shards", 0);
            keyDictionary.Add("fragments", 0);
            keyDictionary.Add("motes", 0);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string materialObtained = "";
            while (true)
            {
                string[] arr = Console
                    .ReadLine()
                    .Split();
                bool isFalse = false;

                for (int i = 0; i < arr.Length / 2; i++)
                {
                    int quantity = int.Parse(arr[i + i]);
                    string material = arr[i + i + 1].ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyDictionary[material] += quantity;

                        if (keyDictionary[material] >= 250)
                        {
                            keyDictionary[material] -= 250;
                            materialObtained = material;
                            isFalse = true;
                            break;
                        }
                    }
                    else
                    {
                        if (dictionary.ContainsKey(material))
                        {
                            dictionary[material] += quantity;
                        }
                        else
                        {
                            dictionary.Add(material, quantity);
                        }
                    }
                }

                if (isFalse)
                {
                    break;
                }
            }

            if (materialObtained == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (materialObtained == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (materialObtained == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            keyDictionary = keyDictionary
                .OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(a => a.Key,
                a => a.Value);

            foreach (var item in keyDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            dictionary = dictionary
                .OrderBy(a => a.Key)
                .ToDictionary(a => a.Key,
                a => a.Value);

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
