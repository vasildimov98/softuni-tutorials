--II.Queries for Bank Database
USE Bank;
GO

--09.Find Full Name
CREATE PROC usp_GetHoldersFullName 
AS
BEGIN
	SELECT
		CONCAT(FirstName, ' ', LastName) [Full Name]
	FROM AccountHolders;
END
GO

EXEC usp_GetHoldersFullName;

--10.People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan @Money DECIMAL(18, 4)
AS
BEGIN
	SELECT
		FirstName
		,LastName
	FROM AccountHolders
	WHERE Id IN (SELECT
					AccountHolderId
				FROM Accounts
				GROUP BY AccountHolderId
				HAVING SUM(Balance) > @Money)
	ORDER BY FirstName, LastName;
END
GO

EXEC usp_GetHoldersWithBalanceHigherThan 1000000;
GO

--11.Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@InitialSum DECIMAL(18, 4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	RETURN @InitialSum * POWER(1 + @YearlyInterestRate ,@NumberOfYears);
END 
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5);
GO

--12.Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount @AccountId INT, @InterestRate FLOAT
AS
BEGIN
	SELECT 
		a.Id [Account Id]
		,ah.FirstName [First Name]
		,ah.LastName [Last Name]
		,a.Balance [Current Balance]
		,dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) [Balance in 5 years]
	FROM Accounts a
	JOIN AccountHolders ah
		ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId;
END
GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1;
GO