--Section 4. Programmability

--11.Get Colonists Count
CREATE FUNCTION  udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN

DECLARE @DoesPlanetExists INT = (SELECT COUNT(*) FROM Planets WHERE [Name] = @PlanetName);

IF (@DoesPlanetExists = 0)
BEGIN
	RETURN 0;
END

DECLARE @Result INT = 
(
	SELECT
		COUNT(c.Id)
	FROM Planets pl
	JOIN Spaceports sp
		ON pl.Id = sp.PlanetId
	JOIN Journeys j
		ON sp.Id = j.DestinationSpaceportId
	JOIN TravelCards tc
		ON j.Id = tc.JourneyId
	JOIN Colonists c
		ON tc.ColonistId = c.Id
	WHERE pl.[Name] = @PlanetName
	GROUP BY pl.[Name]
);

RETURN @Result;

END
GO

SELECT dbo.udf_GetColonistsCount('awddawd')
GO

--12.Change Journey Purpose

/*
	Create a user defined stored procedure, named usp_ChangeJourneyPurpose(@JourneyId, @NewPurpose), that receives an journey id and purpose, and attempts to change the purpose of that journey. An purpose will only be changed if all of these conditions pass:
	•	If the journey id doesn’t exists, then it cannot be changed. Raise an error with the message “The journey does not exist!”
	•	If the journey has already that purpose, raise an error with the message “You cannot change the purpose!”
	If all the above conditions pass, change the purpose of that journey.
*/

CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN

BEGIN TRANSACTION;

DECLARE @DoesJournetExists INT = (SELECT COUNT(*) FROM Journeys WHERE Id = @JourneyId);

IF (@DoesJournetExists = 0)
BEGIN
	ROLLBACK;
	THROW 50001, 'The journey does not exist!', 1;
END

DECLARE @OldPurpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId);

IF (@OldPurpose = @NewPurpose)
BEGIN 
	ROLLBACK;
	THROW 50002, 'You cannot change the purpose!', 2;
END

UPDATE Journeys
	SET Purpose = @NewPurpose
WHERE Id = @JourneyId;

COMMIT;

END
GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical';
EXEC usp_ChangeJourneyPurpose 2, 'Educational';
EXEC usp_ChangeJourneyPurpose 196, 'Technical';
