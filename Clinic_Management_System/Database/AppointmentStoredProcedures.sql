/*  ************************************************************************************
                                    Stored Procedure:  Add Appointment   
***************************************************************************************** */
CREATE PROCEDURE AddAppointment
    @SlotId INT,
    @PatientId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if Slot exists
        IF NOT EXISTS (SELECT 1 FROM AppointmentSlot WHERE SlotId = @SlotId)
        BEGIN 
            RAISERROR('Invalid SlotId',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Check if Patient exists
        IF NOT EXISTS (SELECT 1 FROM Patient WHERE PatientId = @PatientId)
        BEGIN 
            RAISERROR('Invalid PatientId',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Check if Slot is already booked
        IF EXISTS (SELECT 1 FROM AppointmentSlot WHERE SlotId = @SlotId AND IsBooked = 1)
        BEGIN 
            RAISERROR('Slot is already booked',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Insert into Appointment table
        INSERT INTO Appointment (SlotId, PatientId, Status)
        VALUES (@SlotId, @PatientId, 'Schedule');
        
        -- Update the slot to mark as booked
        UPDATE AppointmentSlot 
        SET IsBooked = 1
        WHERE SlotId = @SlotId;
        
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
                                    Stored Procedure: Update Appointment 
***************************************************************************************** */
CREATE PROCEDURE UpdateAppointmentSlot
    @SlotId INT,
    @DoctorId INT = NULL,
    @StartTime SMALLDATETIME = NULL,
    @EndTime SMALLDATETIME = NULL,
    @IsBooked BIT = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if slot exists
    IF NOT EXISTS (SELECT 1 FROM [dbo].[AppointmentSlot] WHERE [SlotId] = @SlotId)
    BEGIN
        RAISERROR('Appointment slot not found.', 16, 1);
        RETURN;
    END

    -- Check if changing DoctorId and verify the doctor owns the slot
    IF @DoctorId IS NOT NULL 
    BEGIN
        IF NOT EXISTS (
            SELECT 1 
            FROM [dbo].[AppointmentSlot] 
            WHERE [SlotId] = @SlotId AND [DoctorId] = @DoctorId
        )
        BEGIN
            RAISERROR('Doctor does not have access to this slot.', 16, 1);
            RETURN;
        END
    END

    -- Update the appointment slot
    UPDATE [dbo].[AppointmentSlot]
    SET 
        [StartTime] = ISNULL(@StartTime, [StartTime]),
        [EndTime] = ISNULL(@EndTime, [EndTime]),
        [IsBooked] = ISNULL(@IsBooked, [IsBooked]),
        [IsActive] = ISNULL(@IsActive, [IsActive])
    WHERE 
        [SlotId] = @SlotId;

    SELECT 'Success' AS [Status], 'Slot updated successfully' AS [Message];
END;
GO

/*  ************************************************************************************
                                    Stored Procedure: Deactivate Appointment Slot Doctor 
***************************************************************************************** */

CREATE PROCEDURE DeactivateSlot
    @SlotId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if Slot exists
        IF NOT EXISTS (SELECT 1 FROM AppointmentSlot WHERE SlotId = @SlotId)
        BEGIN 
            RAISERROR('Invalid SlotId',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Check if slot is already deactivated
        IF NOT EXISTS (SELECT 1 FROM AppointmentSlot WHERE SlotId = @SlotId AND IsActive = 1)
        BEGIN 
            RAISERROR('Slot is already deactivated',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Deactivate the slot
        UPDATE AppointmentSlot 
        SET IsActive = 0
        WHERE SlotId = @SlotId;
        
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
                                    Stored Procedure: Add Appointment Slot Doctor 
***************************************************************************************** */
CREATE PROCEDURE AddAppointmentSlot
    @DoctorId INT,
    @StartTime SMALLDATETIME,
    @EndTime SMALLDATETIME
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if Doctor exists
        IF NOT EXISTS (SELECT 1 FROM Doctor WHERE DoctorId = @DoctorId)
        BEGIN 
            RAISERROR('Invalid DoctorId',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Validate time range
        IF @StartTime >= @EndTime
        BEGIN 
            RAISERROR('StartTime must be before EndTime',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Insert into AppointmentSlot table
        INSERT INTO AppointmentSlot (DoctorId, StartTime, EndTime)
        VALUES (@DoctorId, @StartTime, @EndTime);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage,16,1);
    END CATCH
END
GO