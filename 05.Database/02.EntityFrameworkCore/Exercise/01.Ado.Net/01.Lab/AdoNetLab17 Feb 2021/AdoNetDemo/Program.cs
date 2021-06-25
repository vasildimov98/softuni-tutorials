namespace AdoNetDemo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Data.SqlClient;
    class Program
    {
        static void Main()
        {
            using var sqlConnection = new SqlConnection("Server=.;Database=Bitbucket;Integrated Security=true");

            sqlConnection.Open();
            // var input = Console.ReadLine();

            //var size = long.Parse(Console.ReadLine());
            //var extension = Console.ReadLine();

            var result = UserWithAverageSize(sqlConnection/*, size, extension*/);

            Console.WriteLine(result);
        }

        //Problem 05
        private static string TakeAllCommits(SqlConnection connection)
        {
            var query = @"SELECT
                           Id
                           ,[Message]
                           ,RepositoryId
                           ,ContributorId
                          FROM Commits;";

            using var command = new SqlCommand(query, connection);

            using var result = command.ExecuteReader();

            return CreateOutput(result, "Id", "Message", "RepositoryId", "ContributorId");
        }

        //Problem 06
        private static string TakeAllFilterFiles(SqlConnection connection, long size, string extention)
        {
            var query = @"SELECT
	                         Id
	                        ,[Name]
	                        ,Size
                          FROM Files
                          WHERE Size > @Size AND CHARINDEX(@Extension, [Name]) > 0
                          ORDER BY Size DESC, Id ASC;";

            using var command = new SqlCommand(query, connection);

            command
                .Parameters
                .AddRange(new SqlParameter[]
                {
                    new SqlParameter("@Size", size),
                    new SqlParameter("@Extension", extention)
                });

            using var result = command.ExecuteReader();

            return CreateOutput(result, "Id", "Name", "Size");
        }

        //Problem 07
        private static string SelectAllIssueWithAssignee(SqlConnection connection)
        {
            var query = @"SELECT
	                        i.Id
	                        ,CONCAT(u.Username, ' : ', i.Title) IssueAssignee
                          FROM Issues i
                          LEFT JOIN Users u
	                          ON i.AssigneeId = u.Id
                          ORDER BY i.Id DESC;";

            using var command = new SqlCommand(query, connection);

            using var result = command.ExecuteReader();

            return CreateOutput(result, "Id", "IssueAssignee");
        }

        //Problem 08
        private static string SelectSingleFiles(SqlConnection connection)
        {
            var query = @"SELECT
                          	Id
                          	,[Name]
                          	,Size
                          FROM Files
                          WHERE Id NOT IN (SELECT ParentId FROM Files WHERE ParentId IS NOT NULL);";

            using var command = new SqlCommand(query, connection);

            using var result = command.ExecuteReader();

            return CreateOutput(result, "Id", "Name", "Size");
        }

        //Problem 09
        private static string SelectTopFiveRepositories(SqlConnection connection)
        {
            var query = @"SELECT TOP (5)
	                        r.Id
	                        ,r.[Name]
	                        ,COUNT(*) Commits
                          FROM RepositoriesContributors rc
                          JOIN Repositories r
	                          ON rc.RepositoryId = r.Id
                          JOIN Commits c
	                          ON r.Id = c.RepositoryId
                          GROUP BY r.Id, r.[Name]
                          ORDER BY Commits DESC, Id ASC;";

            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();

            return CreateOutput(reader, "Id", "Name", "Commits");
        }

        //Problem 10
        private static string UserWithAverageSize(SqlConnection connection)
        {
            var query = @"SELECT
	                        u.Username
	                        ,AVG(f.Size) AverageSize
                          FROM Users u
                          JOIN Commits c
	                          ON u.Id = c.ContributorId
                          JOIN Files f
	                          ON c.Id = f.CommitId
                          GROUP BY u.Username
                          ORDER BY AverageSize DESC, u.Username;";

            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();

            return CreateOutput(reader, "Username", "AverageSize");
        }

        //Problem 11
        private static string AllUserCommits(SqlConnection connection, string username)
        {
            var query = @$"SELECT
	                        COUNT(*)
                          FROM Users u
                          JOIN Commits c
                          	ON u.Id = c.ContributorId
                          WHERE u.Username = @Username;";

            using var sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@Username", username);

            var commitsCount = (int)sqlCommand.ExecuteScalar();

            return $"{username} has {commitsCount} commit{(commitsCount != 1 ? "s" : string.Empty)}";
        }

        //Problem 12
        private static string SearchForFiles(SqlConnection connection, string extension)
        {
            var query = @"SELECT
	                          Id
	                          ,[Name]
	                          ,CONCAT(Size, 'KB') Size
                          FROM Files
                          WHERE SUBSTRING([Name], CHARINDEX('.', [Name]) + 1, LEN([Name])) = @Extension
                          ORDER BY Id ASC, [Name] ASC, Size DESC;";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Extension", extension);

            using var result = command.ExecuteReader();

            return CreateOutput(result, "id", "Name", "Size");
        }


        // Help methods
        private static string CreateOutput(SqlDataReader reader, params string[] keys)
        {
            var sb = new StringBuilder();
            while (reader.Read())
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    sb.Append($"{reader[keys[i]]}{(i != keys.Length - 1 ? " " : string.Empty)}");
                }

                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
