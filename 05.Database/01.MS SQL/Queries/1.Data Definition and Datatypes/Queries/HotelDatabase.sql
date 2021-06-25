CREATE DATABASE Hotel;

USE Hotel;

CREATE TABLE Employees (
     Id INT PRIMARY KEY IDENTITY(1,1),
	 FirstName NVARCHAR(50) NOT NULL,
	 LastName NVARCHAR(50) NOT NULL,
	 Title NVARCHAR(50),
	 Notes NVARCHAR(MAX)
);

INSERT INTO Employees (FirstName, LastName)
               Values 
			          ('Ivan', 'Petrov'),
			          ('Vasil;', 'Dimov'),
			          ('Tanya', 'Hristova');

CREATE TABLE Customers (
     AccountNumber BIGINT PRIMARY KEY,
	 FirstName NVARCHAR(50) NOT NULL,
	 LastName NVARCHAR(50) NOT NULL,
	 PhoneNumber INT,
	 EmergencyName NVARCHAR(50),
	 EmergencyNumber NVARCHAR(50),
	 Notes NVARCHAR(MAX)
);

INSERT INTO Customers (AccountNumber, FirstName, LastName)
               VALUES
			          (312412411412, 'Raliza', 'Goneva'),
			          (312312312313, 'Gabriela', 'Soleva'),
			          (412515616412, 'Maria', 'Balikova');

CREATE TABLE RoomStatus (
     RoomStatus NVARCHAR(50) PRIMARY KEY,
	 Notes NVARCHAR(MAX)
);

INSERT INTO RoomStatus (RoomStatus)
                VALUES
				       ('Free'),
				       ('Occupied'),
				       ('Cleaning');

CREATE TABLE RoomTypes (
     RoomType NVARCHAR(50) PRIMARY KEY,
	 Notes NVARCHAR(MAX)
);


INSERT INTO RoomTypes (RoomType)
                VALUES
				       ('Single'),
				       ('Double'),
				       ('Apartment');

CREATE TABLE BedTypes (
     BedType VARCHAR(50) PRIMARY KEY, 
     Notes NVARCHAR(MAX)
);

INSERT INTO BedTypes (BedType)
                VALUES
				       ('One person bed'),
				       ('Queen size bed'),
				       ('King size bed');

CREATE TABLE Rooms (
     RoomNumber INT PRIMARY KEY IDENTITY(10,1),
	 RoomType NVARCHAR(50) FOREIGN KEY(RoomType) REFERENCES RoomTypes(RoomType),
	 BedType VARCHAR(50) FOREIGN KEY(BedType) REFERENCES BedTypes(BedType),
	 Rate INT,
	 RoomStatus NVARCHAR(50) FOREIGN KEY(RoomStatus) REFERENCES RoomStatus(RoomStatus),
	 Notes NVARCHAR(MAX)
);

INSERT INTO Rooms (Rate)
            VALUES 
			       (7),
			       (8),
			       (10);

CREATE TABLE Payments (
     Id INT PRIMARY KEY IDENTITY(1,1),
     EmployeeId INT FOREIGN KEY(Id) REFERENCES Employees(Id),
     PaymentDate DATE,
     AccountNumber BIGINT NOT NULL,
     FirstDateOccupied DATE,
     LastDateOccupied DATE,
     TotalDays INT,
     AmountCharged DECIMAL(5,2),
     TaxRate DECIMAL(5,2),
     TaxAmount DECIMAL(5,2),
     PaymentTotal MONEY,
     Notes NVARCHAR(MAX)
);

INSERT INTO Payments (AccountNumber)
            VALUES
			         (412515616412),
			         (312312312313),
			         (312412411412);

CREATE TABLE Occupancies (
     Id INT PRIMARY KEY IDENTITY(1,1),
     EmployeeId INT FOREIGN KEY(Id) REFERENCES Employees(Id),
	 DateOccupied DATE,
	 AccountNumber BIGINT NOT NULL,
	 RoomNumber INT, 
	 RateApplied INT, 
	 PhoneCharge MONEY,
	 Notes NVARCHAR(MAX)
);

INSERT INTO Occupancies (AccountNumber)
                VALUES
			          (412515616412),
			          (312312312313),
			          (312412411412);

SELECT * FROM Employees;
SELECT * FROM Customers;
SELECT * FROM RoomStatus;
SELECT * FROM RoomTypes;
SELECT * FROM BedTypes;
SELECT * FROM Rooms;
SELECT * FROM Payments;
SELECT * FROM Occupancies;