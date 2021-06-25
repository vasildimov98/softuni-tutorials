--Queries for SoftUni Database
USE SoftUni;
GO

--08.Employees with Three Projects
CREATE PROC usp_AssignProject(@EmloyeeId INT, @ProjectID INT)
AS
BEGIN
	BEGIN TRANSACTION;
	DECLARE @EmployeeProjectCount TINYINT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId);
	
	IF (@EmployeeProjectCount >= 3)
	BEGIN
		ROLLBACK;
		RAISERROR('The employee has too many projects!', 16, 2);
		RETURN
	END

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
	VALUES (@EmloyeeId, @ProjectID);
	COMMIT;
END
GO

--09.Delete Employees
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT REFERENCES Departments(DepartmentId) NOT NULL,
	Salary DECIMAL(15,4) NOT NULL
);
GO

CREATE TRIGGER tr_InsertInfoAboutDeletedEmployees
ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees
	SELECT 
		FirstName
		,LastName
		,MiddleName
		,JobTitle
		,DepartmentID
		,Salary
	FROM deleted
END
GO
