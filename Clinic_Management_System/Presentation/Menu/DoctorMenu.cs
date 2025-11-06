using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Business.Services;
using Clinic_Management_System.Core.Utilites;
namespace Clinic_Management_System.Presentation.Menu;

internal class DoctorMenu
{
    public static void ShowDoctorMenu(User doctor, DoctorService doctorService)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("              👨‍⚕️ Doctor Dashboard");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome, {doctor.Name}!");
            Console.WriteLine("Please choose an operation:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1️  View Appointments");
            Console.WriteLine("2️  Add Appointment Slot");
            Console.WriteLine("3️  Update Appointment Slot");
            Console.WriteLine("4️  Cancel Appointment");
            Console.WriteLine("5️  View My Patients");
            Console.WriteLine("6️  Update My Profile");
            Console.WriteLine("7️  Logout");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();

            string choice = InputUtility.ReadInput("Enter your choice: ");

            switch (choice)
            {
                case "1":
                    ViewAppointments(doctor, doctorService);
                    break;

                case "2":
                    AddAppointmentSlot(doctor, doctorService);
                    break;

                case "3":
                    UpdateAppointmentSlot(doctor, doctorService);
                    break;

                case "4":
                    CancelAppointment(doctor, doctorService);
                    break;

                case "5":
                    // TODO: View My Patients
                    break;

                case "6":
                    // TODO: Update My Profile
                    break;

                case "7":
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
    private static void ViewAppointments(User doctor, DoctorService doctorService)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║     📅  Appointments for Dr. {doctor.Name,-35} ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        Console.ResetColor();

        var slots = doctorService.GetAllSlots(doctor.UserId).ToList();

        if (slots.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ No appointments found.");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            return;
        }


        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n──────────────────────────────────────────────────────────────────────────");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{"ID",-5} {"Start Time",-22} {"End Time",-22} {"Booked",-9} {"Active",-8}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("────────────────────────────────────────────────────────────────────────────");
        Console.ResetColor();


        foreach (var slot in slots)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{slot.SlotId,-5}");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{slot.StartTime,-22:yyyy-MM-dd HH:mm}");
            Console.Write($"{slot.EndTime,-22:yyyy-MM-dd HH:mm}");

            if (slot.IsBooked)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{"Yes",-9}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{"No",-9}");
            }

            Console.ForegroundColor = slot.IsActive ? ConsoleColor.Green : ConsoleColor.DarkRed;
            Console.WriteLine(slot.IsActive ? "Active" : "Inactive");

            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("──────────────────────────────────────────────────────────────\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Total Slots: {slots.Count}");
        Console.ResetColor();

        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private static void AddAppointmentSlot(User doctor, DoctorService doctorService)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🕒 Add New Appointment Slot");
        Console.ResetColor();
        Console.WriteLine("---------------------------------------------");

        try
        {
            string startInput = InputUtility.ReadInput("Enter Start Time (yyyy-MM-dd HH:mm): ");
            string endInput = InputUtility.ReadInput("Enter End Time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(startInput, out DateTime startTime) ||
                !DateTime.TryParse(endInput, out DateTime endTime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid date/time format. Please use: yyyy-MM-dd HH:mm");
                Console.ResetColor();
                return;
            }


            doctorService.AddNewAppointmentSlot(doctor.UserId, new AppointmentSlot(doctor.UserId, startTime, endTime));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Appointment slot added successfully!");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }

    private static void UpdateAppointmentSlot(User doctor, DoctorService doctorService)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("📝 Update Appointment Slot");
        Console.ResetColor();
        Console.WriteLine("---------------------------------------------");

        try
        {

            Console.Write("Enter Slot ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int slotId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid Slot ID.");
                Console.ResetColor();
                return;
            }


            string startInput = InputUtility.ReadInput("Enter Start Time (yyyy-MM-dd HH:mm): ");
            string endInput = InputUtility.ReadInput("Enter End Time (yyyy-MM-dd HH:mm): ");

            if (!DateTime.TryParse(startInput, out DateTime startTime) ||
                !DateTime.TryParse(endInput, out DateTime endTime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid date/time format. Please use: yyyy-MM-dd HH:mm");
                Console.ResetColor();
                return;
            }


            var updatedSlot = new AppointmentSlot
            {
                SlotId = slotId,
                DoctorId = doctor.UserId,
                StartTime = startTime,
                EndTime = endTime,
                IsBooked = false,
                IsActive = true
            };


            doctorService.UpdateAppointmentSlot(doctor.UserId, updatedSlot);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Appointment slot updated successfully!");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }

    private static void CancelAppointment(User doctor, DoctorService doctorService)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🗑️  Delete (Cancel) Appointment Slot");
        Console.ResetColor();
        Console.WriteLine("---------------------------------------------");

        try
        {

            Console.Write("Enter Slot ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int slotId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid Slot ID. Please enter a valid number.");
                Console.ResetColor();
                return;
            }


            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"⚠️  Are you sure you want to delete slot #{slotId}? (y/n): ");
            Console.ResetColor();
            string? confirm = Console.ReadLine()?.Trim().ToLower();

            if (confirm != "y")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("❎ Operation cancelled by user.");
                Console.ResetColor();
                return;
            }


            doctorService.RemoveAppointmentSlot(doctor.UserId, slotId);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ Appointment slot #{slotId} deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}
