SELECT * FROM 
( 
SELECT EmployeeID,FirstName,LastName,Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary >= 10000 AND Salary <= 50000
)
AS Result
WHERE Rank = 2
ORDER BY Salary DESC


USE Geography

SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

SELECT * FROM 
(
SELECT Peaks.PeakName,
       Rivers.RiverName,
	   LOWER(LEFT(PeakName,LEN(PeakName)-1) + RiverName) AS Mix 
FROM Peaks
JOIN Rivers ON RIGHT(PeakName,1) = LEFT(RiverName,1)
)
AS Result
ORDER BY Mix

USE Diablo 

SELECT TOP (50) [Name], FORMAT([Start],'yyyy-MM-dd') AS Start
FROM Games 
WHERE DATEPART(YEAR,Start) = 2011 OR DATEPART(YEAR,Start) = 2012
ORDER BY [Start],[Name]

SELECT Username,
      SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email) - CHARINDEX('@',Email)) AS 'Email Provider'
FROM Users
ORDER BY [Email Provider],Username

SELECT Username,IpAddress 
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

SELECT [Name] AS Game,
CASE 
WHEN DATEPART(HOUR,Start) >= 0 AND DATEPART(HOUR,Start) < 12 THEN 'Morning'
WHEN DATEPART(HOUR,Start) >= 12 AND DATEPART(HOUR,Start) < 18 THEN 'Afternoon'
ELSE 'Evening'
END AS [Part of the Day],
CASE 
WHEN Duration <= 3 THEN 'Extra Short'
WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
WHEN Duration > 6 THEN 'Long'
ELSE 'Extra Long'
END AS Duration
FROM Games
ORDER BY Game,Duration,[Part of the Day]
















































USE Orders

SELECT ProductName,
       OrderDate,
	   DATEADD(day,3,OrderDate) AS [Pay Due],
	   DATEADD(month,1,OrderDate) AS [Delivery Due]
FROM Orders
