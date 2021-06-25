SELECT 
	it.[Name],
	it.Price,
	it.MinLevel,
	st.Strength,
	st.Defence,
	st.Speed,
	st.Luck,
	st.Mind
FROM Items AS it
	JOIN [Statistics] AS st ON st.Id = it.StatisticId
WHERE 
	st.Mind > (SELECT AVG(Mind) FROM [Statistics]) AND
	st.Luck > (SELECT AVG(Luck) FROM [Statistics]) AND
	st.Speed > (SELECT AVG(Speed) FROM [Statistics]) 
ORDER BY it.[Name];