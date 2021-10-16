INSERT INTO Planets VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

---

INSERT INTO Spaceships VALUES 
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9','SpaceX',1),
('Bed','Vidolov',6)

---

UPDATE Spaceships
SET LightSpeedRate = LightSpeedRate + 1 
WHERE Id BETWEEN 8 AND 12

--- 

DELETE TravelCards
WHERE JourneyId in (1,2,3)

DELETE Journeys
WHERE Id IN(1,2,3)