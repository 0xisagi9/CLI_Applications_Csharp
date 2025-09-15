using Contact_Manager_Application.Models;
using Contact_Manager_Application.Utilities;
using Contact_Manager_Application.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Contact_Manager_Application.Services;

internal class ContanctManager
{
    private readonly List<User> _users;


    public ContanctManager()
    {
        _users = [];
    }

    public void AddUser(User user)
    {
        if (_users.Any(s => s.Id == user.Id))
            throw new Exception("User with the Same Id already Exist");
        _users.Add(user);
    }

    public void UdateUser(int id)
    {
        User updUser = _users.FirstOrDefault(u => u.Id == id) ?? throw new Exception("User not Found");
        bool keepRunning = true;
        while (keepRunning)
        {
            Menu.ShowUpdateMenu(updUser);
            string choice = InputUtility.ReadInput("Enter Your Choice");

            switch (choice)
            {
                case "1":
                    updUser.Firstname = InputUtility.ReadInput("Enter new First Name: ");
                    break;

                case "2":
                    updUser.Lastname = InputUtility.ReadInput("Enter new Last Name: ");
                    break;

                case "3":
                    updUser.Gender = InputUtility.ReadInput("Enter new Gender: ");
                    break;

                case "4":
                    updUser.City = InputUtility.ReadInput("Enter new City: ");
                    break;

                case "5":
                    updUser.AddEmail(UserDataFactory.EmailHepler());
                    break;

                case "6":
                    updUser.AddPhone(UserDataFactory.PhoneHelper());
                    break;

                case "7":
                    updUser.AddAddress(UserDataFactory.AddressHelper());
                    break;

                case "0":
                    keepRunning = false;
                    Console.WriteLine("\n Exiting Update Menu...");
                    break;

                default:
                    Console.WriteLine(" Invalid option, please try again.");
                    break;
            }
            if (keepRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

        }

    }

    public void RemoveUser(int id)
    {
        User delUser = _users.FirstOrDefault(s => s.Id == id) ?? throw new Exception("Use with the Same Id Not Found");
        _users.Remove(delUser);
    }


    public void ShowAllUsers()
    {
        if (_users.Count == 0)
        {
            Console.WriteLine("No users found.");
            return;
        }
        foreach (var user in _users)
            user.ShowUser();
    }

    public static User BuildUser()
    {
        User newUser = new();


        Console.Clear();
        Console.WriteLine("===================================================");
        Console.WriteLine("              Enter User Information               ");
        Console.WriteLine("===================================================");

        newUser.Id = int.Parse(InputUtility.ReadInput("Enter Id: "));
        newUser.Firstname = InputUtility.ReadInput("Enter First Name: ");
        newUser.Lastname = InputUtility.ReadInput("Enter Last Name: ");
        newUser.Gender = InputUtility.ReadInput("Enter Gender: ");
        newUser.City = InputUtility.ReadInput("Enter City: ");

        // Address
        do
        {
            newUser.AddAddress(UserDataFactory.AddressHelper());

        } while (InputUtility.ReadInput("Add another Address? (Yes/No): ").Equals("Yes", StringComparison.OrdinalIgnoreCase));

        // Phone
        do
        {
            newUser.AddPhone(UserDataFactory.PhoneHelper());

        } while (InputUtility.ReadInput("Add another Phone? (Yes/No): ").Equals("Yes", StringComparison.OrdinalIgnoreCase));

        // Email

        do
        {
            newUser.AddEmail(UserDataFactory.EmailHepler());

        } while (InputUtility.ReadInput("Add another Email? (Yes/No): ").Equals("Yes", StringComparison.OrdinalIgnoreCase));
        return newUser;
    }
}
