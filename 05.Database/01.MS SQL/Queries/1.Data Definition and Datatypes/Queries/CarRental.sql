CREATE DATABASE CarRental;
USE CarRental;

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	CategoryName NVARCHAR(20) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
)

INSERT INTO Categories (CategoryName) VALUES
('Reapair'),
('Reapair1'),
('Reapair2')

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(50),
	Model NVARCHAR(20),
	CarYear DATETIME,
	CategoryId INT FOREIGN KEY(Id) REFERENCES Categories(Id),
	Doors INT,
	Picture VARCHAR(100),
	Condition VARCHAR(200),
	Available BIT 
)

INSERT INTO Cars (PlateNumber) VALUES 
('CA1123PHA'),
('P1123PHA'),
('A1123PHA')

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(20),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName) VALUES
('Valentin', 'Chekov'),
('Peter', 'Harrison'),
('Cocko', 'Server')

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DriverLicenceNumber INT UNIQUE NOT NULL,
	FullName NVARCHAR(10) NOT NULL,
	[Address] NVARCHAR(100),
	City NVARCHAR(50),
	ZIPCode NVARCHAR(20),
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName) VALUES
(23231123, 'Peter1'),
(232323123, 'Peter2'),
(2323423, 'Peter3')

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	EmployeeId INT FOREIGN KEY(EmployeeId) REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY(CustomerId) REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY(CarId) REFERENCES Cars(Id) NOT NULL,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME,
	EndDate DATETIME,
	TotalDays INT,
	RateApplied INT,
	TaxRate INT,
	OrderStatus INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId) VALUES 
(1, 2, 3),
(2, 3, 1),
(3, 1, 1)
