SELECT CigarName,
PriceForSingleCigar,
ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar,CigarName DESC

---

SELECT c.Id,
c.CigarName,
c.PriceForSingleCigar,
t.TasteType,
t.TasteStrength
FROM Cigars AS c
JOIN Tastes as t ON c.TastId = t.Id
WHERE t.TasteType IN('Earthy','Woody')
ORDER BY c.PriceForSingleCigar DESC

--- 

SELECT c.Id,
CONCAT(c.FirstName,' ',c.LastName) as ClientName,
c.Email
FROM Clients as c
LEFT JOIN ClientsCigars as clc ON c.Id = clc.ClientId
WHERE clc.CigarId IS NULL
ORDER BY ClientName

---

SELECT TOP(5) c.CigarName,
c.PriceForSingleCigar,
c.ImageURL
FROM Cigars AS c
JOIN Sizes as s ON c.SizeId = s.Id AND s.Length >= 12 AND s.RingRange > 2.55
WHERE  c.CigarName LIKE '%ci%' OR
	  c.PriceForSingleCigar > 50 
ORDER BY c.CigarName asc,c.PriceForSingleCigar DESC

---

SELECT CONCAT(c.FirstName,' ',c.LastName) as FullName,
a.Country,
a.ZIP,
CONCAT('$',MAX(cig.PriceForSingleCigar)) as CigarPrice 
FROM Clients as c
JOIN Addresses as a ON c.AddressId = a.Id
JOIN ClientsCigars as clc ON c.Id = clc.ClientId
JOIN Cigars as cig ON clc.CigarId = cig.Id
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY c.FirstName,c.LastName,a.Country,a.ZIP
ORDER BY FullName

---

SELECT c.LastName,
CEILING(AVG(s.Length)) as CiagrLength,
CEILING(AVG(s.RingRange)) as CiagrRingRange
FROM Clients as c
JOIN ClientsCigars as clc ON c.Id = clc.ClientId
JOIN Cigars as cig ON clc.CigarId = cig.Id
JOIN Sizes as s ON cig.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CEILING(AVG(s.Length)) DESC