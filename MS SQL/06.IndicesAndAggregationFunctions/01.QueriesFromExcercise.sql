SELECT DepositGroup, 
MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

---

SELECT TOP (2) DepositGroup 
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

---

SELECT DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

---

SELECT DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

---

SELECT DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC

--- 

SELECT DepositGroup,
MagicWandCreator,
MIN(DepositCharge) as MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup

---


SELECT GroupingTable.AgeGroup,
COUNT(id) as WizzardCount
FROM
(
SELECT *, 
CASE
	WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
	WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
	WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
	WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
	WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
	WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
	ELSE '[61+]'
END AS AgeGroup
FROM WizzardDeposits
) AS GroupingTable
GROUP BY GroupingTable.AgeGroup

---

SELECT DISTINCT SUBSTRING(FirstName,1,1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName
ORDER BY FirstLetter

--- 

SELECT DepositGroup,
IsDepositExpired,
AVG(DepositInterest) as AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

---

SELECT SUM(GameTable.[Difference]) as SumDifference
FROM
(
SELECT FirstName as 'Host Wizard', 
DepositAmount as 'Host Deposit',
LEAD(FirstName) OVER(ORDER BY Id) as 'Guest Wizard',
LEAD(DepositAmount) OVER(ORDER BY Id) as 'Guest Amount',
DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) as [Difference]
FROM WizzardDeposits 
) as GameTable

---

SELECT DepartmentID,
SUM(Salary) as TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

---

SELECT DepartmentID,
MIN(Salary) as MinimumSalary
FROM Employees
WHERE DepartmentID IN(2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

---

SELECT * 
INTO [DemoEmployees]
FROM Employees
WHERE Salary > 30000

DELETE FROM DemoEmployees
WHERE ManagerID = 42

UPDATE DemoEmployees
SET Salary+= 5000
WHERE DepartmentID = 1

SELECT DepartmentID,
AVG(Salary) as AverageSalary
FROM DemoEmployees
GROUP BY DepartmentID

---

SELECT DepartmentID,
MAX(Salary) as MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

---


SELECT COUNT(*) AS Count 
FROM Employees
WHERE ManagerID IS NULL

---

SELECT DISTINCT DepartmentID,
Salary as ThirdHighestSalary
FROM
(
SELECT e.DepartmentID,
e.Salary,
DENSE_RANK() OVER(PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) as RANK
FROM Employees as e
) AS RankingTable
WHERE RankingTable.RANK = 3

---



SELECT TOP (10) 
e.FirstName,
e.LastName,
e.DepartmentID
FROM Employees as e
WHERE Salary > ( SELECT AVG(Salary) as AvgSalary
				 FROM Employees 
				 WHERE DepartmentID = e.DepartmentID
				 GROUP BY DepartmentID )
ORDER BY e.DepartmentID




