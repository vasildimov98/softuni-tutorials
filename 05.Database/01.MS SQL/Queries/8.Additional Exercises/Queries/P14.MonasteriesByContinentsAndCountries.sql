-- Change country name 'Myanmar' to 'Burma'
UPDATE Countries
	SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar';

-- Add new monastery Name - 'Hanga Abbey' and Country Tanzania
INSERT INTO Monasteries ([Name], CountryCode)
VALUES ('Hanga Abbey',
(
	SELECT CountryCode
	FROM Countries
	WHERE CountryName = 'Tanzania'
));

-- Add new monastery Name - 'Myin-Tin-Daik' and Country Myanmar
INSERT INTO Monasteries ([Name], CountryCode)
VALUES ('Myin-Tin-Daik',
(
	SELECT CountryCode
	FROM Countries
	WHERE CountryName = 'Myanmar'
));

-- Display final result
SELECT
	ct.ContinentName,
	co.CountryName,
	COUNT(m.Id) AS MonasteriesCount
FROM Continents AS ct
	LEFT JOIN Countries AS co ON co.ContinentCode = ct.ContinentCode AND co.IsDeleted = 0
	LEFT JOIN Monasteries AS m ON m.CountryCode = co.CountryCode
GROUP BY ct.ContinentName, co.CountryName
ORDER BY MonasteriesCount DESC, co.CountryName ASC;
