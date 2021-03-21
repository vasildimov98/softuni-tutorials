namespace P01.SecretChat
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var concealedMsg = Console.ReadLine();

            concealedMsg = ProcceedCommand(concealedMsg);

            Console.WriteLine($"You have a new text message: {concealedMsg}");
        }

        private static string ProcceedCommand(string concealedMsg)
        {
            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                var args = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];

                if (action == "InsertSpace")
                {
                    concealedMsg = InsertSpace(concealedMsg, args);

                    Console.WriteLine(concealedMsg);
                }
                else if (action == "Reverse")
                {
                    concealedMsg = ReverseAndReplace(concealedMsg, args);
                }
                else
                {
                    concealedMsg = ChangeTheSubstring(concealedMsg, args);

                    Console.WriteLine(concealedMsg);
                }
            }

            return concealedMsg;
        }

        private static string ChangeTheSubstring(string concealedMsg, string[] args)
        {
            var substring = args[1];
            var replacement = args[2];

            concealedMsg = concealedMsg.Replace(substring, replacement);
            return concealedMsg;
        }

        private static string ReverseAndReplace(string concealedMsg, string[] args)
        {
            var substring = args[1];

            if (!concealedMsg.Contains(substring))
            {
                Console.WriteLine("error");
            }
            else
            {
                var reversedSubstring = string.Join("", substring.Reverse());

                var indexOfSubstring = concealedMsg.IndexOf(substring);

                concealedMsg = concealedMsg.Remove(indexOfSubstring, substring.Length);

                concealedMsg = concealedMsg.Insert(concealedMsg.Length, reversedSubstring);

                Console.WriteLine(concealedMsg);
            }

            return concealedMsg;
        }

        private static string InsertSpace(string concealedMsg, string[] args)
        {
            var index = int.Parse(args[1]);
            return concealedMsg.Insert(index, " ");
        }
    }
}
