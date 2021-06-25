namespace P03.MinionNames
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Text;

    class Program
    {
        private const string CONNECT_TO_DATABASE_TEXT = "Server=.;Database=MinionsDB;Integrated security=true;";

        static void Main()
        {
            try
            {
                using var sqlConnection = new SqlConnection(CONNECT_TO_DATABASE_TEXT);

                sqlConnection.Open();

                var villainId = int.Parse(Console.ReadLine());

                var villainInfo = GenerateVillainInfo(sqlConnection, villainId);

                Console.WriteLine(villainInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GenerateVillainInfo(SqlConnection sqlConnection, int villainId)
        {
            var selectVillainText = "SELECT Name FROM Villains WHERE Id = @Id";
            var selectVillainMinionsText = "SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum, m.Name, m.Age FROM MinionsVillains AS mv JOIN Minions As m ON mv.MinionId = m.Id WHERE mv.VillainId = @Id ORDER BY m.Name";

            var sb = new StringBuilder();

            using var selectVillainCommand = new SqlCommand(selectVillainText, sqlConnection);
            selectVillainCommand.Parameters.AddWithValue("@Id", villainId);
            var villionName = selectVillainCommand.ExecuteScalar();

            if (villionName != null)
            {
                sb.AppendLine($"Villain: {villionName}");
            }
            else
            {
                return ($"No villain with ID {villainId} exists in the database.");
            }

            using var selectVillionMinions = new SqlCommand(selectVillainMinionsText, sqlConnection);
            selectVillionMinions.Parameters.AddWithValue("@Id", villainId);

            using var minions = selectVillionMinions.ExecuteReader();

            var hasNoMinions = true;
            while (minions.Read())
            {
                hasNoMinions = false;
                var rowNum = minions["RowNum"];
                var name = minions["Name"];
                var age = minions["Age"];

                sb.AppendLine($"{rowNum}. {name} {age}");
            }

            if (hasNoMinions)
            {
                sb.AppendLine("(no minions)");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
