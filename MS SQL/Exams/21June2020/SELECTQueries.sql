SELECT a.FirstName,
a.LastName,
FORMAT(a.BirthDate,'MM-dd-yyyy') as BirthDate,
c.Name as HomeTown,
a.Email
FROM Accounts as a
JOIN Cities as c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY HomeTown 

---

SELECT c.Name as City,
COUNT(h.Id) as Hotels
FROM Hotels as h
JOIN Cities as c ON h.CityId = c.Id
GROUP BY c.Name
ORDER BY Hotels DESC,c.Name

---


SELECT RankingTable.AccountId,
RankingTable.FullName,
MAX(Diff) as LongestTrip,
MIN(Diff) as ShortestTrip
FROM
(
	SELECT act.AccountId as AccountId,
	CONCAT(a.FirstName,' ',a.LastName) AS FullName,
	DATEDIFF(day,t.ArrivalDate,t.ReturnDate) as Diff
	FROM Accounts as a
	JOIN AccountsTrips as act ON a.Id = act.AccountId
	JOIN Trips as t ON act.TripId = t.Id
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL 
) as RankingTable
GROUP BY RankingTable.AccountId,RankingTable.FullName
ORDER BY LongestTrip DESC, ShortestTrip

---

SELECT TOP(10) c.Id,
c.Name,
c.CountryCode,
COUNT(a.Id) as Accounts
FROM Cities as c
JOIN Accounts as a ON c.Id = a.CityId
GROUP BY c.Id,c.Name,c.CountryCode
ORDER BY Accounts desc

---

SELECT a.Id,
a.Email,
c.Name,
COUNT(t.Id) as Trips
FROM Accounts as a
JOIN AccountsTrips as act ON a.Id = act.AccountId
JOIN Trips as t ON act.TripId = t.Id
JOIN Rooms as r ON t.RoomId = r.Id
JOIN Hotels as h ON r.HotelId = h.Id
JOIN Cities as c ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY a.Id,a.Email,c.Name
ORDER BY Trips desc,a.Id

---

SELECT SubqueryTable.Id,
SubqueryTable.[Full Name],
c.Name as [From],
c1.Name as [To],
SubqueryTable.Duration
FROM
(
SELECT t.Id,
CASE
	WHEN a.MiddleName IS NULL THEN CONCAT(a.FirstName, ' ', a.LastName)
	ELSE CONCAT(a.FirstName, ' ' + a.MiddleName, ' ', a.LastName)
END AS [Full Name],
a.CityId,
h.CityId as HotelId,
CASE 
	WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(day,t.ArrivalDate,t.ReturnDate),' ','days')
	ELSE 'Canceled'
END AS Duration
FROM Trips as t
JOIN AccountsTrips as act on t.Id = act.TripId
JOIN Accounts as a ON act.AccountId = a.Id
JOIN Rooms as r ON r.Id = t.RoomId
JOIN Hotels as h ON h.Id = r.HotelId
GROUP BY t.Id,a.FirstName,a.MiddleName,a.LastName,a.CityId,h.CityId,t.ArrivalDate,t.ReturnDate,t.CancelDate
) as SubqueryTable
JOIN Cities as c ON c.Id = SubqueryTable.CityId
JOIN Cities as c1 ON c1.Id = SubqueryTable.HotelId
ORDER BY SubqueryTable.[Full Name],SubqueryTable.Id


