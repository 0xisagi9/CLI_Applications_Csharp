USE [EmployeeManagmentSystem]
GO

CREATE PROCEDURE UpdateStaffMember
    @StaffId INT, 
    @Name VARCHAR(50),
    @Phone VARCHAR(50),
    @Email VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE StaffMembers
    SET Name = @Name,
        Phone = @Phone,
        Email = @Email
    WHERE StaffId = @StaffId;
END
GO

SELECT * FROM StaffMembers
SELECT D.DepartmentId,D.DepartmentName,S.StaffId,S.Name,S.Type
FROM Department D INNER JOIN StaffMembers S ON S.DepartmentId = D.DepartmentId
