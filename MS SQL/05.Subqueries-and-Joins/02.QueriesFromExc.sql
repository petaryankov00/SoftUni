 USE SoftUni
 
SELECT TOP (5) e.EmployeeID,e.JobTitle,e.AddressID,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

---

SELECT TOP (50) e.FirstName,
e.LastName,
t.[Name] as Town,
a.AddressText
FROM Employees AS e 
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName,e.LastName

---

SELECT e.EmployeeID,e.FirstName,e.LastName,d.[Name] as DepartmentName
FROM Employees AS e 
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

---

SELECT TOP(5) e.EmployeeID,e.FirstName,e.Salary,d.[Name] as DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--- 

SELECT TOP (3) e.EmployeeID,e.FirstName 
FROM Employees AS e 
LEFT JOIN EmployeesProjects AS p ON e.EmployeeID = p.EmployeeID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID

---

SELECT e.FirstName,e.LastName,e.HireDate,d.[Name] as DeptName 
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-1-1' AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY e.HireDate 

---

SELECT TOP (5) ep.EmployeeID,e.FirstName,p.[Name] as ProjectName
FROM Employees as e
JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects as p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY ep.EmployeeID

---

SELECT e.EmployeeID,
	   e.FirstName,
CASE 
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE p.[Name] 
END as ProjectName
	FROM Employees as e
	JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects as p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

	---

	SELECT m.EmployeeID,
		   m.FirstName,
		   m.ManagerID,
		   e.FirstName as ManagerName
	FROM Employees as e
	JOIN Employees as m ON e.EmployeeID = m.ManagerID
	WHERE m.ManagerID IN (3,7)
	ORDER BY m.EmployeeID
	
	---
	 
	SELECT TOP (50) e.EmployeeID,
	CONCAT(e.FirstName, ' ',e.LastName) as EmployeeName,
	CONCAT(m.FirstName, ' ',m.LastName) as ManagerName,
	d.Name as DepartmentName
	FROM Employees as e
	JOIN Employees as m ON e.ManagerID = m.EmployeeID
	JOIN Departments as d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID
	
	---

	SELECT MIN(a.AverageSalary) as MinAverageSalary FROM
	(
	SELECT e.DepartmentID,
		   AVG(e.Salary) as AverageSalary
	FROM Employees as e
	GROUP BY e.DepartmentID
	) as a

	USE Geography

	SELECT mc.CountryCode,
		   m.MountainRange,
		   p.PeakName,
		   p.Elevation
	FROM MountainsCountries as mc
	JOIN Mountains as m ON mc.MountainId = m.Id
	JOIN Peaks as p ON m.Id = p.MountainId
	WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
	ORDER BY p.Elevation DESC

	---
	 
	SELECT c.CountryCode,
	COUNT(m.MountainRange) as MountainRanges
	FROM MountainsCountries as c
	JOIN Mountains as m ON c.MountainId = m.Id
	WHERE c.CountryCode IN ('US','BG','RU')
	GROUP BY c.CountryCode
	
	---

	SELECT TOP (5) c.CountryName,
		   r.RiverName
	FROM Countries as c
	LEFT JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers as r ON cr.RiverId = r.Id
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName

	---
	SELECT ContinentCode,
		   CurrencyCode,
		   CurrencyUsage
	FROM 
	( 
		SELECT *,
		DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) as CurrencyCount 
		FROM
	( 
		SELECT ContinentCode,
		CurrencyCode,
		COUNT(CurrencyCode) AS CurrencyUsage
		FROM Countries
		GROUP BY ContinentCode,CurrencyCode 
	) AS SubQueryCountingTable
	WHERE SubQueryCountingTable.CurrencyUsage > 1 	
	) as ResultTable
	WHERE ResultTable.CurrencyCount = 1
	
	---

	SELECT COUNT(c.CountryCode) as [Count] 
	FROM Countries as c
	LEFT JOIN MountainsCountries as m ON c.CountryCode = m.CountryCode
	WHERE m.MountainId IS NULL

	--- 

	SELECT TOP (5) 
	GroupingTable.CountryName AS CountryName,
	GroupingTable.Elevation AS HighestPeakElevation,
	GroupingTable.Length AS LongestRiverLength
	FROM 
	(
	SELECT c.CountryName,
	p.Elevation,
	r.Length,
	DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC,Length DESC) as [Rank]
	FROM Countries as c
	LEFT JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Peaks as p ON mc.MountainId = p.MountainId
	LEFT JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers as r ON cr.RiverId = r.Id
	GROUP BY c.CountryName,p.Elevation,r.Length
	) AS GroupingTable	
	WHERE GroupingTable.Rank = 1
	ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC, CountryName
	
	---

	SELECT c.CountryName,
	MAX(p.Elevation) AS HighestPeak,
	MAX(r.Length) AS LongestRiver
	FROM Countries as c
	LEFT JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Peaks as p ON mc.MountainId = p.MountainId
	LEFT JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers as r ON cr.RiverId = r.Id
	GROUP BY c.CountryName
	ORDER BY HighestPeak DESC, LongestRiver DESC