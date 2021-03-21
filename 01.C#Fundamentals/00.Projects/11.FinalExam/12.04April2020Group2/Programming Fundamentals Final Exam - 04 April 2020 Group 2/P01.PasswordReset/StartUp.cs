namespace P01.PasswordReset
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            var password = Console.ReadLine();
            password = CreateNewPassword(password);
            Console.WriteLine($"Your password is: {password}");
        }

        private static string CreateNewPassword(string password)
        {
            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                var args = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];

                if (action == "TakeOdd")
                {
                    password = TakeAllOddLines(password);

                    Console.WriteLine(password);
                }
                else if (action == "Cut")
                {
                    password = CutThePassword(password, args);

                    Console.WriteLine(password);
                }
                else
                {
                    password = ReplaceSubstring(password, args);
                }
            }

            return password;
        }

        private static string ReplaceSubstring(string password, string[] args)
        {
            var substring = args[1];

            if (!password.Contains(substring))
            {
                Console.WriteLine("Nothing to replace!");
            }
            else
            {
                var subtitute = args[2];

                password = password.Replace(substring, subtitute);

                Console.WriteLine(password);
            }

            return password;
        }

        private static string CutThePassword(string password, string[] args)
        {
            var index = int.Parse(args[1]);
            var length = int.Parse(args[2]);

            var substring = password.Substring(index, length);

            var indexOfSubsring = password.IndexOf(substring);

            password = password.Remove(indexOfSubsring, substring.Length);
            return password;
        }

        private static string TakeAllOddLines(string str)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sb.Append(str[i]);
                }
            }

            str = sb.ToString();
            return str;
        }
    }
}
