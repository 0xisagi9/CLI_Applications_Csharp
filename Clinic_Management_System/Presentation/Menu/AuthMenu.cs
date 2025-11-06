using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Business.Services;
using Clinic_Management_System.Core.Utilites;

namespace Clinic_Management_System.Presentation.Menu;

internal class AuthMenu
{
    public static void SingUpMenu(AuthService authService)
    {
        Console.Clear();


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("                SIGN UP ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("---------------------------------------------");
        Console.ResetColor();
        Console.WriteLine("Please enter your details below:");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("---------------------------------------------");
        Console.ResetColor();


        Console.ForegroundColor = ConsoleColor.White;
        string name = InputUtility.ReadInput("👤  Name      : ");
        string email = InputUtility.ReadInput("📧  Email     : ");
        string password = InputUtility.ReadInput("🔒  Password  : ");
        string role = InputUtility.ReadInput("🎭  Role (Doctor/Patient)    : ");

        try
        {
            var user = new User(name, email, password, role);
            authService.SignUp(user);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Account created successfully!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ {ex.Message}");
        }

    }

    public static void LoginMenu(AuthService authService, DoctorService doctorService, PatientService patientService)
    {
        bool loggedIn = false;

        while (!loggedIn)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                🔐 LOGIN MENU");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Please enter your credentials:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.White;
            string email = InputUtility.ReadInput("📧  Email     : ");
            string password = InputUtility.ReadInput("🔒  Password  : ");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n---------------------------------------------");
            Console.ResetColor();

            try
            {
                var user = authService.Login(email, password);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✅ Login successful! Welcome, {user.Name}");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();


                if (user.Role.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
                    DoctorMenu.ShowDoctorMenu(user, doctorService);
                else
                    PatientMenu.ShowPaitentMenu(user, patientService);

                loggedIn = true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ {ex.Message}");
                Console.ResetColor();

                Console.WriteLine("\nWould you like to try again? (y/n): ");
                string? retry = Console.ReadLine()?.Trim().ToLower();

                if (retry != "y")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nLogin cancelled.");
                    Console.ResetColor();
                    break;
                }
            }
        }
    }
}
