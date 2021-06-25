CREATE DATABASE Minions

CREATE TABLE Minions (
   id int PRIMARY KEY NOT NULL,
   [Name] nvarchar(50) NOT NULL,
   Age int 
);

CREATE TABLE Towns (
    id int PRIMARY KEY NOT NULL,
	[Name] nvarchar(50) NOT NULL
);

ALTER TABLE Minions 
ADD TownId int NOT NULL,
FOREIGN KEY (TownId) REFERENCES Towns(id); 


INSERT INTO Towns (Id, [Name])
     VALUES
	       (1, 'Sofia'),
		   (2, 'Plovdiv'),
		   (3, 'Varna');

INSERT INTO Minions (id, [Name], Age, TownId)
       VALUES 
	         (1, 'Kevin', 22, 1),	        
			 (2, 'Bob', 15, 3),
			 (3, 'Steward', NULL, 2);

SELECT * FROM Minions;

TRUNCATE TABLE Minions; 

DROP TABLE Minions;
DROP TABLE Towns;