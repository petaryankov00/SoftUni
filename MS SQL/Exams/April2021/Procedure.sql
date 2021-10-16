CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
DECLARE @EmployeeDepartment INT = 
		( SELECT DepartmentId 
		FROM Employees as e
		WHERE e.Id = @EmployeeId)

DECLARE @CategoryDepartment INT =
		( SELECT c.DepartmentId 
		FROM Reports as r
		JOIN Categories as c ON r.CategoryId = c.Id
		WHERE r.Id = @ReportId)

IF(@EmployeeDepartment != @CategoryDepartment)
BEGIN
THROW 50001,'Employee doesn''t belong to the appropriate department!',1;
END


UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE Id = @ReportId

GO

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2
