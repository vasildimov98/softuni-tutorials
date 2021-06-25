--Exercises: Additional Exercises

--PART I – Queries for Diablo Database
USE Diablo;
GO

--Problem 01.Number of Users for Email Provider
SELECT 
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
	,COUNT(*) [Number Of Users]
FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
ORDER BY [Number Of Users] DESC, [Email Provider] ASC;
GO

--Problem 02.All User in Games
SELECT 
	g.[Name] Game
	,gt.[Name] [Game Type]
	,u.Username
	,ug.[Level]
	,ug.Cash
	,ch.[Name] [Character]
FROM UsersGames ug
JOIN Games g
	ON ug.GameId = g.Id
JOIN GameTypes gt
	ON g.GameTypeId = gt.Id
JOIN Users u
	ON ug.UserId = u.Id
JOIN Characters ch
	ON ug.CharacterId = ch.Id
ORDER BY [Level] DESC, Username ASC, [Game] ASC;
GO

--Problem 03.Users in Games with Their Items
SELECT
	u.Username
	,g.[Name] Game
	,COUNT(ugi.ItemId) [Items Count]
	,SUM(i.Price) [Items Price]
FROM UsersGames ug
JOIN Users u
	ON ug.UserId = u.Id
JOIN Games g
	ON ug.GameId = g.Id
JOIN UserGameItems ugi
	ON ug.Id = ugi.UserGameId
JOIN Items i
	ON ugi.ItemId = i.Id
GROUP BY u.Username, g.[Name]
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC;
GO

--Problem 04.User in Games with Their Statistics
SELECT
	Username
	,Game
	,MAX([Character]) [Character]
	,SUM(ItemStrength) + MAX(GameTypeStrength) + MAX(CharacterStrength) Strength
	,SUM(ItemDefence) + MAX(GameTypeDefence) + MAX(CharacterDefence) Defence
	,SUM(ItemSpeed) + MAX(GameTypeSpeed) + MAX(CharacterSpeed) Speed
	,SUM(ItemMind) + MAX(GameTypeMind) + MAX(CharacterMind) Mind
	,SUM(ItemLuck) + MAX(GameTypeLuck) + MAX(CharacterLuck) Luck
FROM (SELECT
		u.Username
		,g.[Name] Game
		,ch.[Name] [Character]
		,SUM(ist.Strength) ItemStrength
		,SUM(ist.Defence) ItemDefence
		,SUM(ist.Speed) ItemSpeed
		,SUM(ist.Mind) ItemMind
		,SUM(ist.Luck) ItemLuck
		,MAX(gtst.Strength) GameTypeStrength
		,MAX(gtst.Defence) GameTypeDefence
		,MAX(gtst.Speed) GameTypeSpeed
		,MAX(gtst.Mind) GameTypeMind
		,MAX(gtst.Luck) GameTypeLuck
		,MAX(chst.Strength) CharacterStrength
		,MAX(chst.Defence) CharacterDefence
		,MAX(chst.Speed) CharacterSpeed
		,MAX(chst.Mind) CharacterMind
		,MAX(chst.Luck) CharacterLuck
	FROM UsersGames ug
	JOIN Games g
		ON ug.GameId = g.Id
	JOIN GameTypes gt
		ON g.GameTypeId = gt.Id
	JOIN Users u
		ON ug.UserId = u.Id
	JOIN Characters ch
		ON ug.CharacterId = ch.Id
	JOIN UserGameItems ugi
		ON ug.Id = ugi.UserGameId
	JOIN Items i
		ON ugi.ItemId = i.Id
	JOIN [Statistics] ist
		ON i.StatisticId = ist.Id
	JOIN [Statistics] gtst
		ON gt.BonusStatsId = gtst.Id
	JOIN [Statistics] chst
		ON ch.StatisticId = chst.Id
	GROUP BY u.Username, g.[Name], ch.[Name]) statInfo
