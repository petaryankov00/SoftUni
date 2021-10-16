CREATE OR ALTER FUNCTION udf_AllUserCommits(@Username VARCHAR(50))
RETURNS INT
AS
BEGIN
DECLARE @CountCommits INT;

SET @CountCommits = (SELECT COUNT(*) FROM Users as u
					JOIN Commits as c ON u.Id = c.ContributorId
					WHERE u.Username = @Username)

RETURN @CountCommits

END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

---

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(30))
AS
BEGIN 

SELECT Id,
Name,
CONCAT(Size,'KB') as Size
FROM Files
WHERE Name LIKE '%'+@fileExtension+'%'
ORDER BY Id,Name,Size DESC

END

EXEC usp_SearchForFiles 'txt'