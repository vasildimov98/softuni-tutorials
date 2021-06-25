USE SoftUni;
GO

--02
SELECT * FROM Departments;
GO

--03
SELECT [Name] FROM Departments;
GO

--04
SELECT 
	FirstName,
	LastName,
	Salary
		FROM Employees;
GO

--05
SELECT 
	FirstName,
	MiddleName,
	LastName
		FROM Employees;
GO

--06
SELECT
	FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
		FROM Employees;
GO

--07
SELECT DISTINCT
	Salary
		FROM Employees;
GO

--08
SELECT
	*
		FROM Employees
		WHERE JobTitle = 'Sales Representative';
GO

--09
SELECT
	FirstName,
	LastName,
	JobTitle
		FROM Employees
		WHERE Salary >= 20000
		AND	Salary <= 30000;
GO

--10
SELECT
	FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
		FROM Employees
		WHERE Salary IN (25000, 14000, 12500, 23600);
GO

--11
SELECT
	FirstName,
	LastName
		FROM Employees
		WHERE ManagerID IS NULL;
GO

--12
SELECT
	FirstName,
	LastName,
	Salary
		FROM Employees
		WHERE Salary > 50000
		ORDER BY Salary DESC;
GO

--13
SELECT TOP (5)
	FirstName,
	LastName
		FROM Employees
		ORDER BY Salary DESC;
GO

--14
SELECT 
	FirstName,
	LastName
		FROM Employees
		WHERE DepartmentID != 4;
GO

--15
SELECT
	*
		FROM Employees
		ORDER BY Salary DESC,
				FirstName ASC,
				LastName DESC,
				MiddleName ASC;
GO

--16
CREATE VIEW V_EmployeesSalaries AS
SELECT
	FirstName,
	LastName,
	Salary
		FROM Employees;
GO

--17
CREATE VIEW V_EmployeeNameJobTitle AS 
SELECT
	FirstName + ' '+ ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name],
	JobTitle AS [Job Title]
		FROM Employees;
GO

--18
SELECT DISTINCT
	JobTitle
		FROM Employees;
GO

--19
SELECT TOP (10)
	*
		FROM Projects
		ORDER BY StartDate ASC, [Name] ASC;
GO

--20
SELECT TOP (7)
	FirstName,
	LastName,
	HireDate
		FROM Employees
		ORDER BY HireDate DESC;
GO

--21
UPDATE Employees
	SET Salary *= 1.12
	WHERE DepartmentID IN (1, 2, 4, 11);

SELECT
	Salary
		FROM Employees;
GO