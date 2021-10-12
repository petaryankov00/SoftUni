USE SoftUni

INSERT INTO Projects (Name, StartDate)
SELECT CONCAT(Name,' Restructuring'), GETDATE() 
FROM Departments

INSERT INTO Towns 
VALUES ('Stara Zagora')

SELECT * FROM Towns
WHERE [Name] = 'Stara Zagora'

SELECT * FROM Projects

UPDATE Projects
Set EndDate = GETDATE()
WHERE EndDate IS NULL