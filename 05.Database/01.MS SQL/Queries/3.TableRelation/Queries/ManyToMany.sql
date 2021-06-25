--03. Many to Many
CREATE TABLE Students 
(
	StudentID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
);

INSERT INTO Students ([Name]) VALUES
	('Mila'),                                      
	('Toni'),
	('Ron');
GO

SELECT * FROM Students;
GO;

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
);
GO

INSERT INTO Exams ([Name]) VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g');
GO

CREATE TABLE StudentsExams 
(
	StudentID INT REFERENCES Students(StudentID),
	ExamID INT REFERENCES Exams(ExamID),
	CONSTRAINT PR_Student_Exam
	PRIMARY KEY (StudentID, ExamID) 
);
GO

INSERT INTO StudentsExams (StudentID, ExamID) VALUES
	(1,	101),
	(1,	102),
	(2,	101),
	(3,	103),
	(2,	102),
	(2,	103);
GO

--SELECT * FROM StudentsExams;
--GO