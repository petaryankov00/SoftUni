Use SoftUni

SELECT Concat(FirstName, '.' ,LastName,'@softuni.bg') AS 'Full Email Adress' FROM Employees 

SELECT DISTINCT Salary FROM Employees

SELECT * FROM Employees 
WHERE JobTitle = 'Sales Representative'

SELECT FirstName, LastName, JobTitle FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

SELECT Concat(FirstName, ' ', MiddleName, ' ',LastName) AS 'Full Name' FROM Employees 
WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600

SELECT FirstName,LastName FROM Employees
WHERE ManagerID IS NULL

SELECT TOP (5) FirstName,LastName,Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

SELECT TOP (5) FirstName,LastName FROM Employees
ORDER BY Salary DESC

SELECT FirstName,LastName FROM Employees
WHERE NOT DepartmentID = 4

SELECT * FROM Employees
ORDER BY Salary DESC,FirstName,LastName DESC,MiddleName

CREATE VIEW v_EmployeesSalaries AS
SELECT FirstName,LastName,Salary 
FROM Employees

SELECT * FROM v_EmployeesSalaries

