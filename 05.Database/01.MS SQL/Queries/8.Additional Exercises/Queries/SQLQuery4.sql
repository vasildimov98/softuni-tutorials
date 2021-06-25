SELECT
	u.Username,
	g.[Name] AS Game, 
	MAX(ch.[Name]) AS [Character],
	SUM(itst.Strength) + MAX(gtst.Strength) + MAX(chst.Strength) AS Strength,
	SUM(itst.Defence) + MAX(gtst.Defence) + MAX(chst.Defence) AS Defence,
	SUM(itst.Speed) + MAX(gtst.Speed) + MAX(chst.Speed) AS Speed,
	SUM(itst.Mind) + MAX(gtst.Mind) + MAX(chst.Mind) AS Mind,
	SUM(itst.Luck) + MAX(gtst.Luck) + MAX(chst.Luck) AS Luck
FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
	JOIN [Statistics] AS gtst ON gtst.Id = gt.BonusStatsId
	JOIN Characters AS ch ON ch.Id = ug.CharacterId
	JOIN [Statistics] AS chst ON chst.Id = ch.StatisticId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS it ON it.Id = ugi.ItemId
	JOIN [Statistics] AS itst ON itst.Id = it.StatisticId
GROUP BY u.Username, g.[Name]
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC;
	
