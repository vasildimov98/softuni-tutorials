CREATE DATABASE CarRental;

USE CarRental;

CREATE TABLE Categories (
      Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
      CategoryName VARCHAR(5) NOT NULL,
      DailyRate NVARCHAR(50),
      WeeklyRate INT,
      MonthlyRate INT,
	  WeekendRate INT
);

CREATE TABLE Cars (
      Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	  PlateNumber VARCHAR(50) NOT NULL UNIQUE, 
	  Manufacturer VARCHAR(15), 
	  Model VARCHAR(15),
	  CarYear DATE,
	  CategoryId INT FOREIGN KEY(Id) REFERENCES Categories(Id),
	  Doors INT,
	  Picture IMAGE,
	  Condition VARCHAR(MAX),
	  Available CHAR(5) 
	  CHECK(Available='true' OR Available='false')
);


CREATE TABLE Employees (
      Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	  FirstName NVARCHAR(50) NOT NULL,
	  LastName NVARCHAR(50) NOT NULL,
	  Title NVARCHAR(30),
	  Notes NVARCHAR(MAX)
);

CREATE TABLE Customers (
     Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	 DriverLicenceNumber INT NOT NULL, 
	 FullName NVARCHAR(50),
	 [Address] NVARCHAR(80),
	 City NVARCHAR(20),
	 ZIPCode INT,
	 Notes NVARCHAR(MAX)
);

CREATE TABLE RentalOrders (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT NOT NULL FOREIGN KEY(Id) REFERENCES Employees(Id),
	CustomerId INT NULL FOREIGN KEY(Id) REFERENCES Customers(Id),
	CarId INT NOT NULL FOREIGN KEY(Id) REFERENCES Cars(Id),
	TankLevel DECIMAL(5,2),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE,
	EndDate DATE,
	TotalDays INT,
	RateApplied VARCHAR(12),
	TaxRate DECIMAL(5,2),
	OrderStatus VARCHAR(50),
	Notes NVARCHAR(MAX)
);


INSERT INTO Categories (CategoryName)
                 VALUES 
                        ('B1'),
                        ('B'),
                        ('A1');

INSERT INTO Cars (PlateNumber, CategoryId)
          VALUES 
		         (13241251, 1),
		         (41241441, 2),
		         (4124512515, 3);

INSERT INTO Employees (FirstName, LastName)
               VALUES 
			          ('Ivan', 'Petrov'),
			          ('Petar', 'Petrovic'),
			          ('Sonya', 'Doreva');

INSERT INTO Customers (DriverLicenceNumber)
                VALUES 
			          (123456789),
			          (123123123),
			          (134412514);

INSERT INTO RentalOrders (EmployeeId, CarId)
                  VALUES 
                          (1, 3),
                          (3, 1),
                          (2, 1);

SELECT * FROM RentalOrders;