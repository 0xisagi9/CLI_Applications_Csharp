using Clinic_Management_System.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Presentation.Menu;

internal class WelcomMenu
{
    public static void WelcomeToApplication(AuthService authService, DoctorService doctorService, PatientService patientService, AppointmentService appointmentService, AppointmentSlotService appointmentSlotService)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║     🏥  Clinic Management System       ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\nChoose an action:\n");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(" [1]    Sign Up (Create new account)");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" [2]    Login (Access your account)");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" [0]    Exit the system");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nSelect option: ");
        string choice = Console.ReadLine() ?? "";
        switch (choice)
        {
            case "1":
                AuthMenu.SingUpMenu(authService);
                break;
            case "2":
                AuthMenu.LoginMenu(authService, doctorService, patientService);
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n❌ Invalid choice! Please try again.");
                Console.ResetColor();
                Console.ReadKey();
                break;
        }
    }
}
