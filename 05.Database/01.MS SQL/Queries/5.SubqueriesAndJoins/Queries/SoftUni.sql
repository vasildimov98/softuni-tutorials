-- Part I - SoftUni Database

USE SoftUni;
GO

--01. Employee Address
SELECT TOP(5)
	e.EmployeeID
	,e.JobTitle
	,e.AddressID
	,a.AddressText
		FROM Employees e
		JOIN Addresses a 
		ON e.AddressID = a.AddressID
		ORDER BY e.AddressID ASC;
GO

--02. Addresses with Towns
SELECT TOP(50)
	e.FirstName
	,e.LastName
	,t.[Name] Town
	,a.AddressText
		FROM Employees e
		JOIN Addresses a
		ON e.AddressID = a.AddressID
		JOIN Towns t
		ON a.TownID = t.TownID
		ORDER BY e.FirstName ASC, e.LastName ASC;
GO

--03. Sales Employee
SELECT
	e.EmployeeID
	,e.FirstName
	,e.LastName
	,d.[Name] DepartmentName
		FROM Employees e
		LEFT JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
		WHERE d.[Name] IN ('Sales')
		ORDER BY e.EmployeeID;
GO

--04. Employee Departments
SELECT TOP(5)
	e.EmployeeID
	,e.FirstName
	,e.Salary
	,d.[Name] DepartmentName
		FROM Employees e
		JOIN Departments d 
		ON d.DepartmentID = e.DepartmentID
		WHERE e.Salary > 15000
		ORDER BY d.DepartmentID ASC;
GO

--05. Employees Without Project
SELECT TOP(3)
	e.EmployeeID,
	e.FirstName
		FROM EmployeesProjects ep
		RIGHT JOIN Employees e
		ON ep.EmployeeID = e.EmployeeID
		WHERE ep.EmployeeID IS NULL
		ORDER BY e.EmployeeID ASC;
GO

--06. Employees Hired After
SELECT
	e.FirstName
	,e.LastName
	,e.HireDate
	,d.[Name] DeptName
		FROM Employees e
		LEFT JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
		WHERE e.HireDate > '1999-01-01'
		AND d.[Name] IN ('Sales', 'Finance' )
		ORDER BY e.HireDate ASC;
GO

--07. Employees with Project
SELECT TOP(5)
	e.EmployeeID
	,e.FirstName
	,p.[Name] ProjectName
		FROM EmployeesProjects ep
		JOIN Employees e
		ON ep.EmployeeID = e.EmployeeID
		JOIN Projects p
		ON ep.ProjectID = p.ProjectID
		WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
		ORDER BY e.EmployeeID;
GO

--08. Employee 24
SELECT
	e.EmployeeID
	,e.FirstName
	,CASE
		WHEN p.StartDate < '2005' THEN p.[Name]
		ELSE NULL
	END AS ProjectName
		FROM EmployeesProjects ep
		JOIN Employees e
		ON ep.EmployeeID = e.EmployeeID
		JOIN Projects p
		ON ep.ProjectID = p.ProjectID
		WHERE e.EmployeeID = 24;
GO

--09. Employee Manager
SELECT 
	e.EmployeeID
	,e.FirstName
	,m.EmployeeID ManagerID
	,m.FirstName ManagerName
		FROM Employees e
		JOIN Employees m
		ON e.ManagerID = m.EmployeeID
		WHERE e.ManagerID IN (3, 7)
		ORDER BY e.EmployeeID ASC;
GO

--10. Employee Summary
SELECT TOP(50)
	e.EmployeeID
	,CONCAT(e.FirstName, ' ', e.LastName) EmployeeName
	,CONCAT(m.FirstName, ' ', m.LastName) ManagerName
	,d.[Name] DepartmentName
		FROM Employees e
		JOIN Employees m
		ON e.ManagerID = m.EmployeeID
		JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
		ORDER BY e.EmployeeID;
GO

--11. Min Average Salary
SELECT TOP(1)
	(SELECT
		AVG(Salary)
			FROM Employees
			WHERE DepartmentID = d.DepartmentID) AS MinAverageSalary
		FROM Departments d
		ORDER BY MinAverageSalary;
GO