USE [EmployeeManagmentSystem]
GO

-- Delete data in correct order (child tables first, then parent tables)
DELETE FROM [dbo].[Employees]
DELETE FROM [dbo].[StaffMembers]
DELETE FROM [dbo].[Department]

-- Reset identity seeds
DBCC CHECKIDENT ('[dbo].[StaffMembers]', RESEED, 0)
DBCC CHECKIDENT ('[dbo].[Department]', RESEED, 0)
GO