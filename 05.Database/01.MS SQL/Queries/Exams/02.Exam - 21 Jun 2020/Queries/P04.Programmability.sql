--Section 4. Programmability (14 pts)

--11. Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @Result VARCHAR(MAX) =
	(
		SELECT TOP(1)
			CONCAT('Room ', r.Id, ': ', r.[Type], ' (', r.Beds, ' beds) - $', (h.BaseRate + r.Price) * @People)
		FROM Rooms r
		JOIN Hotels h
			ON r.HotelId = h.Id
		WHERE Beds >= @People
			AND HotelId = @HotelId
			AND NOT EXISTS (SELECT
								*
							FROM Trips tr
							WHERE tr.RoomId = r.Id
								AND tr.CancelDate IS NULL
								AND @Date BETWEEN tr.ArrivalDate AND tr.ReturnDate)
		ORDER BY (h.BaseRate + r.Price) * @People DESC
	);

	IF @Result IS NULL
		RETURN 'No rooms available';

	RETURN @Result;
END
GO

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2);
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3);
GO

--12. Switch Room
--Create a user defined stored procedure, named usp_SwitchRoom(@TripId, @TargetRoomId), that receives a trip and a target room, and attempts to move the trip to the target room. A room will only be switched if all of these conditions are true:
--•	If the target room ID is in a different hotel, than the trip is in, raise an exception with the message “Target room is in another hotel!”.
--•	If the target room doesn’t have enough beds for all the trip’s accounts, raise an exception with the message “Not enough beds in target room!”.
--If all the above conditions pass, change the trip’s room ID to the target room ID.

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN

	BEGIN TRANSACTION;
		
		DECLARE @TripHotelId INT = 
		(
			SELECT
				HotelId
			FROM Trips tr
			JOIN Rooms r
				ON tr.RoomId = r.Id
			WHERE tr.Id = @TripId
		);

		DECLARE @RoomHotelId INT = 
		(
			SELECT
				HotelId
			FROM Rooms
			WHERE Id = @TargetRoomId
		);

		IF (@TripHotelId != @RoomHotelId)
		BEGIN 
			ROLLBACK;
			THROW 50001, 'Target room is in another hotel!', 1;
		END

		DECLARE @AccountsCount INT = 
		(
			SELECT
				COUNT(*)
			FROM AccountsTrips actr
			JOIN Trips tr
				ON actr.TripId = tr.Id
			JOIN Accounts ac
				ON actr.AccountId = ac.Id
			WHERE actr.TripId = @TripId
		);

		DECLARE @BedsCount INT = 
		(
			SELECT 
				Beds
			FROM Rooms
			WHERE Id = @TargetRoomId
		);

		IF (@AccountsCount > @BedsCount)
		BEGIN
			ROLLBACK;
			THROW 50002, 'Not enough beds in target room!', 1;
		END

		UPDATE Trips
			SET RoomId = @TargetRoomId
		WHERE Id = @TripId;

	COMMIT;

END
GO

EXEC usp_SwitchRoom 10, 11;
SELECT RoomId FROM Trips WHERE Id = 10;
EXEC usp_SwitchRoom 10, 7;
EXEC usp_SwitchRoom 10, 8;
GO