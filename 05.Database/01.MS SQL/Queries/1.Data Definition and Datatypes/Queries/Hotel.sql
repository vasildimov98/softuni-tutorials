CREATE DATABASE Hotel;

USE HOTEL;

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title) VALUES  
('Nevile', 'Longbottom', 'Auror'),
('Harry', 'Potter', 'Auror'),
('Ron', 'Weasley', 'Auror')

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(14) NOT NULL,
	EmergencyName VARCHAR(50) NOT NULL,
	EmergencyNumber VARCHAR(14) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber) VALUES
('TestFirst1', 'TestLast1', '+35989570505', 'TestEmergency1', '881699565'),
('TestFirst2', 'TestLast2', '+35989570505', 'TestEmergency2', '881699565'),
('TestFirst3', 'TestLast3', '+35989570505', 'TestEmergency3', '881699565')

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(20) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus) VALUES
('free1'),
('free2'),
('close1')

CREATE TABLE RoomTypes 
(
	RoomType VARCHAR(20) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType) VALUES
('Bigger'),
('Medium'),
('Smaller')

CREATE TABLE BedTypes
(
	BedType VARCHAR(20) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes (BedType) VALUES
('Big'),
('Medium'),
('Large')

CREATE TABLE Rooms 
(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate VARCHAR(10),
	RoomStatus VARCHAR(20),
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms (RoomType, BedType) VALUES
('Bigger', 'Big'),
('Medium', 'Medium'),
('Smaller', 'Small')

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME,
	LastDateOccupied DATETIME,
	TotalDays INT,
	AmountCharged DECIMAL(15,2) NOT NULL,
	TaxRate INT NOT NULL,
	TaxAmount INT NOT NULL,
	PaymentTotal DECIMAL(15,2) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, AccountNumber, AmountCharged, TaxRate, TaxAmount, PaymentTotal) VALUES
(1, 2, 23.23, 2, 2, 200),
(2, 2, 23.23, 2, 3, 100),
(3, 2, 23.23, 2, 2, 300)

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge INT,
	Notes VARCHAR(MAX)
)

USE Hotel;

UPDATE Payments
SET TaxRate -= TaxRate * 0.03;

SELECT TaxRate FROM Payments;


DELETE FROM Occupancies;
SELECT * FROM Occupancies;
