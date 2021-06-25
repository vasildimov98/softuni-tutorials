namespace P06.RemoveVillain
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Text;

    class Program
    {
        private const string DB_CONNECTION_TEXT = "Server=.;Database=MinionsDB; Integrated security=true";

        private static SqlTransaction sqlTransaction;

        static void Main()
        {
            try
            {
                using var sqlConnection = new SqlConnection(DB_CONNECTION_TEXT);

                sqlConnection.Open();

                var villainId = int.Parse(Console.ReadLine());

                sqlTransaction = sqlConnection.BeginTransaction();

                using (sqlTransaction)
                {
                    var resultInfo = TryToDeleteVillainFromDB(villainId, sqlConnection);

                    Console.WriteLine(resultInfo);
                };
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
                finally
                {
                    sqlTransaction.Dispose();
                }
            }
        }

        private static string TryToDeleteVillainFromDB(int villainId, SqlConnection sqlConnection)
        {
            var output = new StringBuilder();

            var selectNameOfVillainText = "SELECT Name FROM Villains WHERE Id = @villainId";

            var deleteVillainFromRelationTableText = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

            var deleteVillainFromVillainTableText = "DELETE FROM Villains WHERE Id = @villainId";

            using var selectVillainCommand = new SqlCommand(selectNameOfVillainText, sqlConnection);
            selectVillainCommand.Parameters.AddWithValue("@villainId", villainId);
            selectVillainCommand.Transaction = sqlTransaction;

            var villainName = selectVillainCommand.ExecuteScalar();

            if (villainName == null)
            {
                return "No such villain was found.";
            }

            var firstDeletionResult = DeleteData(villainId, deleteVillainFromRelationTableText, sqlConnection);

            output.AppendLine($"{villainName} was deleted.");
            
            var secondDeletionResult = DeleteData(villainId, deleteVillainFromVillainTableText, sqlConnection);

            output.AppendLine($"{firstDeletionResult} minions were released.");

            sqlTransaction.Commit();

            return output.ToString().TrimEnd();
        }

        private static int DeleteData(int villainId, string cmdText, SqlConnection connection)
        {
            using var deleteCommand = new SqlCommand(cmdText, connection);
            deleteCommand.Parameters.AddWithValue("villainId", villainId);
            deleteCommand.Transaction = sqlTransaction;

            var result = deleteCommand.ExecuteNonQuery();

            return result;
        }
    }
}
