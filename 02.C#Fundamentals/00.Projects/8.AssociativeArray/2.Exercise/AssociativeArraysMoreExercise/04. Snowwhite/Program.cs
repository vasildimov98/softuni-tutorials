using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            Dictionary<string, int> dwarfData = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] data = command
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = data[0];
                string dwarfHatColor = data[1];
                int dwarfPhysics = int.Parse(data[2]);

                string nameAndColor = dwarfName + ":" + dwarfHatColor;
                if (!dwarfData.ContainsKey(nameAndColor))
                {
                    dwarfData[nameAndColor] = dwarfPhysics;
                }
                else if (dwarfData[nameAndColor] < dwarfPhysics)
                {
                    dwarfData[nameAndColor] = dwarfPhysics;
                }
            }

            foreach (var dwarf in dwarfData
                .OrderByDescending(a => a.Value)
                .ThenByDescending(a => dwarfData.Where(b => b.Key.Split(':')[1] == a.Key.Split(':')[1])
                .Count()))
            {
                Console.WriteLine($"({dwarf.Key.Split(':')[1]}) {dwarf.Key.Split(':')[0]} <-> {dwarf.Value}");
            }
        }
    }
}
