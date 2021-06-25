-- 2. Add bonus cash of 50000 to users: baleremuda, loosenoise, inguinalself, buildingdeltoid, monoxidecos in the game “Bali”.

SELECT
	ug.Id,
	u.Username,
	g.[Name],
	ug.Cash
FROM UsersGames AS ug
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN Games AS g ON g.Id = ug.GameId
WHERE u.Username IN ('baleremuda','loosenoise','inguinalself','buildingdeltoid','monoxidecos')
	AND g.[Name] = 'Bali';

UPDATE ug
	SET ug.Cash += 50000
FROM UsersGames AS ug
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN Games AS g ON g.Id = ug.GameId
WHERE u.Username IN ('baleremuda','loosenoise','inguinalself','buildingdeltoid','monoxidecos')
	AND g.[Name] = 'Bali';

SELECT Id FROM Games WHERE [Name] = 'Bali'