namespace P01.SingletonDemo
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    public class SingletonDataContainer : ISingletonContainer
    {
        private const string FILE_PATH_NAME = "capitals.txt";

        private static SingletonDataContainer instance = new SingletonDataContainer();

        private Dictionary<string, int> capitals;

        private SingletonDataContainer()
        {
            this.capitals = new Dictionary<string, int>();

            Console.WriteLine("Initializing singleton objects");

            var elements = File.ReadAllLines(FILE_PATH_NAME);

            for (int i = 0; i < elements.Length; i += 2)
            {
                this.capitals[elements[i]] = int.Parse(elements[i + 1]);
            }
        }

        public static ISingletonContainer Instance => instance;
        public int GetPopulation(string name)
        {
            if (this.capitals.ContainsKey(name))
            {
                return this.capitals[name];
            }

            return 0;
        }
    }
}
