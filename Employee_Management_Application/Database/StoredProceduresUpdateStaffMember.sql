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
