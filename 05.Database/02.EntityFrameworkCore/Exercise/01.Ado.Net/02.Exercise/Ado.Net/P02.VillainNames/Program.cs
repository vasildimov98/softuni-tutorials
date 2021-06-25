namespace P02.VillainNames
{
    using System;
    using System.Text;
    using Microsoft.Data.SqlClient;

    class Program
    {
        private const string CONNECTION_STRING_TO_MINIONS_DB = "Server=.;Database=MinionsDB;Integrated security=true";
        private const string SELECT_ALL_VILLAINS_WITH_MORE_THEN_THREE_MINIONS_TEXT = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains AS v     JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(mv.VillainId)";
        static void Main()
        {
            try
            {
                using var sqlConnectionToMinionsDB = new SqlConnection(CONNECTION_STRING_TO_MINIONS_DB);

                sqlConnectionToMinionsDB.Open();

                var vilionsWithMoreThenThreeMinions = GetVillionsWithMoreThenThreeMinions(sqlConnectionToMinionsDB);

                Console.WriteLine(vilionsWithMoreThenThreeMinions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetVillionsWithMoreThenThreeMinions(SqlConnection sqlConnection)
        {
            var sb = new StringBuilder();

            using var selectViliansCommandData = new SqlCommand(SELECT_ALL_VILLAINS_WITH_MORE_THEN_THREE_MINIONS_TEXT, sqlConnection);

            using var commandReader = selectViliansCommandData.ExecuteReader();

            while (commandReader.Read())
            {
                var name = commandReader["Name"];
                var minionsCount = commandReader["MinionsCount"];

                sb.AppendLine($"{name} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
