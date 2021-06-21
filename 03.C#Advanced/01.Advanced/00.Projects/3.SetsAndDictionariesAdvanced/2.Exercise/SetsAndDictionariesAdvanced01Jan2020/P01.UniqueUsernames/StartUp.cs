namespace P01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static HashSet<string> usernames;
        public static void Main()
        {
            usernames = new HashSet<string>();

            var numberOfUsernames = int.Parse(Console.ReadLine());

            CollectAllUniqueUsernames(numberOfUsernames);
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }

        private static void CollectAllUniqueUsernames(int numberOfUsernames)
        {
            for (int i = 0; i < numberOfUsernames; i++)
            {
                usernames.Add(Console.ReadLine());
            }
        }
    }
}
