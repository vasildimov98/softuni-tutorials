--Section 3. Querying 

--5.Select all military journeys
SELECT 
	Id
	,FORMAT(JourneyStart, 'dd/MM/yyyy') JourneyStart
	,FORMAT(JourneyEnd, 'dd/MM/yyyy') JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart;
GO

--6. Select all pilots
SELECT
	Id
	,CONCAT(FirstName, ' ', LastName) full_name	 
FROM Colonists
WHERE Id IN (SELECT ColonistId FROM TravelCards WHERE JobDuringJourney = 'Pilot')
ORDER BY Id ASC;
GO

--7. Count colonists
SELECT 
	COUNT(*) [count]
FROM Colonists
WHERE Id IN (SELECT
				ColonistId
			FROM TravelCards
			WHERE JourneyId IN(SELECT
									Id
								FROM Journeys
								WHERE Purpose = 'Technical'));
GO

--8. Select spaceships with pilots younger than 30 years

--Extract from the database those spaceships, which have pilots, younger than 30 years old.
--In other words, 30 years from 01/01/2019.
--Sort the results alphabetically by spaceship name.

SELECT DISTINCT
	[Name]
	,Manufacturer
FROM Spaceships sp
JOIN Journeys j
	ON sp.Id = j.SpaceshipId
JOIN TravelCards tc
	ON j.Id = tc.JourneyId
JOIN Colonists c
	ON tc.ColonistId = c.Id
WHERE DATEDIFF(YEAR, c.BirthDate, '2019-01-01') < 30 AND tc.JobDuringJourney = 'Pilot'
ORDER BY [Name] ASC;
GO

--9. Select all planets and their journey count
/*
	Extract from the database all planets’ names and their journeys count.
	Order the results by journeys count, descending and by planet name ascending.
*/

SELECT
	pl.[Name] PlanetName
	,COUNT(j.Id) JourneysCount
FROM Planets pl
JOIN Spaceports sp
	ON pl.Id = sp.PlanetId
JOIN Journeys j
	ON sp.Id = j.DestinationSpaceportId
GROUP BY pl.[Name]
ORDER BY JourneysCount DESC, PlanetName ASC;
GO

--10.Select Second Oldest Important Colonist
/*
	Find all colonists and their job during journey with rank 2.
	Keep in mind that all the selected colonists with rank 2 must be the oldest ones.
	You can use ranking over their job during their journey.
*/

SELECT
	*
FROM 
(
	SELECT
		tc.JobDuringJourney
		,CONCAT(c.FirstName, ' ', c.LastName) FullName
		,ROW_NUMBER() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate ASC) JobRank
	FROM Colonists c
	JOIN TravelCards tc
	ON c.Id = tc.ColonistId
) i
WHERE JobRank = 2;
GO