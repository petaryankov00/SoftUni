SELECT Id,Message,RepositoryId,ContributorId FROM Commits
ORDER BY Id,Message,RepositoryId,ContributorId

---

SELECT Id,
	   Name,
	   Size 
FROM Files
WHERE Size > 1000 AND Name LIKE '%.html'
ORDER BY Size DESC,Id,Name

---

SELECT i.Id,
CONCAT(u.Username,' : ',i.Title) as IssueAssignee
FROM Issues AS i
JOIN Users as u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC,IssueAssignee

---

SELECT f.Id,
f.Name,
CONCAT(f.Size, 'KB') as 'Size'
FROM Files as f
LEFT JOIN Files as f1 ON f.Id = f1.ParentId
WHERE f1.Id IS NULL
ORDER BY f.Id,f.Name,Size DESC

---


SELECT TOP(5) r.Id,
r.Name,
COUNT(c.Id) as Commits
FROM Repositories as r
JOIN Commits as c ON r.Id = c.RepositoryId
JOIN RepositoriesContributors as rc ON rc.RepositoryId = r.Id
GROUP BY r.Id,r.Name
ORDER BY Commits DESC,r.Id,r.Name 

---

SELECT u.Username,
AVG(f.Size) as Size
FROM Users as u
JOIN Commits as c ON u.Id = c.ContributorId
JOIN Files as f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY Size DESC,u.Username
