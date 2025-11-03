USE [Clinic_Management_System]
GO

-- Insert 20 Users
INSERT INTO [dbo].[User] ([Name], [Role], [Email], [Password])
VALUES
-- Doctors (5)
('Dr. Sarah Johnson', 'Doctor', 'sarah.johnson@hospital.com', 'doc123'),
('Dr. Michael Chen', 'Doctor', 'michael.chen@hospital.com', 'doc456'),
('Dr. Emily Davis', 'Doctor', 'emily.davis@hospital.com', 'doc789'),
('Dr. Robert Wilson', 'Doctor', 'robert.wilson@hospital.com', 'doc101'),
('Dr. Jennifer Martinez', 'Doctor', 'jennifer.martinez@hospital.com', 'doc112'),

-- Patients (15)
('John Smith', 'Patient', 'john.smith@email.com', 'patient123'),
('Maria Garcia', 'Patient', 'maria.garcia@email.com', 'patient456'),
('David Brown', 'Patient', 'david.brown@email.com', 'patient789'),
('Lisa Thompson', 'Patient', 'lisa.thompson@email.com', 'patient101'),
('James Wilson', 'Patient', 'james.wilson@email.com', 'patient112'),
('Susan Anderson', 'Patient', 'susan.anderson@email.com', 'patient113'),
('Kevin Lee', 'Patient', 'kevin.lee@email.com', 'patient114'),
('Amanda White', 'Patient', 'amanda.white@email.com', 'patient115'),
('Brian Clark', 'Patient', 'brian.clark@email.com', 'patient116'),
('Rachel Taylor', 'Patient', 'rachel.taylor@email.com', 'patient117'),
('Christopher Moore', 'Patient', 'christopher.moore@email.com', 'patient118'),
('Michelle Harris', 'Patient', 'michelle.harris@email.com', 'patient119'),
('Daniel Martin', 'Patient', 'daniel.martin@email.com', 'patient120'),
('Jessica Lewis', 'Patient', 'jessica.lewis@email.com', 'patient121'),
('Matthew Walker', 'Patient', 'matthew.walker@email.com', 'patient122');

-- Insert 5 Doctors (using the first 5 UserIds)
INSERT INTO [dbo].[Doctor] ([DoctorId], [Specification])
VALUES
(1, 'Cardiology'),
(2, 'Neurology'),
(3, 'Pediatrics'),
(4, 'Orthopedics'),
(5, 'Dermatology');

-- Insert 15 Patients (using the next 15 UserIds, starting from 6)
INSERT INTO [dbo].[Patient] ([PatientId], [MedicalNotes])
VALUES
(6, 'Hypertension - Regular checkups needed'),
(7, 'Diabetes type 2 - Monitoring sugar levels'),
(8, 'Asthma - Uses inhaler as needed'),
(9, 'Migraine - Chronic headaches'),
(10, 'Arthritis - Joint pain management'),
(11, 'Allergies - Seasonal allergies'),
(12, 'Back pain - Physical therapy ongoing'),
(13, 'Anxiety - Medication management'),
(14, 'High cholesterol - Diet and exercise'),
(15, 'Insomnia - Sleep disorder'),
(16, 'Thyroid condition - Hormone therapy'),
(17, 'GERD - Acid reflux management'),
(18, 'Depression - Counseling and medication'),
(19, 'Osteoporosis - Bone density monitoring'),
(20, 'Anemia - Iron supplements');


SELECT * FROM [User] U inner join Doctor D on d.DoctorId = u.UserId
SELECT * FROM AppointmentSlot
