-- Game id of Alex
DECLARE @AlexUserGameId INT =
(
	SELECT 
		Id
	FROM UsersGames AS ug
	WHERE ug.GameId =
	(
		SELECT
			Id
		FROM Games
		WHERE [Name] = 'Edinburgh'
	)
	AND ug.UserId = 
	(
		SELECT
			Id
		FROM Users
		WHERE Username = 'Alex'
	)
);

-- Total Price
DECLARE @AlexWishItemsTotalPrice MONEY = 
(
	SELECT 
		SUM(Price)
	FROM Items
	WHERE [Name] IN('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')
);

-- CurrentGameId
DECLARE @CurrentGameId INT =
(
	SELECT 
		GameId
	FROM UsersGames
	WHERE Id = @AlexUserGameId
);

-- Insert Into Table UserGameItems
INSERT INTO UserGameItems
	SELECT 
		it.Id,
		@AlexUserGameId
	FROM Items AS it
	WHERE [Name] IN('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet');

-- Update Alex's Cash
UPDATE UsersGames
	SET Cash -= @AlexWishItemsTotalPrice
WHERE Id = @AlexUserGameId;

-- Select all users in the current game.
SELECT
	u.Username,
	g.[Name],
	ug.Cash,
	it.[Name] AS [Item Name]
FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId =  u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS it ON it.Id = ugi.ItemId
WHERE ug.GameId = @CurrentGameId
ORDER BY [Item Name] ASC;