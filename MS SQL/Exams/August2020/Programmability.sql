CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(c.FirstName,' ', c.LastName) as CustomerName,
c.Age,
c.Gender,
co.Name as CountryName
FROM Customers AS c
JOIN Countries as co ON c.CountryId = co.Id

---

CREATE  TRIGGER tr_DeleteAllProductRelations
ON Products INSTEAD OF DELETE 
AS
BEGIN
DECLARE @DeletedProduct INT = (SELECT p.Id 
							FROM Products as p
							JOIN deleted as d ON p.Id = d.Id)
DELETE ProductsIngredients
WHERE ProductId = @DeletedProduct

DELETE Feedbacks
WHERE ProductId = @DeletedProduct

DELETE Products
WHERE Id = @DeletedProduct

END

DELETE FROM Products WHERE Id = 7