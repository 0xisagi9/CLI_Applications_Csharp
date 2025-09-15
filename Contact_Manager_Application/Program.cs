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

        Console.Clear();
        Console.WriteLine("===================================================");
        Console.WriteLine("              Enter User Information               ");
        Console.WriteLine("===================================================");
        newUser.Id = int.Parse(ReadInput("Enter Id: "));
        newUser.Firstname = ReadInput("Enter First Name: ");
        newUser.Lastname = ReadInput("Enter Last Name: ");
        newUser.Gender = ReadInput("Enter Gender: ");
        newUser.City = ReadInput("Enter City: ");

        // Address
        do
        {
            newUser.AddAddress(AddressHelper());

        } while (ReadInput("Add another Address? (Yes/No): ").Equals("Yes", StringComparison.OrdinalIgnoreCase));

        // Phone
        do
        {
            newUser.AddPhone(PhoneHelper());

        } while (ReadInput("Add another Phone? (Yes/No): ").Equals("Yes", StringComparison.OrdinalIgnoreCase));

        // Email

        do
        {
            newUser.AddEmail(EmailHepler());

        } while (ReadInput("Add another Email? (Yes/No): ").Equals("Yes", StringComparison.OrdinalIgnoreCase));
        return newUser;
    }

    static Address AddressHelper()
    {
        return new Address
        {
            HomeAddress = ReadInput("Enter Home Address: "),
            Type = ReadInput("Enter Address Type: "),
            Description = ReadInput("Enter Address Description: ")

        };
    }

    static Phone PhoneHelper()
    {
        return new Phone
        {
            PhoneNumber = ReadInput("Enter Phone Number : "),
            Type = ReadInput("Enter Phone Type: "),
            Description = ReadInput("Enter Phone Description: ")
        };

    }

    static EmailAddress EmailHepler()
    {
        return new EmailAddress
        {
            Email = ReadInput("Enter Email Address: "),
            Type = ReadInput("Enter Email Type: "),
            Description = ReadInput("Enter Email Description: ")
        };
    }

    static string ReadInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine()!;
    }



}


