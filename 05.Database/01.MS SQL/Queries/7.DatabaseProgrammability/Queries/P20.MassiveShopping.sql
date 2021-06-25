DECLARE @username VARCHAR(50) = 'Stamat';
DECLARE @gameName VARCHAR(50) = 'Safflower';
DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = @username);
DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = @gameName);
DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId);
DECLARE @userMoney MONEY = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
DECLARE @firstItemsPrice MONEY = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12);
DECLARE @secondItemsPrice MONEY = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21);

BEGIN TRANSACTION
IF (@userMoney >= @firstItemsPrice)
BEGIN
	UPDATE UsersGames
		SET Cash -= @firstItemsPrice
	WHERE Id = @userGameId;

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT i.Id, @userGameId
	FROM Items AS i
	WHERE i.Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)
	COMMIT;
END;
ELSE
BEGIN
	ROLLBACK;
END;

SET @userMoney = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);

BEGIN TRANSACTION
IF (@userMoney >= @secondItemsPrice)
BEGIN
	UPDATE UsersGames
		SET Cash -= @secondItemsPrice
	WHERE Id = @userGameId;

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT i.Id, @userGameId
	FROM Items AS i
	WHERE i.Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)
	COMMIT;
END;
ELSE
BEGIN
	ROLLBACK;
END;

SELECT
	[Name] AS [Item Name]
FROM Items
WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @userGameId)
ORDER BY [Item Name] ASC;





