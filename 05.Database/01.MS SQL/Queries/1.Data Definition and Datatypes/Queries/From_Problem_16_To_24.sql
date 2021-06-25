CREATE DATABASE SoftUni;

USE SoftUni;

CREATE TABLE Towns (
    Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
);


INSERT INTO Towns ([Name])
           VALUES 
		          ('Sofia'),
				  ('Plovdiv'),
				  ('Varna'),
				  ('Burgas'); 

CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY(Id) REFERENCES Towns(Id)
);


INSERT INTO Addresses (AddressText)
           VALUES 
		          ('Sofia'),
				  ('Plovdiv'),
				  ('Varna'),
				  ('Burgas'); 


CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL
);

INSERT INTO Departments ([Name])
               VALUES
					    ('Engineering'),
						('Sales'),
						('Marketing'),
						('Software Development'),
						('Quality Assurance');

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId NVARCHAR(50) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	AddressId NVARCHAR(100)
);

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
               VALUES
			          ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 'Software Development', '02/01/2013', 3500.00),
			          ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 'Engineering', '03/02/2004', 4000.00),
			          ('Maria', 'Petrova', 'Ivanova', 'Intern', 'Quality Assurance', '08/28/2016', 525.25),
			          ('Georgi', 'Teziev', 'Ivanov', 'CEO', 'Sales', '12/09/2007', 3000.00),
			          ('Peter', 'Pan', 'Pan', 'Intern', 'Marketing', '08/28/2016', 599.88);
                 


SELECT [Name] FROM Towns
ORDER BY [Name] ASC;

SELECT [Name] FROM Departments
ORDER BY [Name] ASC;

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;

UPDATE Employees SET Salary += Salary* 0.1;
SELECT Salary FROM Employees

DROP TABLE Employees;

USE Hotel;

INSERT INTO Payments (AccountNumber, TaxRate)
                VALUES
				     (31312412,10.00),
				     (3123124,20.00),
				     (12445145125, 9);

UPDATE Payments SET TaxAmount -= TaxAmount * 0.1;
SELECT TaxRate FROM  Payments;

TRUNCATE TABLE Occupancies;