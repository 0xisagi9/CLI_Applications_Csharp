using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Business.Services;
using Clinic_Management_System.Core.Utilites;
namespace Clinic_Management_System.Presentation.Menu;

internal class PatientMenu
{
    public static void ShowPaitentMenu(User patient, PatientService patientService)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("              🧑‍⚕️ Patient Dashboard");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome, {patient.Name}!");
            Console.WriteLine("Please choose an operation:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1️  View Available Appointment Slots");
            Console.WriteLine("2️  Book Appointment");
            Console.WriteLine("3️  View My Appointments");
            Console.WriteLine("4️  Cancel Appointment");
            Console.WriteLine("5  Update My Profile");
            Console.WriteLine("6  Logout");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();

            string choice = InputUtility.ReadInput("Enter your choice: ");

            switch (choice)
            {
                case "1":
                    ViewAllAvailableSlots(patient, patientService);
                    break;

                case "2":
                    BookAppointment(patient, patientService);
                    break;
                case "3":
                    ViewMyAppointments(patient, patientService);
                    break;

                case "4":
                    CancelAppointment(patient, patientService);
                    break;

                case "5":
                    UpdateMyProfile(patient, patientService);
                    break;

                case "6":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅  Logged out successfully!");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    isRunning = false;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n❌  Invalid choice! Please try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void ViewAllAvailableSlots(User patient, PatientService patientService)
    {
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("              📅 Available Appointment Slots");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.ResetColor();

        var availableSlots = patientService.GetAllAvailabeSlots();

        if (availableSlots == null || !availableSlots.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ No available slots at the moment.");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
            return;
        }


        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{"Slot ID",-8} {"Doctor Name",-25} {"Specialization",-20} {"Start Time",-20} {"End Time",-20}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.ResetColor();


        foreach (var slot in availableSlots)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{slot.SlotId,-8}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{slot.Name,-25}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{(string.IsNullOrWhiteSpace(slot.Specification) ? "N/A" : slot.Specification),-20}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{slot.StartTime.ToString("dd/MM/yyyy HH:mm"),-20}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{slot.EndTime.ToString("dd/MM/yyyy HH:mm"),-20}");

            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ End of available slots list.");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void BookAppointment(User patient, PatientService patientService)
    {
        Console.Clear();
        ViewAllAvailableSlots(patient, patientService);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("              📅 Book Appointment");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("--------------------------------------------------");
        Console.ResetColor();
        Console.WriteLine($"Welcome, {patient.Name}! Please enter the following details:");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("--------------------------------------------------");
        Console.ResetColor();


        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("🔢  Slot ID       : ");
        if (!int.TryParse(Console.ReadLine(), out int slotId))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Invalid Slot ID format!");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n🩺 Confirm booking this slot? (y/n): ");
        Console.ResetColor();
        string confirm = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (confirm != "y")
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n⚠️  Booking cancelled by user.");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        try
        {
            var appointment = new Appointment
            {
                SlotId = slotId,
                PatientID = patient.UserId,
                Status = "Scheduled"
            };

            patientService.BookAppointment(appointment);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Appointment booked successfully!");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Failed to book appointment: {ex.Message}");
        }

        Console.ResetColor();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void ViewMyAppointments(User patient, PatientService patientService)
    {
        Console.Clear();

        // === Header ===
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("              📋 My Appointments");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("-------------------------------------------------------------");
        Console.ResetColor();

        try
        {
            var appointments = patientService.ViewPatientAppointment(patient.UserId);

            if (appointments == null || !appointments.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n⚠️  No appointments found for your account.");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to go back...");
                Console.ReadKey();
                return;
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"Appointment ID",-15} {"Slot ID",-10} {"Patient ID",-12} {"Status",-15}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();


            foreach (var appointment in appointments)
            {
                Console.ForegroundColor = appointment.Status switch
                {
                    "Scheduled" => ConsoleColor.Green,
                    "Cancelled" => ConsoleColor.Red,
                    "Completed" => ConsoleColor.Blue,
                    _ => ConsoleColor.White
                };

                Console.WriteLine($"{appointment.AppointmentId,-15} {appointment.SlotId,-10} {appointment.PatientID,-12} {appointment.Status,-15}");
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error: {ex.Message}");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }


    private static void UpdateMyProfile(User patient, PatientService patientService)
    {
        Console.Clear();

        // === Title ===
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("              🧑‍⚕️ Update My Profile");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("-------------------------------------------------------------");
        Console.ResetColor();

        try
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📋 Current Profile Information:");
            Console.ResetColor();

            Console.WriteLine($"👤 Name          : {patient.Name}");
            Console.WriteLine($"📧 Email         : {patient.Email}");
            Console.WriteLine($"🔑 Password      : {patient.Password}");
            Console.WriteLine($"🎭 Role          : {patient.Role}");

            if (patient is Patient p)
            {
                Console.WriteLine($"🩹 Medical Notes : {p.MedicalNotes}");
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("👤  New Name (leave blank to keep): ");
            string name = Console.ReadLine() ?? "";

            Console.Write("📧  New Email (leave blank to keep): ");
            string email = Console.ReadLine() ?? "";

            Console.Write("🔒  New Password (leave blank to keep): ");
            string password = Console.ReadLine() ?? "";

            string notes = "";
            if (patient is Patient)
            {
                Console.Write("🩹  New Medical Notes (leave blank to keep): ");
                notes = Console.ReadLine() ?? "";
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n💾 Confirm update? (y/n): ");
            string confirm = Console.ReadLine()?.Trim().ToLower() ?? "";
            Console.ResetColor();

            if (confirm != "y")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n⚠️  Update cancelled by user.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }


            patient.Name = string.IsNullOrWhiteSpace(name) ? patient.Name : name;
            patient.Email = string.IsNullOrWhiteSpace(email) ? patient.Email : email;
            patient.Password = string.IsNullOrWhiteSpace(password) ? patient.Password : password;

            if (patient is Patient updatedPatient)
            {
                updatedPatient.MedicalNotes = string.IsNullOrWhiteSpace(notes) ? updatedPatient.MedicalNotes : notes;
                patientService.UpdatePatient(updatedPatient);
            }
            else
            {
                throw new Exception("User type is not a Patient — cannot update profile.");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Profile updated successfully!");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error updating profile: {ex.Message}");
        }

        Console.ResetColor();
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    //TODO:
    private static void CancelAppointment(User patient, PatientService patientService)
    {

    }
}





