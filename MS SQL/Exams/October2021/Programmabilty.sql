CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(30))
RETURNS INT
AS
BEGIN
DECLARE @CigarsCount INT =  (SELECT COUNT(*) FROM Clients as c
							 JOIN ClientsCigars as clc ON c.Id = clc.ClientId
							 WHERE c.FirstName = @name)

RETURN @CigarsCount

END

SELECT dbo.udf_ClientWithCigars('Betty')

---

CREATE PROCEDURE usp_SearchByTaste(@taste NVARCHAR(20))
AS
BEGIN

SELECT c.CigarName,
CONCAT('$',c.PriceForSingleCigar) as Price,
t.TasteType,
b.BrandName,
CONCAT(s.Length,' ','cm') as CigarLength,
CONCAT(s.RingRange,' ','cm') as CigarRingRange
FROM Cigars as c
JOIN Brands as b ON c.BrandId = b.Id
JOIN Tastes as t ON c.TastId = t.Id
JOIN Sizes as s ON c.SizeId = s.Id
WHERE t.TasteType = @taste
ORDER BY CigarLength,CigarRingRange DESC

END

EXEC usp_SearchByTaste 'Woody'