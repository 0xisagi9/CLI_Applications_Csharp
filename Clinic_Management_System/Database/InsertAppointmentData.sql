USE [Clinic_Management_System]
GO

-- Insert 2 appointment slots for each doctor (total 10 slots)
INSERT INTO [dbo].[AppointmentSlot] ([DoctorId], [StartTime], [EndTime], [IsBooked])
VALUES
-- Slots for Dr. Sarah Johnson (DoctorId: 1)
(1, '2024-01-15 09:00:00', '2024-01-15 10:00:00', 0),
(1, '2024-01-15 14:00:00', '2024-01-15 15:00:00', 0),

-- Slots for Dr. Michael Chen (DoctorId: 2)
(2, '2024-01-15 10:00:00', '2024-01-15 11:00:00', 0),
(2, '2024-01-15 15:00:00', '2024-01-15 16:00:00', 0),

-- Slots for Dr. Emily Davis (DoctorId: 3)
(3, '2024-01-15 11:00:00', '2024-01-15 12:00:00', 0),
(3, '2024-01-16 09:00:00', '2024-01-16 10:00:00', 0),

-- Slots for Dr. Robert Wilson (DoctorId: 4)
(4, '2024-01-16 10:00:00', '2024-01-16 11:00:00', 0),
(4, '2024-01-16 14:00:00', '2024-01-16 15:00:00', 0),

-- Slots for Dr. Jennifer Martinez (DoctorId: 5)
(5, '2024-01-16 11:00:00', '2024-01-16 12:00:00', 0),
(5, '2024-01-16 15:00:00', '2024-01-16 16:00:00', 0);







INSERT INTO [dbo].[Appointment] ([SlotId], [PatientId], [Status])
VALUES
-- Cardiology appointments
(1, 6, 'Confirmed'),      -- Dr. Sarah Johnson for John Smith (Hypertension)
(2, 7, 'Scheduled'),     -- Dr. Sarah Johnson for Maria Garcia (Diabetes)

-- Neurology appointments  
(3, 8, 'Completed'),     -- Dr. Michael Chen for David Brown (Asthma)
(4, 9, 'Confirmed'),     -- Dr. Michael Chen for Lisa Thompson (Migraine)

-- Pediatrics appointments
(5, 10, 'Scheduled'),    -- Dr. Emily Davis for James Wilson (Arthritis)
(6, 11, 'Cancelled'),    -- Dr. Emily Davis for Susan Anderson (Allergies)

-- Orthopedics appointments
(7, 12, 'Confirmed'),    -- Dr. Robert Wilson for Kevin Lee (Back pain)
(8, 13, 'Scheduled'),    -- Dr. Robert Wilson for Amanda White (Anxiety)

-- Dermatology appointments
(9, 14, 'Completed'),    -- Dr. Jennifer Martinez for Brian Clark (High cholesterol)
(10, 15, 'Scheduled');   -- Dr. Jennifer Martinez for Rachel Taylor (Thyroid condition)

-- Update the slots to mark them as booked
UPDATE [dbo].[AppointmentSlot] 
SET [IsBooked] = 1 
WHERE [SlotId] IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10);


