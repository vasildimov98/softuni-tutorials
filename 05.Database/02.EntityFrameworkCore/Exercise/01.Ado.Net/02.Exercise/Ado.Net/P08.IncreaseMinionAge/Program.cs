namespace P08.IncreaseMinionAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Data.SqlClient;

    class Program
    {
        private const string DB_CONNECTION_TEXT = "Server=.;Database=MinionsDB;Integrated security=true";

        static void Main()
        {
            try
            {
                using var sqlConnection = new SqlConnection(DB_CONNECTION_TEXT);
                sqlConnection.Open();

                var ids = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var minionsNames = UpdateNames(ids, sqlConnection);

                Console.WriteLine(string.Join(Environment.NewLine, minionsNames));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<string> UpdateNames(int[] ids, SqlConnection sqlConnection)
        {
            var cmdText = " UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 WHERE Id = @Id";

            foreach (var id in ids)
            {
                using var command = new SqlCommand(cmdText, sqlConnection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }

            return ReturnMinionsInfo(ids, sqlConnection);
        }

        private static List<string> ReturnMinionsInfo(int[] ids, SqlConnection sqlConnection)
        {
            var commandText = "SELECT Id, Name, Age FROM Minions";
            using var command = new SqlCommand(commandText, sqlConnection);

            using var minionsInfo = command.ExecuteReader();

            var outputNames = new List<string>();

            while (minionsInfo.Read())
            {
                var id = (int)minionsInfo["Id"];
                var name = minionsInfo["Name"];
                var age = minionsInfo["Age"];

                if (!ids.Contains(id))
                {
                    outputNames.Add($"{name.ToString().ToLower()} {age}");
                }
                else
                {
                    outputNames.Add($"{name} {age}");
                }
            }

            return outputNames;
        }
    }
}
