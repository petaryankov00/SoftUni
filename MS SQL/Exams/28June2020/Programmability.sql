CREATE or alter FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30)) 
RETURNS INT
AS
BEGIN

DECLARE @ColonistCount INT =  ( SELECT ISNULL(COUNT(t.Id),0) 
								FROM Planets as p
								JOIN Spaceports as s ON p.Id = s.PlanetId
								JOIN Journeys as j ON j.DestinationSpaceportId = s.Id
								JOIN TravelCards as t ON t.JourneyId = j.Id
								WHERE p.Name = @PlanetName
								)
RETURN @ColonistCount
								

END

GO 

---

CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT , @NewPurpose NVARCHAR(30)) 
AS
BEGIN

DECLARE @CurrentPurpose NVARCHAR(30) = ( SELECT Purpose FROM Journeys
										WHERE Id = @JourneyId )

IF(@CurrentPurpose IS NULL)
THROW 50001,'The journey does not exist!',1

IF(@CurrentPurpose = @NewPurpose)
THROW 50002,'You cannot change the purpose!',1


UPDATE Journeys
SET Purpose = @NewPurpose
WHERE Id = @JourneyId

END

EXEC usp_ChangeJourneyPurpose 4, 'Technical'

EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
