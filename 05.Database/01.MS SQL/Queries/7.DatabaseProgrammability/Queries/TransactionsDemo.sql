/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[AccountHolderId]
      ,[Balance]
  FROM [Bank].[dbo].[Accounts]
  WHERE Id IN (1, 3)



CREATE OR ALTER PROC usp_TransferMoneyFromAccountToAccount (@FromAccountId INT, @ToAccountId INT, @TransferAmount MONEY)
AS
BEGIN

BEGIN TRANSACTION 

IF NOT EXISTS(SELECT * FROM Accounts WHERE id = @FromAccountId) 
BEGIN
	ROLLBACK;
	THROW 50002, '@FromAccountId doesn''t not exists!', 1;
END

IF (SELECT Balance FROM Accounts WHERE Id = @FromAccountId) < 546543.23
BEGIN 
	ROLLBACK;
	THROW 50001, 'Not enough money in @FromAccountId', 1;
END

UPDATE Accounts
	SET Balance -= @TransferAmount
WHERE Id = @FromAccountId;

IF NOT EXISTS(SELECT * FROM Accounts WHERE id = @ToAccountId) 
BEGIN
	ROLLBACK;
	THROW 50003, '@ToAccountId doesn''t not exists!', 1;
END

UPDATE Accounts
	SET Balance += @TransferAmount
WHERE Id = @ToAccountId;

COMMIT

END
GO

EXEC usp_TransferMoneyFromAccountToAccount 1, 3, 546543.23
GO