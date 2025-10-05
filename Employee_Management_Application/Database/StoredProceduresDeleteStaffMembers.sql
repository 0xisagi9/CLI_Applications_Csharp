USE [EmployeeManagmentSystem]
GO
CREATE PROCEDURE DeleteStaffMember
@Id INT
AS
BEGIN 
SET NOCOUNT ON;
DELETE FROM StaffMembers WHERE StaffId = @Id;

END
GO
