--Part III – Queries for Diablo Database
USE Diablo;
GO

--14
SELECT TOP (50)
	[Name],
	FORMAT([Start], 'yyyy-MM-dd') AS [Start]
		FROM Games
		WHERE YEAR([Start]) IN ('2011', '2012')
		ORDER BY [Start] ASC;
GO

--15
SELECT
	Username,
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
		FROM Users
		ORDER BY [Email Provider] ASC, Username ASC;
GO

--16
SELECT 
	Username,
	IpAddress
		FROM Users
		WHERE IpAddress LIKE '___.1%.%.___'
		ORDER BY Username;
GO

--17
SELECT 
	[Name] AS Game
	,CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day]
	,CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration >= 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS Duration
		FROM Games
		ORDER BY [Name] ASC, Duration ASC, [Part of the Day] ASC;
GO