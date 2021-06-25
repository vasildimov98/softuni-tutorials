--Queries for Diablo Database
USE Diablo;
GO

--06.Trigger

--1.Insert trigger
CREATE TRIGGER tr_BuyOnlyAllowedItems
ON UserGameItems INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO UserGameItems(ItemId, UserGameId)
	SELECT
		ItemId,
		UserGameId
	FROM inserted ins
	JOIN Items i
		ON ins.ItemId = i.Id
	JOIN UsersGames ug
		ON ins.UserGameId = ug.Id
	WHERE ug.[Level] >= i.MinLevel;
END
GO

INSERT INTO UserGameItems (ItemId, UserGameId) VALUES (154, 2);
SELECT @@ROWCOUNT;
GO

--2.Add Bonus Cash
UPDATE UsersGames
	SET Cash += 50000 
WHERE Id IN (SELECT
				ug.Id
			FROM UsersGames ug
			JOIN Users u
				ON ug.UserId = u.Id
			JOIN Games g
				ON ug.GameId = g.Id
			WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
				AND g.[Name] = 'Bali');
GO

--3. Buy Items
CREATE PROC usp_BuyItems (@ItemId INT, @UserGameId INT, @GameId INT)
AS
BEGIN
BEGIN TRANSACTION;
	DECLARE @DoesItemExists BIT = (SELECT COUNT(*) FROM Items WHERE Id = @ItemId);

	IF (@DoesItemExists = 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Item doesn''t not exists!', 1;
	END

	DECLARE @UserCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId AND GameId = @GameId);
	DECLARE @ItemPrice MONEY = (SELECT Price FROM Items WHERE Id = @ItemId);

	IF (@UserCash < @ItemPrice)
	BEGIN
		ROLLBACK;
		THROW 50002, 'User does not have enough money!', 2;
	END 

	UPDATE UsersGames
		SET Cash -= @ItemPrice
	WHERE Id = @UserGameId AND GameId = @GameId;

	INSERT INTO UserGameItems (ItemId, UserGameId)
	VALUES (@ItemId, @UserGameId);
COMMIT;
END;
GO

DECLARE @FirstGameUserId INT = (SELECT
								ug.Id
							FROM UsersGames ug
							JOIN Users u
								ON ug.UserId = u.Id
							JOIN Games g
								ON ug.GameId = g.Id
							WHERE u.Username = 'baleremuda'
								AND g.[Name] = 'Bali');

DECLARE @SecondGameUserId INT = (SELECT
								ug.Id
							FROM UsersGames ug
							JOIN Users u
								ON ug.UserId = u.Id
							JOIN Games g
								ON ug.GameId = g.Id
							WHERE u.Username = 'loosenoise'
								AND g.[Name] = 'Bali');

DECLARE @ThirdGameUserId INT = (SELECT
								ug.Id
							FROM UsersGames ug
							JOIN Users u
								ON ug.UserId = u.Id
							JOIN Games g
								ON ug.GameId = g.Id
							WHERE u.Username = 'inguinalself'
								AND g.[Name] = 'Bali');

DECLARE @FourthGameUserId INT = (SELECT
								ug.Id
							FROM UsersGames ug
							JOIN Users u
								ON ug.UserId = u.Id
							JOIN Games g
								ON ug.GameId = g.Id
							WHERE u.Username = 'buildingdeltoid'
								AND g.[Name] = 'Bali');

DECLARE @FifthGameUserId INT = (SELECT
								ug.Id
							FROM UsersGames ug
							JOIN Users u
								ON ug.UserId = u.Id
							JOIN Games g
								ON ug.GameId = g.Id
							WHERE u.Username = 'monoxidecos'
								AND g.[Name] = 'Bali');

DECLARE @GameId INT = (SELECT Id FROM Games WHERE [Name] = 'Bali');

DECLARE @FirstCurrItemStartId INT = 251;
DECLARE @FirstItemEndId INT = 299;

WHILE (@FirstCurrItemStartId <= @FirstItemEndId)
BEGIN
	EXEC usp_BuyItems @FirstCurrItemStartId, @FirstGameUserId, @GameId;
	EXEC usp_BuyItems @FirstCurrItemStartId, @SecondGameUserId, @GameId;
	EXEC usp_BuyItems @FirstCurrItemStartId, @ThirdGameUserId, @GameId;
	EXEC usp_BuyItems @FirstCurrItemStartId, @FourthGameUserId, @GameId;
	EXEC usp_BuyItems @FirstCurrItemStartId, @FifthGameUserId, @GameId;

	SET @FirstCurrItemStartId += 1;
END

DECLARE @SecondCurrItemStartId INT = 501;
DECLARE @SecondItemEndId INT = 539;

WHILE (@SecondCurrItemStartId <= @SecondItemEndId)
BEGIN
	EXEC usp_BuyItems @SecondCurrItemStartId, @FirstGameUserId, @GameId;
	EXEC usp_BuyItems @SecondCurrItemStartId, @SecondGameUserId, @GameId;
	EXEC usp_BuyItems @SecondCurrItemStartId, @ThirdGameUserId, @GameId;
	EXEC usp_BuyItems @SecondCurrItemStartId, @FourthGameUserId, @GameId;
	EXEC usp_BuyItems @SecondCurrItemStartId, @FifthGameUserId, @GameId;

	SET @SecondCurrItemStartId += 1;
END
GO
--4. Select all user in Bali game

SELECT
	u.Username
	,g.[Name]
	,ug.Cash
	,i.[Name] [Item Name]
FROM UsersGames ug
JOIN Users u
	ON ug.UserId = u.Id
JOIN Games g
	ON ug.GameId = g.Id
JOIN UserGameItems ugi
	ON ug.Id = ugi.UserGameId
JOIN Items i
	ON ugi.ItemId = i.Id
WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
	AND g.[Name] = 'Bali'
ORDER BY u.Username ASC, i.[Name] ASC;
GO

--07. Massive Shopping
DECLARE @Username CHAR(6) = 'Stamat';
DECLARE @GameName CHAR(9) = 'Safflower';
DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @Username);
DECLARE @GameId INT = (SELECT Id FROM Games WHERE [Name] = @GameName);
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId);
DECLARE @UserGameCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId);
DECLARE @FirstSetOfItemsPrice MONEY = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12);
DECLARE @SecondSetOfItemsPrice MONEY = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21);

BEGIN TRANSACTION
IF (@UserGameCash >= @FirstSetOfItemsPrice)
BEGIN 
	UPDATE UsersGames
		SET Cash -= @FirstSetOfItemsPrice
	WHERE Id = @UserGameId;

	INSERT INTO UserGameItems (ItemId, UserGameId) 
	SELECT 
		Id
		,@UserGameId
	FROM Items
	WHERE Id IN (SELECT Id WHERE MinLevel BETWEEN 11 AND 12);
	COMMIT;
END
ELSE
BEGIN
	ROLLBACK;
END

SET @UserGameCash = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId);

BEGIN TRANSACTION
IF (@UserGameCash >= @SecondSetOfItemsPrice)
BEGIN 
	UPDATE UsersGames
		SET Cash -= @SecondSetOfItemsPrice
	WHERE Id = @UserGameId;

	INSERT INTO UserGameItems (ItemId, UserGameId) 
	SELECT 
		Id
		,@UserGameId
	FROM Items
	WHERE Id IN (SELECT Id WHERE MinLevel BETWEEN 19 AND 21);

	COMMIT;
END
ELSE
BEGIN
	ROLLBACK;
END

SELECT
	[Name] [Item Name]
FROM Items
WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @UserGameId)
ORDER BY [Name] ASC;
GO