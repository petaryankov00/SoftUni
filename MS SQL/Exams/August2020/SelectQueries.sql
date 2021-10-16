SELECT Name,
Price,
Description
FROM Products
ORDER BY Price DESC,Name

---

SELECT f.ProductId,
f.Rate,
f.Description,
f.CustomerId,
c.Age,
c.Gender
FROM Feedbacks as f
JOIN Customers as c ON f.CustomerId = c.Id
WHERE f.Rate < 5.0
ORDER BY f.ProductId desc,f.Rate

---

SELECT CONCAT(c.FirstName,' ',c.LastName) as CustomerName,
c.PhoneNumber,
c.Gender
FROM Customers as c
LEFT JOIN Feedbacks as f ON c.Id = f.CustomerId
WHERE f.Id IS NULL
ORDER BY c.Id

---

SELECT c.FirstName,
c.Age,
c.PhoneNumber
FROM Customers as c
JOIN Countries as co ON c.CountryId = co.Id
WHERE (c.Age >= 21 AND FirstName LIKE '%an%') OR (c.PhoneNumber LIKE '%38' AND co.Name <> 'Greece')
ORDER BY c.FirstName,c.Age DESC

---

SELECT d.Name,
i.Name,
p.Name,
AVG(f.Rate) as AverageRate
FROM Ingredients as i
JOIN ProductsIngredients as prin ON i.Id = prin.IngredientId
JOIN Products as p ON prin.ProductId = p.Id
JOIN Distributors as d ON i.DistributorId = d.Id
JOIN Feedbacks as f ON f.ProductId = p.Id
GROUP BY i.Name,d.Name,p.Name
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.Name,i.Name,p.Name

---


SELECT CountryName,
DistributorName
FROM
(
	SELECT c.Name CountryName,
	d.Name as DistributorName,
	COUNT(i.Id) as Count,
	DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY COUNT(i.Id) desc) AS Rank
	FROM Countries as c
    JOIN Distributors as d ON c.Id = d.CountryId
	LEFT JOIN Ingredients as i ON i.DistributorId = d.Id
	GROUP BY c.Name,d.Name
) as RankingTable
WHERE Rank = 1
ORDER BY CountryName,DistributorName


