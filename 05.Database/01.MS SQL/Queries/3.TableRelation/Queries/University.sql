-- 06. University Database
CREATE DATABASE University;
GO

USE University;
GO

CREATE TABLE Majors 
(
	MajorID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Students 
(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID) NOT NULL
);
GO

CREATE TABLE Payments 
(
	PaymentID INT IDENTITY PRIMARY KEY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL (15,2) NOT NULL,
	StudentID INT REFERENCES Students(StudentID) NOT NULL
);
GO

CREATE TABLE Subjects 
(
	SubjectID INT IDENTITY PRIMARY KEY,
	SubjectName VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Agenda 
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID)
	CONSTRAINT PK_Student_Subjects
	PRIMARY KEY (StudentID, SubjectID)
);
GO