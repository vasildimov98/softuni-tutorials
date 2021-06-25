-- Create a table
CREATE TABLE Monasteries
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(100),
	CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode) 
);

-- Insert values into tables
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

-- Add new column to countries
ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0 NOT NULL

-- Delete all countries with count of rivers more than 3
UPDATE Countries
	SET IsDeleted = 1
WHERE CountryCode IN
(
	SELECT 
		CountryCode
	FROM CountriesRivers
	GROUP BY CountryCode
	HAVING COUNT(RiverId) > 3
);

-- Display all monastery with countries without the deleted one
SELECT
	m.[Name] AS Monastery,
	c.CountryName AS Country
FROM Monasteries AS m
	JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY Monastery ASC;


