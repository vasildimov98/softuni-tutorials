namespace P04.AddMinion
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.Data.SqlClient;

    class Program
    {
        private const string CONNECT_TO_DB_TEXT = "Server=.;Database=MinionsDB;Integrated security=true;";
        private static SqlTransaction sqlTransaction;
        static void Main()
        {
            try
            {
                using var sqlConnection = new SqlConnection(CONNECT_TO_DB_TEXT);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction();  

                var minionInfo = ReadInfo();
                var villainInfo = ReadInfo();

                var operationsInfo = AddMinionToVillain(sqlConnection, minionInfo, villainInfo);

                sqlTransaction.Commit();

                Console.WriteLine(operationsInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                try
                {
                    sqlTransaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
            }
        }

        private static string AddMinionToVillain(SqlConnection sqlConnection, string[] minionInfo, string[] villainInfo)
        {
            var sb = new StringBuilder();

            var minionName = minionInfo[0];
            var minionAge = minionInfo[1];
            var minionTown = minionInfo[2];

            var villainName = villainInfo[0];

            var townOperationInfo = EnsureTownExists(sqlConnection, minionTown);
            TryAddInfoIfAnyToResult(sb, townOperationInfo);

            var villainOperationInfo = EnsureVillainExists(sqlConnection, villainName);
            TryAddInfoIfAnyToResult(sb, villainOperationInfo);

            AddMinionToDB(sqlConnection, minionName, minionAge, minionTown);

            var addMinionToVillainOperationInfo = AddMinionToVillain(sqlConnection, minionName, villainName);
            TryAddInfoIfAnyToResult(sb, addMinionToVillainOperationInfo);

            return sb.ToString().TrimEnd();
        }

        private static void TryAddInfoIfAnyToResult(StringBuilder sb, string townOperationInfo)
        {
            if (townOperationInfo != string.Empty)
            {
                sb.AppendLine(townOperationInfo);
            }
        }

        private static string AddMinionToVillain(SqlConnection sqlConnection, string minionName, string villainName)
        {
            var selectVillainIdText = "SELECT Id FROM Villains WHERE Name = @Name";
            var selectMinionIdText = "SELECT Id FROM Minions WHERE Name = @Name";
            var insertMinionToVillionText = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            var villainId = GetId(sqlConnection, "@Name", villainName, selectVillainIdText);
            var minionId = GetId(sqlConnection, "@Name", minionName, selectMinionIdText);

            using var insertMinionToVillainCommad = new SqlCommand(insertMinionToVillionText, sqlConnection);

            insertMinionToVillainCommad.Parameters.AddRange(new[]
            {
                new SqlParameter("@villainId", villainId),
                new SqlParameter("@minionId", minionId)
            });

            insertMinionToVillainCommad.Transaction = sqlTransaction;

            return $"Successfully added {minionName} to be minion of {villainName}.";
        }

        private static void AddMinionToDB(SqlConnection sqlConnection, string name, string age, string townName)
        {
            var selectTownText = "SELECT Id FROM Towns WHERE Name = @townName";
            var addMinionText = "INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";

            var townId = GetId(sqlConnection, "@townName", townName, selectTownText);

            using var addMinionCommand = new SqlCommand(addMinionText, sqlConnection);

            addMinionCommand.Parameters.AddRange(new[]
            {
                new SqlParameter("@nam", name),
                new SqlParameter("@age", age),
                new SqlParameter("@townId", townId)
            });

            addMinionCommand.Transaction = sqlTransaction;

            addMinionCommand.ExecuteNonQuery();
        }

        private static object GetId(SqlConnection sqlConnection, string parameter, string parameterValue, string commadText)
        {
            using var selectIdCommand = new SqlCommand(commadText, sqlConnection);
            selectIdCommand.Parameters.AddWithValue(parameter, parameterValue);
            selectIdCommand.Transaction = sqlTransaction;

            var id = selectIdCommand.ExecuteScalar();
            return id;
        }

        private static string EnsureVillainExists(SqlConnection sqlConnection, string villainName)
        {
            var selectVillainText = "SELECT Id FROM Villains WHERE Name = @Name";

            using var selectVillainCommand = new SqlCommand(selectVillainText, sqlConnection);
            selectVillainCommand.Parameters.AddWithValue("@Name", villainName);
            selectVillainCommand.Transaction = sqlTransaction;

            var villainInfo = selectVillainCommand.ExecuteScalar();

            if (villainInfo == null)
            {
                return AddVillainToDB(sqlConnection, villainName);
            }

            return string.Empty;
        }

        private static string AddVillainToDB(SqlConnection sqlConnection, string villainName)
        {
            var insertVillainText = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
            using var insertVillainCommand = new SqlCommand(insertVillainText, sqlConnection);
            insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
            insertVillainCommand.Transaction = sqlTransaction;

            insertVillainCommand.ExecuteNonQuery();

            return $"Villain {villainName} was added to the database.";
        }

        private static string EnsureTownExists(SqlConnection sqlConnection, string townName)
        {
            var selectTownText = "SELECT Id FROM Towns WHERE Name = @townName";

            var townId = GetId(sqlConnection, "@townName", townName, selectTownText);

            if (townId == null)
            {
                return AddTownToDB(sqlConnection, townName);
            }

            return string.Empty;
        }

        private static string AddTownToDB(SqlConnection sqlConnection, string townName)
        {
            var insertTownText = "INSERT INTO Towns (Name) VALUES (@townName)";
            using var insertTownCommand = new SqlCommand(insertTownText, sqlConnection);
            insertTownCommand.Parameters.AddWithValue("@townName", townName);
            insertTownCommand.Transaction = sqlTransaction;

            insertTownCommand.ExecuteNonQuery();

            return $"Town {townName} was added to the database."; 
        }

        private static string[] ReadInfo()
        {
            return Console
                .ReadLine()
                .Split()
                .Skip(1)
                .ToArray();
        }
    }
}
