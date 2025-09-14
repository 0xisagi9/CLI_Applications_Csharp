using Contact_Manager_Application.Models;
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
}
