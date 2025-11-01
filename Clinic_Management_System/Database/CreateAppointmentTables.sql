USE [Clinic_Management_System]
GO

CREATE TABLE [dbo].[AppointmentSlot]
(
[SlotId] INT IDENTITY(1,1) NOT NULL,
[DoctorId] INT NOT NULL,
[StartTime] SMALLDATETIME,
[EndTime] SMALLDATETIME,
[IsBooked] BIT


CONSTRAINT [PK_AppointmentSlot] PRIMARY KEY CLUSTERED ([SlotId] ASC),
CONSTRAINT [FK_AppointmentSlot_Doctor] FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctor]([DoctorId])
)


CREATE TABLE [dbo].[Appointment]
(
[AppointmentId] INT IDENTITY(1,1) NOT NULL,
[SlotId] INT NOT NULL,
[PatientId] INT NOT NULL,
[Status] VARCHAR(50) NOT NULL


CONSTRAINT [PK_AppointmenT] PRIMARY KEY CLUSTERED ([AppointmentId] ASC), 
CONSTRAINT [FK_Appointment_Slot] FOREIGN KEY ([SlotId]) REFERENCES [dbo].[AppointmentSlot]([SlotId]),
CONSTRAINT [FK_Appointment_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient]([PatientId])
)