SELECT Id,
FORMAT(JourneyStart,'dd/MM/yyyy') as JourneyStart,
FORMAT(JourneyEnd,'dd/MM/yyyy') as JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

---

SELECT c.Id,
CONCAT(c.FirstName,' ',c.LastName) as FullName
FROM Colonists as c 
JOIN TravelCards as t ON c.iD = t.ColonistId
WHERE JobDuringJourney = 'Pilot'
ORDER BY c.Id

---

SELECT COUNT(*) AS count 
FROM Journeys as j
JOIN TravelCards as t on j.Id = t.JourneyId
WHERE j.Purpose = 'Technical'

---

SELECT s.Name,
s.Manufacturer
FROM Spaceships as s
JOIN Journeys as j ON s.Id = j.SpaceshipId
JOIN TravelCards as t ON j.Id = t.JourneyId
JOIN Colonists as c ON c.Id = t.ColonistId
WHERE t.JobDuringJourney = 'Pilot' AND 
YEAR('01/01/2019') - YEAR(c.BirthDate) < 30
ORDER BY s.Name

---

SELECT p.Name as PlanetName,
COUNT(j.Id) as JourneysCount
FROM Planets as p
JOIN Spaceports as s ON p.Id = s.PlanetId
JOIN Journeys as j ON j.DestinationSpaceportId = s.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC,p.Name


---


SELECT * 
FROM
(
SELECT t.JobDuringJourney,
CONCAT(c.FirstName,' ',c.LastName) as FullName,
DENSE_RANK() OVER (PARTITION BY t.JobDuringJourney ORDER BY c.BirthDate) as Rank
FROM Colonists as c
JOIN TravelCards as t ON c.Id = t.ColonistId
) as RankingTable
WHERE Rank = 2


