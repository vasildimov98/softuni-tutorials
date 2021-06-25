--11.	All User Commits
--Create a user defined function, named udf_AllUserCommits(@username) that receives a username.
--The function must return count of all commits for the user:

CREATE FUNCTION udf_AllUserCommits(@Username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = 
	(
		SELECT
			COUNT(*)
		FROM Users u
		JOIN Commits c
			ON u.Id = c.ContributorId
		WHERE Username = @Username
	);

	RETURN @Result;
END
GO

SELECT dbo.udf_AllUserCommits('UnderSinduxrein');
GO

--12. Search for Files
--Create a user defined stored procedure, named usp_SearchForFiles(@fileExtension), that receives files extensions.
--The procedure must print the id, name and size of the file.
--Add "KB" in the end of the size.
--Order them by id (ascending), file name (ascending) and file size (descending)
CREATE OR ALTER PROC usp_SearchForFiles(@FileExtension VARCHAR(30))
AS
BEGIN
	SELECT
		Id
		,[Name]
		,CONCAT(Size, 'KB') Size
	FROM Files
	WHERE CHARINDEX(@FileExtension, [Name]) > 0
	ORDER BY Id ASC, [Name] ASC, Size DESC;
END
GO

EXEC usp_SearchForFiles 'json'
GO