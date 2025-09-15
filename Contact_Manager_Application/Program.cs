using Contact_Manager_Application.Models;
using Contact_Manager_Application.Services;
using Contact_Manager_Application.Utilities;
using Contact_Manager_Application.UI;
using System.Runtime.Serialization;

namespace Contact_Manager_Application;

internal class Program
{
    static void Main()
    {


        try
        {
            bool ProgramRun = true;
            ContanctManager Service = new();
            var user1 = new User(
    1,
    "Ahmed",
    "Ali",
    "Male",
    "Cairo",
    new Address("Cairo", "Home", "Main Flat"),
    new Phone("0101234567", "Mobile", "Personal Phone"),
    new EmailAddress("ahmed.ali@gmail.com", "Personal", "Primary Email")
);
            Service.AddUser(user1);

            while (ProgramRun)
            {
                Console.Clear();
                Menu.ShowMainMenu();
                Console.WriteLine("Enter Your Choice");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": // Add User
                        Service.AddUser(ContanctManager.BuildUser());
                        Console.WriteLine("\n User added successfully!");
                        break;
                    case "2": // Update User
                        int updId = int.Parse(InputUtility.ReadInput("Enter Id:"));
                        Service.UdateUser(updId);
                        break;

                    case "3": // Delete User
                        int delId = int.Parse(InputUtility.ReadInput("Enter Id to delete:"));
                        Service.RemoveUser(delId);
                        Console.WriteLine("\n Student deleted successfully!");
                        break;
                    case "4": // Display User

                        break;

                    case "5": // Display All Users
                        Service.ShowAllUsers();
                        break;
                    case "6":
                        ProgramRun = false;
                        Console.WriteLine("\n Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\n Invalid choice, please try again.");
                        break;

                }

                if (ProgramRun)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }





}


