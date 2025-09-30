--					((Create Department Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[Department](
[DepartmentId] INT IDENTITY(1,1) NOT NULL,
[DepartmentName] VARCHAR(50) NOT NULL,
CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
)
GO

--					((Create StaffMembers Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[StaffMembers](
[StaffId] INT IDENTITY(1,1) NOT NULL,
[Name] VARCHAR(50) NOT NULL,
[Phone] VARCHAR(50) NOT NULL,
[Email] VARCHAR(50) NOT NULL,
[DepartmentId] INT NOT NULL,
[Type] VARCHAR(50) NOT NULL,

CONSTRAINT [PK_StaffMembers] PRIMARY KEY CLUSTERED ([StaffId] ASC),
CONSTRAINT [FK_StaffMembers_Department] 
		FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department]([DepartmentId])
		ON DELETE CASCADE,
CONSTRAINT [UQ_StaffMembers_Email] UNIQUE ([Email])
)
GO

--					((Create Employee Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[Employees](
[EmployeeId] INT NOT NULL,
[SSN] VARCHAR(50) NOT NULL,
CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
CONSTRAINT [FK_Employees_StaffMembers] 
		FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[StaffMembers]([StaffId])
		ON DELETE CASCADE,
CONSTRAINT [UQ_Employees_SSN] UNIQUE ([SSN])
)
GO

--					((Create Volunteers Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[Volunteers](
[VolunteerId] INT NOT NULL,
[Value] DECIMAL(8,2) NOT NULL,
CONSTRAINT [PK_Volunteers] PRIMARY KEY CLUSTERED ([VolunteerId] ASC),
CONSTRAINT [FK_Volunteers_StaffMembers] 
		FOREIGN KEY ([VolunteerId]) REFERENCES [dbo].[StaffMembers]([StaffId])
		ON DELETE CASCADE
)
GO

--					((Create HourlyEmployees Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[HourlyEmployees](
[HEmployeeId] INT NOT NULL,
[Rate] DECIMAL(8,2) NOT NULL,
[Hours] INT NOT NULL,
CONSTRAINT [PK_HourlyEmployees] PRIMARY KEY CLUSTERED ([HEmployeeId] ASC),
CONSTRAINT [FK_HourlyEmployees_Employees]  -- CORRECTED CONSTRAINT NAME
		FOREIGN KEY ([HEmployeeId]) REFERENCES [dbo].[Employees]([EmployeeId])
		ON DELETE CASCADE
)
GO

--					((Create ExecutiveEmployees Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[ExecutiveEmployees](
[ExEmployeeId] INT NOT NULL,
[Salary] DECIMAL(8,2) NOT NULL,
[Bonus] DECIMAL(8,2) NOT NULL,
CONSTRAINT [PK_ExecutiveEmployees] PRIMARY KEY CLUSTERED ([ExEmployeeId] ASC),
CONSTRAINT [FK_ExecutiveEmployees_Employees]  -- CORRECTED CONSTRAINT NAME
		FOREIGN KEY ([ExEmployeeId]) REFERENCES [dbo].[Employees]([EmployeeId])
		ON DELETE CASCADE
)
GO

--					((Create CommissionEmployee Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[CommissionEmployee](
[CEmployeeId] INT NOT NULL,
[Target] DECIMAL(8,2) NOT NULL,
CONSTRAINT [PK_CommissionEmployee] PRIMARY KEY CLUSTERED ([CEmployeeId] ASC),
CONSTRAINT [FK_CommissionEmployee_Employees]  -- CORRECTED CONSTRAINT NAME
		FOREIGN KEY ([CEmployeeId]) REFERENCES [dbo].[Employees]([EmployeeId])
		ON DELETE CASCADE
)
GO

--					((Create SalariedEmployees Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[SalariedEmployees](
[SEmployeeId] INT NOT NULL,
[Salary] DECIMAL(8,2) NOT NULL,
CONSTRAINT [PK_SalariedEmployees] PRIMARY KEY CLUSTERED ([SEmployeeId] ASC),
CONSTRAINT [FK_SalariedEmployees_Employees]  -- CORRECTED CONSTRAINT NAME
		FOREIGN KEY ([SEmployeeId]) REFERENCES [dbo].[Employees]([EmployeeId])
		ON DELETE CASCADE
)
GO

--					((Create Project Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[Projects](
[ProjectId] INT IDENTITY(1,1) NOT NULL,
[Location] VARCHAR(50) NOT NULL,
[CurrentCost] DECIMAL(8,2) NOT NULL,
[ManagerStaffId] INT NOT NULL,
CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([ProjectId] ASC),
CONSTRAINT [FK_Projects_StaffMembers]  
		FOREIGN KEY ([ManagerStaffId]) REFERENCES [dbo].[Employees]([EmployeeId])
		ON DELETE CASCADE
)
GO

--					((Create Budgets Table))
USE [EmployeeManagmentSystem]
GO
CREATE TABLE [dbo].[Budgets](
[BudgetId] INT IDENTITY(1,1) NOT NULL,
[ProjectId] INT NOT NULL,
[Value] DECIMAL(8,2) NOT NULL,
CONSTRAINT [PK_Budgets] PRIMARY KEY CLUSTERED ([BudgetId] ASC),
CONSTRAINT [FK_Budgets_Projects]
		FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects]([ProjectId])
		ON DELETE CASCADE
)
GO