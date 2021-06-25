CREATE DATABASE Movies;

USE Movies;

CREATE TABLE Directors (
   Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
   DirectorName NVARCHAR(50) NOT NULL,
   Notes NVARCHAR(MAX) NULL
);

CREATE TABLE Genres (
   Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
   GerneName NVARCHAR(50) NOT NULL,
   Notes NVARCHAR(MAX) NULL
);

CREATE TABLE Categories (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CategoryName CHAR(3) NOT NULL,
	Notes NVARCHAR(MAX) NULL
);

CREATE TABLE Movies (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL FOREIGN KEY(Id) REFERENCES Directors(Id),
	CopyrightYear DATE NULL,
	[Length] DECIMAL(5,2) NOT NULL,
	GenreId INT NOT NULL FOREIGN KEY(Id) REFERENCES Genres(Id),
	CategoryId INT NOT NULL FOREIGN KEY(Id) REFERENCES Categories(Id),
	Rating INT NULL,
	Notes NVARCHAR(MAX) NULL
);

INSERT INTO Directors (DirectorName, Notes)
                VALUES
				       ('Mike', 'Todo list'),
					   ('Pesho', NULL),
					   ('Dragan', NULL),
					   ('Misho', NULL),
					   ('Petkan', NULL);


INSERT INTO Genres (GerneName, Notes)
                VALUES
				       ('Horror', 'Todo list'),
					   ('Sitcom', NULL),
					   ('Stand-up comedy', NULL),
					   ('Action', NULL),
					   ('Sci-fi', 'Star Wars');
SELECT * FROM Genres;

INSERT INTO Categories (CategoryName, Notes)
                VALUES
				       ('N/A', 'Todo list'),
					   ('A', NULL),
					   ('C*', NULL),
					   ('D', NULL),
					   ('X', NULL);



INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
            VALUES 
			        ('Star Wars', 1, NULL, 2.2, 5, 4, 9, NULL),    
			        ('Star Treck', 2, NULL, 2.2, 5, 4, 6, NULL),    
			        ('Gabriel Iglesias', 3, NULL, 2.2, 3, 4, 9, NULL),    
			        ('007', 4, NULL, 2.2, 5, 4, 9, NULL),    
			        ('Star Wars', 5, NULL, 2.2, 5, 4, 9, NULL);


SELECT * FROM Directors;
SELECT * FROM Categories;
SELECT * FROM Movies;



