CREATE OR ALTER PROC usp_BuyItem (@userGameId INT, @itemId INT, @gameId INT)
AS
BEGIN
BEGIN TRANSACTION
	DECLARE @isItemInDatabase INT = (SELECT COUNT(*) FROM Items WHERE Id = @itemId);

	IF (@isItemInDatabase != 1)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid item id!', 1;
	END;

	DECLARE @userGameCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @userGameId AND GameId = @gameId);
	DECLARE @itemPrice MONEY = (SELECT Price FROM Items WHERE Id = @itemId);

	IF (@userGameCash < @itemPrice)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Not enough money to buy!', 1;
	END;

	UPDATE UsersGames
		SET Cash -= @itemPrice
	WHERE Id = @userGameId AND GameId = @gameId;

	INSERT INTO UserGameItems (ItemId, UserGameId)
	VALUES (@userGameId, @itemId)
COMMIT;
END;

GO 




