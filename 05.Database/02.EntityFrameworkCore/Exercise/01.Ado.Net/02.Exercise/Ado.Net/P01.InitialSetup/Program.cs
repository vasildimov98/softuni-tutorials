namespace P01.InitialSetup
{
    using System;
    using Microsoft.Data.SqlClient;

    class Program
    {
        private const string CONNECTION_INFO_TO_MASTER = "Server=.;Database=master;Integrated security=true";

        private const string CONNECTION_INFO_TO_MINIONS_DB = "Server=.;Database=MinionsDB;Integrated security=true";

        private const string CREATE_DATABASE_TEXT = "CREATE DATABASE MinionsDB";
        static void Main()
        {
            try
            {
                using var sqlConnectToMaster = new SqlConnection(CONNECTION_INFO_TO_MASTER);
                sqlConnectToMaster.Open();
                using var sqlCommandCreate = new SqlCommand(CREATE_DATABASE_TEXT, sqlConnectToMaster);

                sqlCommandCreate.ExecuteNonQuery();

                using var sqlConnectToMinonsDB = new SqlConnection(CONNECTION_INFO_TO_MINIONS_DB);

                sqlConnectToMinonsDB.Open();

                CreateTablesForMinionsDB(sqlConnectToMinonsDB);
                InsertValuesIntoTables(sqlConnectToMinonsDB);

                Console.WriteLine("Successfully inserted values into tables to newly creted database");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void InsertValuesIntoTables(SqlConnection sqlConnection)
        {
            var insertCountryValuesText = "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";

            var insertTownsValuesText = "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";

            var insertMinionsValuesText = "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";

            var insertEvilnessFactorValuesText = "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";

            var insertVillainsValuesText = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)";

            var insertMinionsVillainsValuesText = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";

            using var createCountryCommand = new SqlCommand(insertCountryValuesText, sqlConnection);
            createCountryCommand.ExecuteNonQuery();

            using var insertTownsComValuesmand = new SqlCommand(insertTownsValuesText, sqlConnection);
            insertTownsComValuesmand.ExecuteNonQuery();

            using var insertMinionsCValuesommand = new SqlCommand(insertMinionsValuesText, sqlConnection);
            insertMinionsCValuesommand.ExecuteNonQuery();

            using var insertEvilnessValuesFactorCommand = new SqlCommand(insertEvilnessFactorValuesText, sqlConnection);
            insertEvilnessValuesFactorCommand.ExecuteNonQuery();

            using var insertVillainsValuesCommand = new SqlCommand(insertVillainsValuesText, sqlConnection);
            insertVillainsValuesCommand.ExecuteNonQuery();

            using var insertMinionsVValuesillainsCommand = new SqlCommand(insertMinionsVillainsValuesText, sqlConnection);
            insertMinionsVValuesillainsCommand.ExecuteNonQuery();
        }

        private static void CreateTablesForMinionsDB(SqlConnection sqlConnection)
        {
            var createCountryText = "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))";

            var createTownsText = "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";

            var createMinionsText = "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";

            var createEvilnessFactorText = "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";

            var createVillainsText = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";

            var createMinionsVillainsText = "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";

            using var createCountryCommand = new SqlCommand(createCountryText, sqlConnection);
            createCountryCommand.ExecuteNonQuery();

            using var createTownsCommand = new SqlCommand(createTownsText, sqlConnection);
            createTownsCommand.ExecuteNonQuery();

            using var createMinionsCommand = new SqlCommand(createMinionsText, sqlConnection);
            createMinionsCommand.ExecuteNonQuery();

            using var createEvilnessFactorCommand = new SqlCommand(createEvilnessFactorText, sqlConnection);
            createEvilnessFactorCommand.ExecuteNonQuery();

            using var createVillainsCommand = new SqlCommand(createVillainsText, sqlConnection);
            createVillainsCommand.ExecuteNonQuery();

            using var createMinionsVillainsCommand = new SqlCommand(createMinionsVillainsText, sqlConnection);
            createMinionsVillainsCommand.ExecuteNonQuery();
        }
    }
}
