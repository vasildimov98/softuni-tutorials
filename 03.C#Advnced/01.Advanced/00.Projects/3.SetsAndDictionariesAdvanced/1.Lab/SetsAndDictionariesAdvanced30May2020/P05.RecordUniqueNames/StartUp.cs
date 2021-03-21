namespace P05.RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static HashSet<string> uniqueNames;
        public static void Main()
        {
            uniqueNames = new HashSet<string>();
            var numberOfNamesToRead = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfNamesToRead; i++)
            {
                uniqueNames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, uniqueNames));
        }
    }
}
