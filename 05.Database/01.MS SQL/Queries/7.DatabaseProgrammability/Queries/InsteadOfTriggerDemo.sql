/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[SSN]
      ,[IsDeleted]
  FROM [Bank].[dbo].[AccountHolders]

USE Bank;
GO

--Instead of delete set the column isDeleted to true or 1;
CREATE TRIGGER tr_SetIsDeletedToTrue
ON [AccountHolders] INSTEAD OF DELETE
AS
BEGIN
	UPDATE AccountHolders
		SET IsDeleted = 1
	WHERE id IN (SELECT id FROM deleted)
END
GO

UPDATE AccountHolders
	SET IsDeleted = 0
WHERE IsDeleted = 1;