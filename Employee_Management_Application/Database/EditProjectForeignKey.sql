USE [EmployeeManagementSystem]
GO

-- First, drop the existing foreign key constraint
ALTER TABLE [dbo].[Projects] 
DROP CONSTRAINT [FK_Projects_StaffMembers]
GO

-- Then add the new foreign key constraint that references Employees
ALTER TABLE [dbo].[Projects] 
ADD CONSTRAINT [FK_Projects_Employees] 
FOREIGN KEY ([ManagerStaffId]) 
REFERENCES [dbo].[Employees]([StaffId])
ON DELETE CASCADE
GO