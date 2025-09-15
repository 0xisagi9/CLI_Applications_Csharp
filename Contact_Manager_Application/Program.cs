using Contact_Manager_Application.Models;
using Contact_Manager_Application.Services;
using System.Runtime.Serialization;

namespace Contact_Manager_Application;

internal class Program
{
    static void Main()
    {
        try
        {
            bool ProgramRun = true;
            ContanctManager Database = new();

            while (ProgramRun)
            {
                Console.Clear();
                ShowMainMenu();
                Console.WriteLine("Enter Your Choice");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": // Add User
                        User newUser = AddUserFunctionality();
                        Database.AddUser(newUser);

                        break;
                    case "2": // Update User
                        break;

                    case "3": // Delete User
                        break;
                    case "4": // Display User

                        break;

                    case "5": // Display All Users
                        Database.ShowAllUsers();
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
    static void ShowMainMenu()
    {
        Console.WriteLine("===================================================");
        Console.WriteLine("              Welcome to Our Application           ");
        Console.WriteLine("===================================================");
        Console.WriteLine("  [1]  Add User");
        Console.WriteLine("  [2]  Update User");
        Console.WriteLine("  [3]  Delete User");
        Console.WriteLine("  [4]  Display User");
        Console.WriteLine("  [5]  Display All Users");
        Console.WriteLine("  [6]  Exit");
        Console.WriteLine("===================================================");
    }

    static User AddUserFunctionality()
    {
        User newUser = new();

        bool checkerRun = true;

        Console.Clear();
        Console.WriteLine("===================================================");
        Console.WriteLine("              Enter User Information               ");
        Console.WriteLine("===================================================");
        Console.Write("Enter Id: ");
        newUser.Id = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Firstname: ");
        newUser.Firstname = Console.ReadLine()!;

        Console.Write("Enter Lastname: ");
        newUser.Lastname = Console.ReadLine()!;

        Console.Write("Enter Gender: ");
        newUser.Gender = Console.ReadLine()!;

        Console.Write("Enter City: ");
        newUser.City = Console.ReadLine()!;

        Console.WriteLine("---- Address Information -----");
        Address newAdd = AddressHelper();
        newUser.AddAddress(newAdd);

        while (checkerRun)
        {

            Console.WriteLine(" ----- Add Another Address -----");
            Console.WriteLine("Enter Chioce (Yes | No):");
            string? chioce = Console.ReadLine()!;
            switch (chioce)
            {
                case "Yes":
                    Console.WriteLine("---- Address Information -----");
                    Address newExtraAdd = AddressHelper();
                    newUser.AddAddress(newExtraAdd);
                    break;

                case "No":
                    checkerRun = false;
                    Console.WriteLine("\n Exiting...");

                    break;

                default:
                    Console.WriteLine("\n Invailid Option");
                    break;
            }

            if (checkerRun)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }



        Console.WriteLine("---- Phone Information -----");
        Phone newPHone = PhoneHelper();
        newUser.AddPhone(newPHone);

        Console.WriteLine("---- Email Information -----");
        EmailAddress newEmail = EmailHepler();
        newUser.AddEmail(newEmail);


        return newUser;
    }

    static Address AddressHelper()
    {
        Address newAdd = new();
        Console.WriteLine("Enter Home Address:");
        newAdd.HomeAddress = Console.ReadLine()!;
        Console.WriteLine("Enter Address Type:");
        newAdd.Type = Console.ReadLine()!;
        Console.WriteLine("Enter Description:");
        newAdd.Description = Console.ReadLine()!;

        return newAdd;
    }

    static Phone PhoneHelper()
    {
        Phone newPhone = new();
        Console.WriteLine("Enter Phone Number:");
        newPhone.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine("Enter Phone Type:");
        newPhone.Type = Console.ReadLine()!;
        Console.WriteLine("Enter Description:");
        newPhone.Description = Console.ReadLine()!;

        return newPhone;

    }

    static EmailAddress EmailHepler()
    {
        EmailAddress newEmail = new();
        Console.WriteLine("Enter Email Address");
        newEmail.Email = Console.ReadLine()!;
        Console.WriteLine("Enter Email Type:");
        newEmail.Type = Console.ReadLine()!;
        Console.WriteLine("Enter Description:");
        newEmail.Description = Console.ReadLine()!;

        return newEmail;
    }



}


