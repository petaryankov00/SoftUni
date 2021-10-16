SELECT CONCAT(m.FirstName,' ',m.LastName) as Mechanic,
j.Status,
j.IssueDate
FROM Mechanics AS m
JOIN Jobs as j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId,j.IssueDate,j.JobId

--

SELECT  CONCAT(c.FirstName,' ',c.LastName) as Client,
DATEDIFF(day,j.IssueDate,'2017-04-24') as 'Days going',
j.Status
FROM Clients as c
JOIN Jobs as j ON c.ClientId = j.ClientId
WHERE j.Status != 'Finished'
ORDER BY [Days going] DESC,c.ClientId

--
SELECT JoinTable.Mechanic,
AVG(JoinTable.DaysWorked) as 'Average Days'
FROM
(
	SELECT CONCAT(m.FirstName,' ',m.LastName) as Mechanic,
	DATEDIFF(DAY,j.IssueDate,j.FinishDate) as DaysWorked,
	m.MechanicId
	FROM Mechanics as m
	JOIN Jobs as j ON m.MechanicId = j.MechanicId
	WHERE j.Status = 'Finished'
) as JoinTable
GROUP BY JoinTable.Mechanic,JoinTable.MechanicId
ORDER BY JoinTable.MechanicId

-- 

SELECT 
CONCAT(m.FirstName,' ',m.LastName) as Available
FROM Mechanics as m
WHERE m.MechanicId NOT IN(SELECT MechanicId FROM Jobs 
								WHERE Status = 'In Progress')

--

SELECT j.JobId,
SUM(p.Price) as Total
FROM Parts as p
LEFT JOIN PartsNeeded as pn ON p.PartId = pn.PartId
LEFT JOIN Jobs as j ON pn.JobId = j.JobId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC,JobId

--

SELECT * 
FROM
(SELECT p.PartId,
p.Description,
pn.Quantity AS Required,
p.StockQty AS 'In Stock',
ISNULL(op.Quantity,0) AS Ordered
FROM Jobs AS j
LEFT JOIN PartsNeeded as pn ON j.JobId = pn.JobId
LEFT JOIN Parts as p ON pn.PartId = p.PartId
LEFT JOIN Orders as o ON j.JobId = o.JobId
LEFT JOIN OrderParts as op ON o.OrderId = op.OrderId
WHERE j.Status <> 'Finished' AND (o.Delivered = 0 OR o.Delivered IS NULL)
) AS PartsQuantitySub
WHERE Required > [In Stock] + Ordered
ORDER BY PartId
