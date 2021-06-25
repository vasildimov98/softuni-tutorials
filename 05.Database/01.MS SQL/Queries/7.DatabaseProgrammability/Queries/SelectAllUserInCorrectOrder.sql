--4. Select all users in the current game (“Bali”) with their items.
--Display username, game name, cash and item name.
--Sort the result by username alphabetically, then by item name alphabetically. 

SELECT
	u.Username,
	g.[Name],
	ug.Cash,
	i.[Name] AS [Item Name]
FROM UserGameItems AS ugi
	JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
	JOIN Items AS i ON i.Id = ugi.ItemId
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN Games AS g ON g.Id = ug.GameId
WHERE u.Username IN ('baleremuda','loosenoise','inguinalself','buildingdeltoid','monoxidecos')
	AND g.[Name] = 'Bali'
ORDER BY u.Username ASC, i.[Name] ASC;