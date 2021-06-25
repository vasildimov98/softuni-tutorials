--5.	Commits
--Select all commits from the database.
--Order them by id (ascending), message (ascending), repository id (ascending) and contributor id (ascending).
SELECT
	Id
	,[Message]
	,RepositoryId
	,ContributorId
FROM Commits
ORDER BY Id ASC, [Message] ASC, RepositoryId ASC, ContributorId ASC;
GO

--6.	Front-end
--Select all of the files, which have size, greater than 1000, and a name containing "html". 
--Order them by size (descending), id (ascending) and by file name (ascending).

SELECT
	Id
	,[Name]
	,Size
FROM Files
WHERE Size > 1000 AND CHARINDEX('html', [Name]) > 0
ORDER BY Size DESC, Id ASC, [Name] ASC;
GO

--7.	Issue Assignment
--Select all of the issues, and the users that are assigned to them, 
--so that they end up in the following format: {username} : {issueTitle}.
--Order them by issue id (descending) and issue assignee (ascending).

SELECT
	i.Id
	,CONCAT(u.Username, ' : ', i.Title) IssueAssignee
FROM Issues i
LEFT JOIN Users u
	ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, i.AssigneeId ASC;
GO

--8.	Single Files
--Examples
--Select all of the files, which are NOT a parent to any other file.
--Select their size of the file and add "KB" to the end of it.
--Order them file id (ascending), file name (ascending) and file size (descending).
SELECT 
	Id
	,[Name]
	,CONCAT(Size, 'KB') Size
FROM Files ch
WHERE Id NOT IN (SELECT ParentId FROM Files WHERE ParentId IS NOT NULL)
ORDER BY Id ASC, [Name] ASC, Size DESC;
GO

--9.	Commits in Repositories
--Select the top 5 repositories in terms of count of commits.
--Order them by commits count (descending), repository id (ascending) then by repository name (ascending).

SELECT TOP (5)
	r.Id
	,r.[Name]
	,COUNT(*) Commits
FROM RepositoriesContributors rc 
LEFT JOIN Repositories r
	ON rc.RepositoryId = r.Id
LEFT JOIN Commits c
	ON r.Id = c.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY Commits DESC, r.Id ASC, r.[Name] ASC;
GO

--10.	Average Size
--Select all users which have commits.
--Select their username and average size of the file, which were uploaded by them. 
--Order the results by average upload size (descending) and by username (ascending).

SELECT
	u.Username
	,AVG(f.Size) Size
FROM Users u
JOIN Commits c
	ON u.Id = c.ContributorId
JOIN Files f
	ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY Size DESC, u.Username ASC;
GO