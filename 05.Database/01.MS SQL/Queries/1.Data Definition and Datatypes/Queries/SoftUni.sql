CREATE DATABASE Softuni;
USE SoftUni;

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	[Name] NVARCHAR(10) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY(TownId) REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(20) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	LastName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
	HireDate DATETIME,
	Salary DECIMAL(15, 2),
	AddressId INT FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name]) VALUES 
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments ([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName,	JobTitle,DepartmentId,	HireDate,	Salary) VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013',	3500.00),
('Petar', 'Petrov', 'Petrov',	'Senior Engineer',	1,	'03/02/2004',	4000.00),
('Maria', 'Petrova', 'Ivanova',	'Intern',	5,	'08/28/2016',	525.25),
('Georgi', 'Teziev', 'Ivanov',	'CEO',	2,	'12/09/2007',	3000.00),					 
('Peter', 'Pan', 'Pan',	'Intern',	3,	'08/28/2016',	599.88)

SELECT [Name] FROM Towns
ORDER BY [NAME] ASC;
SELECT [Name] FROM Departments
ORDER BY [Name] ASC;
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;

UPDATE Employees
SET Salary += Salary * 0.1;

SELECT Salary FROM Employees;
