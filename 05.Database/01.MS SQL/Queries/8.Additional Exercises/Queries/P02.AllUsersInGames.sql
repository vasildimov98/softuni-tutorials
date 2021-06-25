SELECT
	g.[Name] AS Game,
	gt.[Name] AS [Game Type],
	u.Username,
	[Level],
	Cash,
	ch.[Name] AS [Character]
FROM UsersGames AS ug
	 JOIN Users AS u ON u.Id = ug.UserId
	 JOIN Games AS g ON g.Id = ug.GameId
	 JOIN Characters AS ch ON ch.Id = ug.CharacterId
	 JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
ORDER BY [Level] DESC, u.Username ASC, Game ASC;