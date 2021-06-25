--Exercises: Triggers and Transactions
USE Bank;
GO

--01.Create Table Logs
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES Accounts(Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
);
GO

CREATE TRIGGER tr_OnAccountChange
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
		FROM inserted i
		JOIN deleted d
			ON i.Id = d.Id
		WHERE d.Balance != i.Balance;
END
GO

--02.Create Table Emails
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] VARCHAR(30) NOT NULL,
	Body VARCHAR(100) NOT NULL
);
GO

CREATE OR ALTER TRIGGER tr_NotifyWhenBalanceChange
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	SELECT
		i.Id,
		CONCAT('Balance change for account: ', i.Id),
		CONCAT('On ', GETDATE(), ' your balance was changed from ', d.Balance, ' to ', i.Balance)
	FROM inserted i
	JOIN deleted d
		ON i.Id = d.Id;
END
GO

--03.Deposit Money
CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN
	UPDATE Accounts
		SET Balance += @MoneyAmount
	WHERE Id = @AccountId;
END
GO

--04.Withdraw Money
CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN
	UPDATE Accounts
		SET Balance -= @MoneyAmount
	WHERE Id = @AccountId;
END
GO

--05.Money Transfer
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4))
AS
BEGIN TRANSACTION;
	IF (@Amount <= 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Ineficient amount of money', 1;
	END

	EXEC usp_WithdrawMoney @SenderId, @Amount;
	EXEC usp_DepositMoney @ReceiverId, @Amount;
COMMIT
GO