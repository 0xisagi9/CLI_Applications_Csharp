-------------------------------------------------------
----                  Danger Zone				-------
-------------------------------------------------------
USE [EmployeeManagmentSystem]
GO

-- Drop tables in reverse dependency order to avoid foreign key conflicts
DROP TABLE IF EXISTS [dbo].[Budgets]
DROP TABLE IF EXISTS [dbo].[Projects]
DROP TABLE IF EXISTS [dbo].[HourlyEmployees]
DROP TABLE IF EXISTS [dbo].[ExecutiveEmployees]
DROP TABLE IF EXISTS [dbo].[CommissionEmployee]
DROP TABLE IF EXISTS [dbo].[SalariedEmployees]
DROP TABLE IF EXISTS [dbo].[Volunteers]
DROP TABLE IF EXISTS [dbo].[Employees]
DROP TABLE IF EXISTS [dbo].[StaffMembers]
DROP TABLE IF EXISTS [dbo].[Department]
GO