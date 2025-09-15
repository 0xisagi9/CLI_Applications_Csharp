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

                        break;
                    case "2": // Update User
                        break;

                    case "3": // Delete User
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


