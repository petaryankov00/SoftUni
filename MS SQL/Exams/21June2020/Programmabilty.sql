CREATE OR ALTER FUNCTION  udf_GetAvailableRoom (@HotelId int, @Date DATE, @People int)
RETURNS VARCHAR(200)
AS
BEGIN

	DECLARE @RoomId INT = (SELECT TOP(1) R.Id 
							   FROM Trips AS T
								   JOIN Rooms  AS R ON R.Id = T.RoomId
								   JOIN Hotels AS H ON H.Id = R.HotelId
								   WHERE H.Id = @HotelId 
								   AND @Date NOT BETWEEN T.ArrivalDate AND T.ReturnDate
								   AND T.CancelDate IS NULL
								   AND R.Beds >= @People
								   AND YEAR(@Date) = YEAR(t.ArrivalDate)
								   ORDER BY R.Price DESC);

	IF (@roomId IS NULL) RETURN 'No rooms available';


	DECLARE @baseRate DECIMAL(5,2)  = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId);
	DECLARE @roomPrice DECIMAL(18, 2) = (SELECT Price FROM Rooms WHERE Id = @roomId);
	DECLARE @roomType VARCHAR(20) = (SELECT [Type] FROM Rooms WHERE Id = @roomId);
	DECLARE @beds INT = (SELECT Beds FROM Rooms WHERE Id = @roomId);

	DECLARE @totalPrice DECIMAL(18, 2) = (@baseRate + @roomPrice) * @People;

	RETURN ('Room ' + CAST(@roomId AS varchar(3)) + ': ' + @roomType +
			' (' + CAST(@beds AS varchar(3)) + ' beds)'+ ' - $' + CAST(@totalPrice AS varchar(20)))
END

---

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
DECLARE @CurrRoomId INT = (SELECT RoomId 
						FROM Trips
						WHERE Id = @TripId)

DECLARE @CurrRoomHotelId INT = (SELECT HotelId FROM Rooms
								WHERE @CurrRoomId = id)

DECLARE @TargetRoomHotelId INT = (SELECT HotelId FROM Rooms
								WHERE @TargetRoomId = id)

IF(@CurrRoomHotelId <> @TargetRoomHotelId)
THROW 50001,'Target room is in another hotel!',1;

DECLARE @AccTripsCount INT = (SELECT COUNT(*) FROM Trips as t
								JOIN AccountsTrips as act ON t.Id = act.TripId
								WHERE  @CurrRoomId = t.RoomId)

DECLARE @TargetRoomBeds INT = (SELECT Beds
								FROM Rooms
								WHERE Id = @TargetRoomId)

IF(@TargetRoomBeds < @AccTripsCount)
THROW 50002,'Not enough beds in target room!',1


UPDATE Trips
SET RoomId = @TargetRoomId
WHERE Id = @TripId


END

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7

EXEC usp_SwitchRoom 10, 8