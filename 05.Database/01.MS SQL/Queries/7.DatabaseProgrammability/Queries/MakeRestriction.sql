CREATE OR ALTER TRIGGER tr_RestrictionsToItems
ON UserGameItems INSTEAD OF INSERT
AS
BEGIN
	DECLARE @itemId INT = (SELECT ItemId FROM inserted);
	DECLARE @userGameId INT = (SELECT UserGameId FROM inserted);

	DECLARE @itemLevel INT = (SELECT MinLevel From Items WHERE Id = @itemId);
	DECLARE @userGameLevel INT = (SELECT [Level] From UsersGames WHERE Id = @userGameId);

	IF (@userGameLevel >= @itemLevel)
	BEGIN
		INSERT INTO UserGameItems(ItemId, UserGameId)
		VALUES (@itemId, @userGameId)
	END;
END;

SELECT * FROM Items;
SELECT * FROM UsersGames;

SELECT * FROM UserGameItems WHERE UserGameId = 2 AND ItemId = 4;

INSERT INTO UserGameItems (ItemId, UserGameId)
VALUES (4,2)