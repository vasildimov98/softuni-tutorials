--02. One to Many
CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	EstablishedOn DATE NOT NULL
);
GO

--SELECT * FROM Manufacturers;
--GO

--TRUNCATE TABLE Manufacturers;

INSERT INTO Manufacturers ([Name], EstablishedOn) VALUES
	('BMW', '03/07/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '05/01/1966');
GO

CREATE TABLE Models 
(
	ModelID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL,
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID) NOT NULL
);
GO

--SELECT * FROM Models;
--GO

INSERT INTO Models ([Name], ManufacturerID) VALUES
	('X1',	1),
	('i6', 1),
	('Model S',	2),
	('Model X',	2),
	('Model	3',	2),
	('Nova', 3);	
GO