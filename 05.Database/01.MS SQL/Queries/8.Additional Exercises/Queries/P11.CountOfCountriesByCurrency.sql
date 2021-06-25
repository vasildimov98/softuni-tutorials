SELECT 
	crr.CurrencyCode,
	crr.[Description] AS Currency,
	COUNT(c.CountryCode) AS NumberOfCountries
FROM Currencies AS crr
	LEFT JOIN Countries AS c ON c.CurrencyCode = crr.CurrencyCode
GROUP BY crr.CurrencyCode, crr.[Description]
ORDER BY NumberOfCountries DESC, Currency ASC;