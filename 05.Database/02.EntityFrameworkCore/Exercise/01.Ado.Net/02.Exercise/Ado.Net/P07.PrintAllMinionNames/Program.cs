namespace P07.PrintAllMinionNames
{
    using System;
    using Microsoft.Data.SqlClient;
    using System.Collections.Generic;
    class Program
    {
        private const string DB_CONNECTION_TEXT = "Server=.;Database=MinionsDB;Integrated security=true";
        static void Main()
        {
            try
            {
                using var sqlConnection = new SqlConnection(DB_CONNECTION_TEXT);
                sqlConnection.Open();

                var names = SelectAllMinionsName(sqlConnection);
                var newlyOrderedNames = OrderName(names);

                Console.WriteLine(string.Join(Environment.NewLine, names));
                Console.WriteLine();
                Console.WriteLine(string.Join(Environment.NewLine, newlyOrderedNames));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<string> OrderName(List<string> names)
        {
            var output = new List<string>();

            for (int i = 0; i < names.Count / 2; i++)
            {
                output.Add(names[i]);
                output.Add(names[names.Count - i - 1]);
            }

            if (names.Count % 2 != 0)
            {
                output.Add(names[names.Count / 2]);
            }

            return output;
        }

        private static List<string> SelectAllMinionsName(SqlConnection sqlConnection)
        {
            var namesOutput = new List<string>();
            var selectNamesText = "SELECT Name FROM Minions";

            using var selectNamesCommand = new SqlCommand(selectNamesText, sqlConnection);

            using var minionsName = selectNamesCommand.ExecuteReader();

            while (minionsName.Read())
            {
                namesOutput.Add($"{minionsName["Name"]}");
            }
            

            return namesOutput;
        }
    }
}
