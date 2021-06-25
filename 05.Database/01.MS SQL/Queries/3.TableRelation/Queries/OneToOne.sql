--01 One to One Relation
CREATE TABLE Passports
(
	PassportID INT IDENTITY(101, 1) PRIMARY KEY,
	PassportNumber VARCHAR(8) NOT NULL
);
GO

INSERT INTO Passports (PassportNumber)
VALUES 
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2');
GO

--SELECT * FROM Passports;
--GO

CREATE TABLE Persons 
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	PassportID INT REFERENCES Passports(PassportID) UNIQUE
);
GO

INSERT INTO Persons (FirstName, Salary, PassportID)
VALUES
	('Roberto', 43300.00, 102),
	('Tom',	56100.00, 103),
	('Yana', 60200.00, 101);
GO

--SELECT * FROM Persons;
--GO