--P07.CreateTablePeople
CREATE TABLE People 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(15,2),
	[Weight] DECIMAL(15,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Gender, Birthdate) VALUES
('Pesho', 'm', '03/12/1998'),
('Pesho1', 'm', '03/12/1998'),
('Pesho2', 'm', '03/12/1998'),
('Mariya', 'f', '12/12/1998'),
('Victoria', 'f', '04/15/1998')
