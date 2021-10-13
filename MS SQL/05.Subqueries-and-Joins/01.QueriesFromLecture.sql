USE SoftUni

SELECT TOP (50)
e.FirstName,
e.LastName,
t.[Name] AS Town,
a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName,e.LastName

---

SELECT 
e.EmployeeID,
e.FirstName,
e.LastName,
d.Name as [DepartmentName]
FROM Employees as e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

---

SELECT MIN(Result.AvgSalary) as MinSalary FROM
(
SELECT AVG(Salary) as AvgSalary 
FROM Employees 
GROUP BY DepartmentID
)
AS Result 


