SELECT
	*
FROM UsersGames AS ug
	LEFT JOIN Users AS u ON u.Id = ug.UserId
	LEFT JOIN Games AS g ON g.Id = ug.GameId
u.Name = 'Pincushion flower annual';
