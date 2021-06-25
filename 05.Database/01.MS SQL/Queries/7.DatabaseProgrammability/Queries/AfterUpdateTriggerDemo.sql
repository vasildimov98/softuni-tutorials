/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[AccountHolderId]
      ,[Balance]
  FROM [Bank].[dbo].[Accounts]

--When a balance to a current account chage, save it to ChangeAccount table
CREATE TABLE ChangeAccountBalanaceLogs 
(
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES Accounts(id) NOT NULL,
	OldBalance MONEY NOT NULL,
	NewBalance MONEY NOT NULL,
	DateOfCahnge DATETIME
);

CREATE OR ALTER TRIGGER tr_SaveBalanceChangeInfo
ON Accounts FOR UPDATE
AS
BEGIN 
	INSERT INTO ChangeAccountBalanaceLogs(AccountId, OldBalance, NewBalance, DateOfCahnge)
	SELECT i.Id, d.Balance, i.Balance, GETDATE() 
		FROM inserted i
		JOIN deleted d 
			ON i.Id = d.Id
		WHERE i.Balance != d.Balance;
END
GO

SELECT * FROM ChangeAccountBalanaceLogs;
GO
