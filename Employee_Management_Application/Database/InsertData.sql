

-- Insert Departement
INSERT INTO [dbo].[Department] ([DepartmentName])
VALUES 
('HR Departement'),
('Frontend Departement'),
('Backend Departement'),
('It Departement'),
('UI/UX Departement')
GO
SELECT * FROM Department
GO

-- Insert Employees 1. First Staff Member
INSERT INTO [dbo].[StaffMembers] ([Name], [Phone], [Email], [DepartmentId], [Type])
VALUES
('John Smith', '555-0101', 'john.smith@company.com', 1, 'Salary'),
('Sarah Johnson', '555-0102', 'sarah.johnson@company.com', 2, 'Hourly'),
('Michael Chen', '555-0103', 'michael.chen@company.com', 3, 'Commission'),
('Emily Davis', '555-0104', 'emily.davis@company.com', 4, 'Volunteers'),
('Robert Wilson', '555-0105', 'robert.wilson@company.com', 5, 'Executive'),
('Lisa Brown', '555-0106', 'lisa.brown@company.com', 5, 'Salary'),
('David Miller', '555-0107', 'david.miller@company.com', 1, 'Hourly'),
('Jennifer Taylor', '555-0108', 'jennifer.taylor@company.com', 2, 'Commission'),
('Kevin Anderson', '555-0109', 'kevin.anderson@company.com', 3, 'Volunteers'),
('Amanda Martinez', '555-0110', 'amanda.martinez@company.com', 4, 'Executive');
GO
SELECT * FROM StaffMembers

INSERT INTO [dbo].[Employees] ([EmployeeId], [SSN])
SELECT 
    StaffId,
    CASE StaffId
        WHEN 1 THEN '123-45-6789'
        WHEN 2 THEN '234-56-7890'
        WHEN 3 THEN '345-67-8901'
        WHEN 4 THEN '456-78-9012'
        WHEN 5 THEN '567-89-0123'
        WHEN 6 THEN '678-90-1234'
        WHEN 7 THEN '789-01-2345'
        WHEN 8 THEN '890-12-3456'
        WHEN 9 THEN '901-23-4567'
        WHEN 10 THEN '012-34-5678'
    END
FROM StaffMembers
ORDER BY StaffId;

SELECT * FROM StaffMembers
SELECT * FROM Employees ORDER BY EmployeeId
SELECT * FROM Employees E inner join StaffMembers S ON S.StaffId = E.EmployeeId
ORDER BY E.EmployeeId



-- Insert Hourly Employee
BEGIN TRANSACTION;
-- Step 1: Add Staff Member
INSERT INTO [dbo].[StaffMembers] ([Name],[Phone],[Email],[DepartmentId],[Type])
VALUES
('Muhammed Ali', '01277470639', 'muhammed9@gmail.com', 3, 'Hourly')

DECLARE @StaffId INT = SCOPE_IDENTITY(); -- Return Last StaffId

-- Step 2: Add Employee
INSERT INTO [dbo].[Employees] ([EmployeeId],[SSN])
VALUES(@StaffId,'30204221302418')

-- Step 3: Add Hourly Employee
INSERT INTO [dbo].[HourlyEmployees] ([HEmployeeId],[Rate],[Hours])
VALUES(@StaffId,30.00,20)
COMMIT TRANSACTION;

SELECT * FROM Employees E inner join StaffMembers S ON E.EmployeeId = S.StaffId
ORDER BY E.EmployeeId



INSERT INTO [dbo].[Projects] (Location, CurrentCost, ManagerStaffId)
VALUES
('Cairo',     12000.50, 1),
('Alex',      15000.75, 2),
('Giza',      18000.25, 3),
('Luxor',      9500.00, 4),
('Aswan',     20000.00, 5),
('Tanta',     17500.60, 6),
('Mansoura',  22000.40, 1),
('Suez',      12500.10, 2),
('Ismailia',  13500.90, 3),
('Hurghada',  24500.00, 4);

SELECT P.ProjectId, P.Location,P.CurrentCost, P.ManagerStaffId, S.Name, S.DepartmentId, S.Type
FROM Projects P INNER JOIN StaffMembers s ON S.StaffId = P.ManagerStaffId

