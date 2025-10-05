/* *********************************************************
                    Add Hourly Employee
************************************************************
*/
GO
CREATE PROCEDURE AddHourlyEmployee
    @Name NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @DepartmentId INT,
    @SSN NVARCHAR(20),
    @Rate DECIMAL(10,2),
    @Hours INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Check Department Id Not Exist
        IF NOT EXISTS (SELECT 1 FROM Department WHERE DepartmentId = @DepartmentId)
        BEGIN 
            RAISERROR('Invalid DepartmentId',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF EXISTS (SELECT 1 FROM Employees WHERE SSN = @SSN)
        BEGIN 
            RAISERROR('SSN Already Exist',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        INSERT INTO StaffMembers (Name, Phone, Email, DepartmentId, Type)
        VALUES (@Name, @Phone, @Email, @DepartmentId, 'Hourly');

        DECLARE @StaffId INT = SCOPE_IDENTITY();

        -- Step 2: Add Employee
        INSERT INTO Employees (EmployeeId, SSN)
        VALUES (@StaffId, @SSN);

        -- Step 3: Add Hourly Employee
        INSERT INTO HourlyEmployees (HEmployeeId, Rate, Hours)
        VALUES (@StaffId, @Rate, @Hours);
    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage,16,1);
    END CATCH
END
GO

 EXEC AddHourlyEmployee 
    @Name = 'Ahmed Ali',
    @Phone = '01012345678',
    @Email = 'ahmed@example.com',
    @DepartmentId = 1,
    @SSN = '987-65-4321',
    @Rate = 30.00,
    @Hours = 20;

    SELECT * FROM StaffMembers S INNER JOIN Employees E ON E.EmployeeId = S.StaffId

/* *********************************************************
                    Add Salaried Employee
************************************************************
*/
GO
CREATE PROCEDURE AddSalariedEmployee
    @Name NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @DepartmentId INT,
    @SSN NVARCHAR(20),
    @Salary DECIMAL(8,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Check Department Id Not Exist
        IF NOT EXISTS (SELECT 1 FROM Department WHERE DepartmentId = @DepartmentId)
        BEGIN 
            RAISERROR('Invalid DepartmentId',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF EXISTS (SELECT 1 FROM Employees WHERE SSN = @SSN)
        BEGIN 
            RAISERROR('SSN Already Exist',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        INSERT INTO StaffMembers (Name, Phone, Email, DepartmentId, Type)
        VALUES (@Name, @Phone, @Email, @DepartmentId,'Salary');

        DECLARE @StaffId INT = SCOPE_IDENTITY();

        -- Step 2: Add Employee
        INSERT INTO Employees (EmployeeId, SSN)
        VALUES (@StaffId, @SSN);

        -- Step 3: Add Salaried Employee
        INSERT INTO SalariedEmployees([SEmployeeId],[Salary])
        VALUES (@StaffId, @Salary);
    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage,16,1);
    END CATCH
END
GO

/* *********************************************************
                    Add Commission Employee
************************************************************
*/
GO
CREATE PROCEDURE AddCommissionEmployee
    @Name NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @DepartmentId INT,
    @SSN NVARCHAR(20),
    @Target DECIMAL(8,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Check Department Id Not Exist
        IF NOT EXISTS (SELECT 1 FROM Department WHERE DepartmentId = @DepartmentId)
        BEGIN 
            RAISERROR('Invalid DepartmentId',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF EXISTS (SELECT 1 FROM Employees WHERE SSN = @SSN)
        BEGIN 
            RAISERROR('SSN Already Exist',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        INSERT INTO StaffMembers (Name, Phone, Email, DepartmentId, Type)
        VALUES (@Name, @Phone, @Email, @DepartmentId,'Commission');

        DECLARE @StaffId INT = SCOPE_IDENTITY();

        -- Step 2: Add Employee
        INSERT INTO Employees (EmployeeId, SSN)
        VALUES (@StaffId, @SSN);

        -- Step 3: Add Salaried Employee
        INSERT INTO CommissionEmployee([CEmployeeId],[Target])
        VALUES (@StaffId, @Target);
    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage,16,1);
    END CATCH
END
GO

/* *********************************************************
                    Add Excecutive Employee
************************************************************
*/
GO
CREATE PROCEDURE AddExecutiveEmployee
    @Name NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @DepartmentId INT,
    @SSN NVARCHAR(20),
    @Salary DECIMAL(8,2),
    @Bonus DECIMAL(8,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Check Department Id Not Exist
        IF NOT EXISTS (SELECT 1 FROM Department WHERE DepartmentId = @DepartmentId)
        BEGIN 
            RAISERROR('Invalid DepartmentId',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF EXISTS (SELECT 1 FROM Employees WHERE SSN = @SSN)
        BEGIN 
            RAISERROR('SSN Already Exist',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        INSERT INTO StaffMembers (Name, Phone, Email, DepartmentId, Type)
        VALUES (@Name, @Phone, @Email, @DepartmentId,'Executive');

        DECLARE @StaffId INT = SCOPE_IDENTITY();

        -- Step 2: Add Employee
        INSERT INTO Employees (EmployeeId, SSN)
        VALUES (@StaffId, @SSN);

        -- Step 3: Add Salaried Employee
        INSERT INTO ExecutiveEmployees([ExEmployeeId],[Salary],[Bonus])
        VALUES (@StaffId, @Salary,@Bonus);
    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage,16,1);
    END CATCH
END
GO

SELECT * FROM StaffMembers