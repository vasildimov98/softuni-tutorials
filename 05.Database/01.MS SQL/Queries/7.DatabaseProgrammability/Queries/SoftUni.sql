--I. Queries for SoftUni Database

USE SoftUni;
GO

--01.Employees with Salary Above 35000

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT
		FirstName
		,LastName
	FROM Employees
	WHERE Salary > 35000;
END
GO

EXEC usp_GetEmployeesSalaryAbove35000;

--02.Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@Salary DECIMAL(18, 4))
AS
BEGIN
	SELECT
		FirstName [First Name]
		,LastName [Last Name]
	FROM Employees
	WHERE Salary >= @Salary
END
GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100;

--03.Town Names Starting With
CREATE PROC usp_GetTownsStartingWith @String VARCHAR(20)
AS
BEGIN 
	SELECT
		[Name] Town
	FROM Towns
	WHERE [Name] LIKE @String + '%';
END
GO

EXEC usp_GetTownsStartingWith 'b'
GO 

--04.Employees from Town
CREATE PROC usp_GetEmployeesFromTown @TownName VARCHAR(50)
AS
BEGIN
	SELECT
		e.FirstName
		,e.LastName
	FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
	WHERE t.[Name] = @TownName
END
GO

EXEC usp_GetEmployeesFromTown 'Sofia'; 

--05.Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18, 4))
RETURNS VARCHAR(7)
AS
BEGIN 
	DECLARE @SalaryLevel VARCHAR(7);

	IF @Salary < 30000
		SET @SalaryLevel = 'Low';
	ELSE IF @Salary <= 50000
		SET @SalaryLevel = 'Average';
	ELSE SET @SalaryLevel = 'High';

	RETURN @SalaryLevel;
END
GO

SELECT
	Salary
	,dbo.ufn_GetSalaryLevel(Salary)
FROM Employees;
GO

--06.Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel @SalaryLevel VARCHAR(7)
AS
BEGIN
	SELECT
		FirstName
		,LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel;
END
GO

EXEC usp_EmployeesBySalaryLevel 'High';

--07.Define Function
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(100), @Word VARCHAR(100))
RETURNS BIT
AS
BEGIN
	DECLARE @Result BIT = 1;
	DECLARE @CurrWordLen INT = 1;

	WHILE (@CurrWordLen <= LEN(@Word))
	BEGIN
		DECLARE @CurrLetter VARCHAR(1) = SUBSTRING(@Word, @CurrWordLen, 1);

		IF CHARINDEX(@CurrLetter, @SetOfLetters) = 0
		BEGIN
			SET @Result = 0;
			BREAK;
		END

		SET @CurrWordLen += 1;
	END

	RETURN @Result;
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
	,dbo.ufn_IsWordComprised('oistmiahf', 'halves')
	,dbo.ufn_IsWordComprised('bobr', 'Rob')
	,dbo.ufn_IsWordComprised('pppp', 'Guy');
GO

--08.Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
BEGIN 
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId);
	
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId);

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL;

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

	DELETE FROM Employees
	WHERE DepartmentID = @DepartmentId;

	DELETE FROM Departments
	WHERE DepartmentID = @DepartmentId;

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @DepartmentId;
END
GO

EXEC usp_DeleteEmployeesFromDepartment 1;
GO

SELECT * FROM Employees WHERE DepartmentID = 1;