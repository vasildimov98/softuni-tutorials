SELECT
	u.Username,
	g.[Name] AS Game,
	COUNT(ugi.ItemId) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM UserGameItems AS ugi
	JOIN Items AS i ON i.Id = ugi.ItemId
	JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN Games AS g ON g.Id = ug.GameId
GROUP BY g.[Name], u.Username
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC;