--04. Self-Referencing
CREATE TABLE Teachers 
(
	TeacherID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	ManagerID INT REFERENCES Teachers(TeacherID)
);
GO

INSERT INTO Teachers ([Name], ManagerID) VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted',	105),
	('Mark', 101),
	('Greta', 101);
GO

SELECT * FROM Teachers;