GROUP BY Username, Game
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC;
GO

--Problem 05.All Items with Greater than Average Statistics
SELECT
	it.[Name]
	,it.Price
	,it.MinLevel
	,st.Strength
	,st.Defence
	,st.Speed
	,st.Luck
	,st.Mind
FROM Items it
JOIN [Statistics] st
	ON it.StatisticId = st.Id
WHERE st.Mind > (SELECT AVG(Mind) FROM [Statistics])
	AND st.Luck > (SELECT AVG(Luck) FROM [Statistics])
	AND st.Speed > (SELECT AVG(Speed) FROM [Statistics])
ORDER BY it.[Name] ASC;
GO

--Problem 06.Display All Items with Information about Forbidden Game Type
SELECT 
	it.[Name] Item
	,it.Price
	,it.MinLevel
	,gt.[Name] [Forbidden Game Type]
FROM Items it
LEFT JOIN GameTypeForbiddenItems gtfit
	ON it.Id = gtfit.ItemId
LEFT JOIN GameTypes gt
	ON gtfit.GameTypeId = gt.Id
ORDER BY [Forbidden Game Type] DESC, Item ASC;
GO

--Problem 07.Buy Items for User in Game
DECLARE @Username CHAR(4) = 'Alex';
DECLARE @GameName CHAR(9) = 'Edinburgh';
DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @Username);
DECLARE @GameId INT = (SELECT Id FROM Games WHERE [Name] = @GameName);
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId);
DECLARE @UserCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId);

DECLARE @FirstItemName NVARCHAR(50) = 'Blackguard';
DECLARE @SecondItemName NVARCHAR(50) = 'Bottomless Potion of Amplification';
DECLARE @ThirdItemName NVARCHAR(50) = 'Eye of Etlich (Diablo III)';
DECLARE @ForthItemName NVARCHAR(50) = 'Gem of Efficacious Toxin';
DECLARE @FifthItemName NVARCHAR(50) = 'Golden Gorget of Leoric';
DECLARE @SixthItemName NVARCHAR(50) = 'Hellfire Amulet';

DECLARE @FirstItemId INT = (SELECT Id FROM Items WHERE [Name] = @FirstItemName);
DECLARE @SecondItemId INT = (SELECT Id FROM Items WHERE [Name] = @SecondItemName);
DECLARE @ThirdItemId INT = (SELECT Id FROM Items WHERE [Name] = @ThirdItemName);
DECLARE @ForthItemId INT = (SELECT Id FROM Items WHERE [Name] = @ForthItemName);
DECLARE @FifthItemId INT = (SELECT Id FROM Items WHERE [Name] = @FifthItemName);
DECLARE @SixthItemId INT = (SELECT Id FROM Items WHERE [Name] = @SixthItemName);

DECLARE @TotalItemPrice MONEY = (SELECT SUM(Price) FROM Items WHERE Id IN (@FirstItemId, @SecondItemId, @ThirdItemId, @ForthItemId, @FifthItemId, @SixthItemId));

INSERT INTO UserGameItems (ItemId, UserGameId)
SELECT 
	Id
	,@UserGameId
FROM Items
WHERE Id IN (@FirstItemId, @SecondItemId, @ThirdItemId, @ForthItemId, @FifthItemId, @SixthItemId);

UPDATE UsersGames
	SET Cash -= @TotalItemPrice
WHERE Id = @UserGameId;

SELECT 
	u.Username
	,g.[Name]
	,ug.Cash
	,it.[Name] [Item Name]
FROM UserGameItems ugi
JOIN UsersGames ug
	ON ugi.UserGameId = ug.Id
JOIN Games g
	ON ug.GameId = g.Id
JOIN Users u
	ON ug.UserId = u.Id
JOIN Items it
	ON ugi.ItemId = it.Id
WHERE GameId = @GameId
ORDER BY it.[Name];
GO