USE Movies;

CREATE DATABASE Movies;

--•	Directors 
CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors (DirectorName) VALUES
('Peter1'),
('Peter2'),
('Peter3'),
('Peter4'),
('Peter5')

--•	Genres 
CREATE TABLE Genres 
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Genres (GenreName) VALUES
('Horror'),
('Comedy'),
('Action'),
('Fantasy'),
('Sci-Fiction')

--•	Categories 
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50),
	Notes VARCHAR(MAX)
)
INSERT INTO Categories (CategoryName) VALUES
('C'),
('A'),
('B'),
('U'),
('C')

--•	Movies 
CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(20) NOT NULL,
	DirectorId INT FOREIGN KEY (Id) REFERENCES Directors(Id) NOT NULL,
	CopyrightYear DATETIME NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY(Id) REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY(Id) REFERENCES Categories(Id),
	Rating INT,
	Notes VARCHAR(Max)
)
INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length])
VALUES 
('Harry Potter 2', 2, '1/02/2009', 2),
('Harry Potter 3', 3, '1/02/2009', 2),
('Harry Potter 4', 4, '1/02/2009', 2),
('Harry Potter 5', 5, '1/02/2009', 2),
('Harry Potter 1', 1, '1/02/2009', 2)
