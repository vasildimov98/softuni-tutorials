--Part II Geography
USE [Geography];
GO

--12. Highest Peaks in Bulgaria
SELECT
	c.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
		FROM Peaks p
		JOIN Mountains m
		ON p.MountainId = m.Id
		JOIN MountainsCountries AS mc
		ON m.Id = mc.MountainId
		JOIN Countries c
		ON mc.CountryCode = c.CountryCode
		WHERE c.CountryName IN ('Bulgaria')
		AND p.Elevation > 2835
		ORDER BY p.Elevation DESC;
GO

--13. Count Mountain Ranges
SELECT
	c.CountryCode
	,(SELECT
		COUNT(MountainId)
			FROM MountainsCountries mc
			WHERE c.CountryCode = mc.CountryCode) AS MountainRanges
		FROM Countries c
		WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria');
GO

--14. Countries with Rivers
SELECT TOP(5)
	c.CountryName
	,r.RiverName
		FROM Countries c
		LEFT JOIN CountriesRivers cr
		ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers r
		ON cr.RiverId = r.Id
		LEFT JOIN Continents co
		ON c.ContinentCode = co.ContinentCode
		WHERE co.ContinentName IN ('Africa')
		ORDER BY c.CountryName ASC;
GO

--15
SELECT
	ContinentCode
	,CurrencyCode
	,CurrencyUsage
		FROM (SELECT
				*
				,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) RankByUsage
					FROM (SELECT
							ContinentCode,
							CurrencyCode,
							COUNT(*) AS CurrencyUsage
								FROM Countries
								GROUP BY ContinentCode, CurrencyCode
								HAVING COUNT(*) > 1) cu) cr
		WHERE RankByUsage = 1;
GO

--16. Countries Without Any Mountains
SELECT 
	COUNT(*) AS [Count]
		FROM Countries c
		LEFT JOIN MountainsCountries mc
		ON c.CountryCode = mc.CountryCode
		WHERE mc.CountryCode IS NULL;
GO

--17. Highest Peak and Longest River by Country
SELECT TOP(5)
	c.CountryName
	,MAX(p.Elevation) HighestPeakElevation
	,MAX(r.Length) LongestRiverLength
		FROM Countries c
		LEFT JOIN MountainsCountries mc
		ON c.CountryCode = mc.CountryCode
		LEFT JOIN Peaks p
		ON mc.MountainId = p.MountainId
		LEFT JOIN CountriesRivers cr
		ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers r
		ON cr.RiverId = r.Id
		GROUP BY c.CountryName
		ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName ASC;
GO

--18. Highest Peak Name and Elevation by Country
SELECT TOP (5)
	rp.Country
	,CASE
		WHEN rp.PeakName IS NULL THEN '(no highest peak)'
		ELSE rp.PeakName
	END [Highest Peak Name]
	,CASE
		WHEN rp.Elevation IS NULL THEN 0
		ELSE rp.Elevation
	END [Highest Peak Elevation]
	,CASE
		WHEN rp.MountainRange IS NULL THEN '(no mountain)'
		ELSE rp.MountainRange
	END Mountain
		FROM (SELECT
				*
				,DENSE_RANK() OVER (PARTITION BY Country ORDER BY Elevation DESC) PeakRank
					FROM (SELECT 
							c.CountryName AS Country
							,p.PeakName
							,p.Elevation
							,m.MountainRange
								FROM Countries c
								LEFT JOIN MountainsCountries mc
									ON c.CountryCode = mc.CountryCode
								LEFT JOIN Mountains m
									ON mc.MountainId = m.Id
								LEFT JOIN Peaks p
									ON m.Id = p.MountainId) iq) rp
		WHERE PeakRank = 1
		ORDER BY rp.Country ASC, [Highest Peak Name] ASC;
GO