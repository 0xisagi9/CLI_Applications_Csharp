USE [Clinic_Management_System]
GO
/*  ************************************************************************************
                                    Stored Procedure: Add Doctor 
***************************************************************************************** */
CREATE PROCEDURE AddDoctor
    @Name VARCHAR(50),
    @Role VARCHAR(50),
    @Email VARCHAR(50),
    @Password VARCHAR(50),
    @Specification VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check Email Already Exist
        IF EXISTS (SELECT 1 FROM [User] WHERE Email = @Email)
        BEGIN 
            RAISERROR('Email Already Exist',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Step 1: Insert into User table
        INSERT INTO [User] (Name, Role, Email, Password)
        VALUES (@Name, @Role, @Email, @Password);

        DECLARE @UserId INT = SCOPE_IDENTITY();

        -- Step 2: Insert into Doctor table
        INSERT INTO Doctor (DoctorId, Specification)
        VALUES (@UserId, @Specification);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage,16,1);
    END CATCH
END
GO

/*  ************************************************************************************
                                    Stored Procedure: Deactivate Doctor 
***************************************************************************************** */

CREATE PROCEDURE DeactivateDoctor
    @DoctorID INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1 Deactivate the doctor (in USER)
        UPDATE [User]
        SET IsActive = 0
        WHERE UserID = @DoctorID;

        -- 2 Deactivate the doctor's slots
        UPDATE APPOINTMENTSLOT
        SET IsActive = 0
        WHERE DoctorID = @DoctorID;

        -- 3 Cancel any future appointments for that doctor
        UPDATE APPOINTMENT
        SET Status = 'Cancelled'
        WHERE SlotID IN (
            SELECT SlotID
            FROM APPOINTMENTSLOT
            WHERE DoctorID = @DoctorID
        )

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/*  ************************************************************************************
                                    Stored Procedure: Update Doctor 
***************************************************************************************** */
CREATE PROCEDURE UpdateDoctor
    @DoctorId INT,
    @Name VARCHAR(50),
    @Email VARCHAR(50),
    @Password VARCHAR(50),
    @Role VARCHAR(50),
    @Specification VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- 1️ Check if Doctor exists
    IF NOT EXISTS (SELECT 1 FROM Doctor WHERE DoctorId = @DoctorId)
    BEGIN
        RAISERROR('Doctor not found.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [User]
        SET 
            [Name] = @Name,
            [Email] = @Email,
            [Password] = @Password,
            [Role] = @Role
        WHERE [UserId] = @DoctorId;

      
        UPDATE [Doctor]
        SET [Specification] = @Specification
        WHERE [DoctorId] = @DoctorId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity INT;
        SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY();
        RAISERROR(@ErrMsg, @ErrSeverity, 1);
    END CATCH
END
GO
/*  ************************************************************************************
                                    Stored Procedure: Add Patient 
***************************************************************************************** */
CREATE PROCEDURE AddPatient
    @Name VARCHAR(50),
    @Role VARCHAR(50),
    @Email VARCHAR(50),
    @Password VARCHAR(50),
    @MedicalNotes VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check Email Already Exist
        IF EXISTS (SELECT 1 FROM [User] WHERE Email = @Email)
        BEGIN 
            RAISERROR('Email Already Exist',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Step 1: Insert into User table
        INSERT INTO [User] (Name, Role, Email, Password)
        VALUES (@Name, @Role, @Email, @Password);

        DECLARE @UserId INT = SCOPE_IDENTITY();

        -- Step 2: Insert into Patient table
        INSERT INTO Patient (PatientId, MedicalNotes)
        VALUES (@UserId, @MedicalNotes);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage,16,1);
    END CATCH
END
GO

/*  ************************************************************************************
                                    Stored Procedure: Deactivate Patient 
***************************************************************************************** */

CREATE PROCEDURE DeactivatePatient
    @PatientId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if Patient exists and active
    IF NOT EXISTS (SELECT 1 FROM [User] WHERE UserId = @PatientId AND IsActive = 1)
    BEGIN
        PRINT 'Patient not found or already inactive.';
        RETURN;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Step 1: Deactivate the Patient
        UPDATE [User]
        SET IsActive = 0
        WHERE UserId = @PatientId;

        -- Step 2: Deactivate the related User record (if they share the same ID)
        UPDATE [User]
        SET IsActive = 0
        WHERE UserId = @PatientId;

        -- Step 3: Cancel all future Appointments for this patient
        UPDATE Appointment
        SET Status = 'Cancelled'
        WHERE PatientId = @PatientId
        COMMIT TRANSACTION;
        PRINT 'Patient deactivated and appointments cancelled successfully.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Error occurred: ' + ERROR_MESSAGE();
    END CATCH;
END;
GO

/*  ************************************************************************************
                                    Stored Procedure: Update Patient 
***************************************************************************************** */
CREATE PROCEDURE UpdatePatient
    @PatientId INT,
    @Name VARCHAR(50),
    @Email VARCHAR(50),
    @Password VARCHAR(50),
    @Role VARCHAR(50),
    @MedicalNotes VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if Patient exists
        IF NOT EXISTS (SELECT 1 FROM [User] WHERE UserId = @PatientId)
        BEGIN 
            RAISERROR('Patient does not exist',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Check if Email already exists for another user
        IF EXISTS (SELECT 1 FROM [User] WHERE Email = @Email AND UserId != @PatientId)
        BEGIN 
            RAISERROR('Email Already Exist for another user',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Step 1: Update User table
        UPDATE [User] 
        SET Name = @Name, 
            Email = @Email, 
            Password = @Password, 
            Role = @Role
        WHERE UserId = @PatientId;

        -- Step 2: Update Patient table
        UPDATE Patient 
        SET MedicalNotes = @MedicalNotes
        WHERE PatientId = @PatientId;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage,16,1);
    END CATCH
END
GO


SELECT * FROM [User]


