USE [Clinic_Management_System]
GO


--					Add IsActive to User Table
ALTER TABLE [User]
ADD IsActive BIT DEFAULT 1;


--					Add IsActive to User Table
ALTER TABLE [AppointmentSlot]
ADD IsActive BIT DEFAULT 1;


