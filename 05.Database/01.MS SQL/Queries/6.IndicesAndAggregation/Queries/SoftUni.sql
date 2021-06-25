--SoftUni
USE SoftUni;
GO

--13.Departments Total Salaries
SELECT
	DepartmentID
	,SUM(Salary) AS TotalSalary
		FROM Employees
		GROUP BY DepartmentID
		ORDER BY DepartmentID ASC;
GO

--14.Employees Minimum Salaries
SELECT
	DepartmentID
	,MIN(Salary)
		FROM Employees
		WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
		GROUP BY DepartmentID;
GO

--15.Employees Average Salaries
SELECT
	*
		INTO[EmployeesAverageSalaries]
		FROM Employees
		WHERE Salary > 30000; 
GO

DELETE FROM EmployeesAverageSalaries
WHERE ManagerID = 42;
GO

UPDATE EmployeesAverageSalaries
SET Salary += 5000
WHERE DepartmentID = 1;
GO

SELECT
	DepartmentID
	,AVG(Salary) AverageSalary
		FROM EmployeesAverageSalaries
		GROUP BY DepartmentID;
GO

--16.Employees Maximum Salaries
SELECT
	DepartmentID
	,MAX(Salary) MaxSalary
		FROM Employees
		GROUP BY DepartmentID
		HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;
GO

--17.Employees Count Salaries
SELECT COUNT(*) [Count] FROM Employees WHERE ManagerID IS NULL;
GO

--18.3rd Highest Salary
SELECT
	DepartmentID
	,Salary ThirdHighestSalary
		FROM (SELECT
				ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) [SalaryRank]
				,DepartmentID
				,Salary
					FROM Employees) sr
		WHERE SalaryRank = 3;
GO

SELECT
	DepartmentID
	,Salary
		FROM (SELECT
				ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) [SalaryRank]
				,DepartmentID
				,Salary
					FROM Employees
					GROUP BY DepartmentID, Salary) info
		WHERE SalaryRank = 3;

--19.Salary Challenge
SELECT TOP (10)
	FirstName
	,LastName
	,DepartmentID
		FROM Employees em1
		WHERE Salary > (SELECT
							AVG(Salary)
								FROM Employees em2
								WHERE em1.DepartmentID = em2.DepartmentID);
GO