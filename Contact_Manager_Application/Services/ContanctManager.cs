using Contact_Manager_Application.Models;
using Contact_Manager_Application.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void UdateUser(User user)
    {
        User updUser = _users.FirstOrDefault(u => u.Id == user.Id) ?? throw new Exception("User with this Id Not Found");
        updUser.Id = user.Id;
        updUser.Firstname = user.Firstname;
        updUser.Lastname = user.Lastname;
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
