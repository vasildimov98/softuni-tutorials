namespace P05.ChangeTownNamesCasing
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        private const string CONNECTING_TO_DB_TEXT = "Server=.;Database=MinionsDB; Integrated security=true";

        static void Main()
        {
            try
            {
                using var sqlConnection = new SqlConnection(CONNECTING_TO_DB_TEXT);
                sqlConnection.Open();

                var countryName = Console.ReadLine();

                var result = TryToMakeTownsOfCountryToUppercase(countryName, sqlConnection);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string TryToMakeTownsOfCountryToUppercase(string countryName, SqlConnection sqlConnection)
        {
            var output = new StringBuilder();

            var tryToUpdateTownsNameText = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using var updateTownsNameCommand = new SqlCommand(tryToUpdateTownsNameText, sqlConnection);
            updateTownsNameCommand.Parameters.AddWithValue("@countryName", countryName);

            var updatedTowsCount = updateTownsNameCommand.ExecuteNonQuery();

            if (updatedTowsCount == 0)
            {
                output.AppendLine("No town names were affected.");
            }
            else
            {
                output.AppendLine($"{updatedTowsCount} town names were affected.");
                var towsName = SelectTownsName(countryName, sqlConnection);
                output.AppendLine(towsName);
            }

            return output.ToString().TrimEnd();
        }

        private static string SelectTownsName(string countryName, SqlConnection sqlConnection)
        {
            var output = new List<string>();

            var selectAllTownsText = "SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";

            using var selectTownsNameCommand = new SqlCommand(selectAllTownsText, sqlConnection);
            selectTownsNameCommand.Parameters.AddWithValue("@countryName", countryName);

            var townsNameResult = selectTownsNameCommand.ExecuteReader();

            while (townsNameResult.Read())
            {
                output.Add($"{townsNameResult["Name"]}");
            }

            return $"[{string.Join(", ", output)}]";
        }
    }
}
