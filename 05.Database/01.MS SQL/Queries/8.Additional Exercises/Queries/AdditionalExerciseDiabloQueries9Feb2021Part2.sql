--PART II – Queries for Geography Database
USE [Geography];
GO

--Problem 08.Peaks and Mountains
SELECT
	p.PeakName
	,m.MountainRange Mountain
	,p.Elevation
FROM Peaks p
JOIN Mountains m
	ON p.MountainId = m.Id
ORDER BY p.Elevation DESC
GO

--Problem 09.Peaks with Their Mountain, Country and Continent
SELECT
	p.PeakName
	,m.MountainRange Mountain
	,c.CountryName
	,co.ContinentName
FROM Peaks p
JOIN Mountains m
	ON p.MountainId = m.Id
JOIN MountainsCountries mc
	ON m.Id = mc.MountainId
JOIN Countries c
	ON mc.CountryCode = c.CountryCode
JOIN Continents co
	ON c.ContinentCode = co.ContinentCode
ORDER BY p.PeakName ASC, c.CountryName ASC;
GO

--Problem 10.Rivers by Country
SELECT 
	c.CountryName
	,co.ContinentName
	,COUNT(r.Id) RiversCount
	,CASE 
		WHEN SUM(r.[Length]) IS NULL THEN 0
		ELSE SUM(r.[Length])
	END AS TotalLength
FROM Countries c
LEFT JOIN Continents co
	ON c.ContinentCode = co.ContinentCode
LEFT JOIN CountriesRivers cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r
	ON cr.RiverId = r.Id
GROUP BY c.CountryName, co.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName ASC;
GO

--Problem 11.Count of Countries by Currency
SELECT 
	cur.CurrencyCode 
	,cur.[Description] Currency
	,COUNT(c.CountryCode) NumberOfCountries
FROM Countries c
RIGHT JOIN Currencies cur
	ON c.CurrencyCode = cur.CurrencyCode
GROUP BY cur.CurrencyCode, cur.[Description]
ORDER BY NumberOfCountries DESC, Currency ASC;
GO

--Problem 12.Population and Area by Continent
SELECT
	con.ContinentName 
	,SUM(c.AreaInSqKm) CountriesArea
	,SUM(CAST(c.[Population] AS BIGINT)) CountriesPopulation
FROM Countries c
JOIN Continents con
	ON c.ContinentCode = con.ContinentCode
GROUP BY con.ContinentName
ORDER BY CountriesPopulation DESC;
GO

--Problem 13.Monasteries by Country
CREATE TABLE Monasteries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	CountryCode CHAR(2) REFERENCES Countries(CountryCode)
);
GO

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
('Sümela Monastery', 'TR');
GO

ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0 NOT NULL;
GO

UPDATE Countries
	SET IsDeleted = 1
WHERE CountryCode IN (SELECT 
						CountryCode
					FROM CountriesRivers
					GROUP BY CountryCode
					HAVING COUNT(RiverId) > 3)
GO

SELECT
	m.[Name] Monastery
	,c.CountryName Country
FROM Monasteries m
JOIN Countries c
	ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY Monastery ASC;
GO

--Problem 14.Monasteries by Continents and Countries
--1. Write and execute a SQL command that changes the country named "Myanmar" to its other name "Burma".
UPDATE Countries
	SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar';
GO

--2. Add a new monastery holding the following information: Name="Hanga Abbey", Country="Tanzania".
INSERT INTO Monasteries ([Name], CountryCode)
SELECT 
	'Hanga Abbey'
	,CountryCode FROM Countries WHERE CountryName = 'Tanzania';
GO

--3. Add a new monastery holding the following information: Name="Myin-Tin-Daik", Country="Myanmar".
INSERT INTO Monasteries ([Name], CountryCode)
SELECT 
	'Myin-Tin-Daik'
	,CountryCode FROM Countries WHERE CountryName = 'Myanmar';
GO

--4. Find the count of monasteries for each continent and not deleted country. Display the continent name, the country name and the count of monasteries. Include also the countries with 0 monasteries. Sort the results by monasteries count (from largest to lowest), then by country name alphabetically. Name the columns exactly like in the table below.
SELECT
	con.ContinentName
	,c.CountryName
	,COUNT(m.Id) MonasteriesCount
FROM Monasteries m
RIGHT JOIN Countries c
	ON m.CountryCode = c.CountryCode
LEFT JOIN Continents con
	ON c.ContinentCode = con.ContinentCode
WHERE c.IsDeleted = 0
GROUP BY con.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, CountryName ASC;
GO

SELECT  * FROM Countries WHERE CountryName = 'Myanmar';