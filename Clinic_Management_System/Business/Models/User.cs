

using System.Runtime;

namespace Clinic_Management_System.Business.Models;

internal class User
{
    public int UserId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public bool IsActive { get; set; }


    public User() { }
    public User(int id, string name, string email, string password, string role, bool isActive)
    {
        UserId = id;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        IsActive = isActive;
    }
    public User(int id, string name, string email, string password, string role)
    {
        UserId = id;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }
    public User(string name, string email, string password, string role)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }


    public override string ToString() => $"Id: {UserId}, Name: {Name}, Email:{Email}, Role: {Role}";


}
