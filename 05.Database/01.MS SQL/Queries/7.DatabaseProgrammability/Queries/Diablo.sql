--III. Queries for Diablo Database
USE Diablo;
GO

--13.Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(50))
RETURNS TABLE 
AS
RETURN
(
	SELECT
		SUM(Cash) SumCash
	FROM (SELECT
			ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) CashRank
			,ug.Cash
		  FROM UsersGames ug
		  JOIN Games g
			ON ug.GameId = g.Id
		  WHERE g.[Name] LIKE @GameName) ci
	WHERE CashRank % 2 != 0
);
GO

SELECT * FROM Games;

SELECT * FROM dbo.ufn_CashInUsersGames('Amsterdam');