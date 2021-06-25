namespace P09.IncreaseAgeStoredProcedure
{
    using System;
    using System.Data;
    using Microsoft.Data.SqlClient;
    class Program
    {
        private const string DB_CONNECTION_TEXT = "Server=.;Database=MinionsDB;Integrated security=true";
        static void Main()
        {
            try
            {
                using var connection = new SqlConnection(DB_CONNECTION_TEXT);
                connection.Open();

                var minionId = int.Parse(Console.ReadLine());

                var minionInfo = CallStoreProcedureWithId(minionId, connection);

                Console.WriteLine(minionInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string CallStoreProcedureWithId(int minionId, SqlConnection connection)
        {
            var procName = "usp_GetOlder";
            using var command = new SqlCommand(procName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", minionId);

            var countOfEffectedRows = command.ExecuteNonQuery();

            if (countOfEffectedRows == 0)
            {
                return "Now rows effected! There is no such id!";
            }
            
            return MinionInfo(minionId, connection);
        }

        private static string MinionInfo(int minionId, SqlConnection connection)
        {
            var cmdText = "SELECT Name, Age FROM Minions WHERE Id = @Id";

            using var command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@Id", minionId);

            using var minionInfo = command.ExecuteReader();

            minionInfo.Read();

            var name = minionInfo["Name"];
            var age = minionInfo["Age"];

            return $"{name} – {age} years old";
        }
    }
}
