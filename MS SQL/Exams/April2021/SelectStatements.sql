SELECT Description,
FORMAT(OpenDate,'dd-MM-yyyy') as OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY Reports.OpenDate, [Description]

SELECT r.[Description],
c.Name
FROM Reports as r
JOIN Categories as c ON r.CategoryId = c.Id
ORDER BY r.Description,c.Name

SELECT TOP (5) c.Name, 
COUNT(r.CategoryId) as ReportsNumber
FROM Categories as c
JOIN Reports as r ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY ReportsNumber DESC,c.Name

SELECT u.Username,
c.Name
FROM Reports AS r
JOIN Categories as c ON r.CategoryId = c.Id
JOIN Users as u ON r.UserId = u.Id
WHERE DAY(u.Birthdate) = DAY(r.OpenDate) AND MONTH(u.Birthdate) = MONTH(r.OpenDate)
ORDER BY u.Username,c.Name


SELECT CONCAT(e.FirstName,' ',e.LastName) as FullName,
ISNULL(UsersCount,0) UsersCount
FROM
(
	SELECT r.EmployeeId,
	COUNT(r.UserId) as UsersCount
	FROM Reports as r
	GROUP BY r.EmployeeId 
) as GroupingTable
RIGHT JOIN Employees as e ON GroupingTable.EmployeeId = e.Id
ORDER BY UsersCount DESC,FullName

SELECT ISNULL(e.FirstName + ' ' + e.LastName,'None') as Employee,
ISNULL(d.Name,'None') as DepartmentName,
ISNULL(c.Name,'None') as CategoryName,
ISNULL(r.Description,'None'),
ISNULL(FORMAT(r.OpenDate,'dd.MM.yyyy'),'None') as OpenDate,
ISNULL(s.Label,'None') as Status,
ISNULL(u.Name,'None') as [User]
FROM Reports as r
LEFT JOIN Employees as e ON r.EmployeeId = e.Id
LEFT JOIN Departments as d ON e.DepartmentId = d.Id
LEFT JOIN Categories as c ON r.CategoryId = c.Id
LEFT JOIN Status as s ON r.StatusId = s.Id
LEFT JOIN Users as u ON r.UserId = u.Id
ORDER BY e.FirstName DESC,e.LastName DESC,d.Name,c.Name,r.Description,r.OpenDate,s.Label,u.Name
