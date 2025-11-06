USE [Clinic_Management_System]
GO

--															Create User Table

CREATE TABLE [dbo].[User]
(
[UserId] INT IDENTITY(1,1) NOT NULL,
[Name] VARCHAR(50) NOT NULL,
[Role] VARCHAR(50) NOT NULL,
[Email] VARCHAR(50) NOT NULL,
[Password] VARCHAR(50) NOT NULL,

CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
CONSTRAINT [UQ_User_Email] UNIQUE ([Email])
)

--															Create Doctor Table
CREATE TABLE [dbo].[Doctor]
(
[DoctorId] INT NOT NULL,
[Specification] VARCHAR(50) NULL,
CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED ([DoctorId] ASC),
CONSTRAINT [FK_Doctor_User] FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[User]([UserId]) ON DELETE CASCADE
)

ALTER TABLE [dbo].[Doctor]
ALTER COLUMN [Specification] VARCHAR(50) NULL;

--															Create Patient Table

CREATE TABLE [dbo].[Patient]
(
[PatientId] INT NOT NULL,
[MedicalNotes] VARCHAR(50) NULL,
CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED ([PatientId] ASC),
CONSTRAINT [FK_Patient_User] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[User]([UserId]) ON DELETE CASCADE
)

