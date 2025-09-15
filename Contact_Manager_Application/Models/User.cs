using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Models;

internal class User
{
    private int _id;
    private string _firstname = string.Empty;
    private string _lastname = string.Empty;
    private string _gender = string.Empty;
    private string _city = string.Empty;
    private readonly DateTime _addedDate;
    private readonly List<Address> _addresses = [];
    private readonly List<Phone> _phones = [];
    private readonly List<EmailAddress> _emails = [];

    public int Id
    {
        get => this._id;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            this._id = value;
        }
    }
    public string Firstname
    {
        get => this._firstname;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            this._firstname = value;
        }
    }
    public string Lastname
    {
        get => this._lastname;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            this._lastname = value;
        }
    }

    public string Gender
    {
        get => this._gender;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            this._gender = value;

        }
    }

    public string City
    {
        get => this._city;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            this._city = value;
        }
    }

    public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();
    public IReadOnlyList<Phone> Phones => _phones.AsReadOnly();
    public IReadOnlyList<EmailAddress> Emails => _emails.AsReadOnly();


    public User()
    {
        _addedDate = DateTime.UtcNow;
    }

    public User(int id, string firstname, string lastname, string gender,
        string city, Address address, Phone phone, EmailAddress email)
    {
        this.Id = id;
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.Gender = gender;
        this.City = city;
        _addedDate = DateTime.UtcNow;
        _addresses = [address];
        _phones = [phone];
        _emails = [email];
    }

    public void AddAddress(Address address) => this._addresses.Add(address);
    public void AddPhone(Phone phone) => this._phones.Add(phone);
    public void AddEmail(EmailAddress email) => this._emails.Add(email);

    public void ShowUser()
    {
        Console.Clear();
        Console.WriteLine("=================================================================");
        Console.WriteLine($"USER INFORMATION (ID: {Id})");
        Console.WriteLine("=================================================================");

        Console.WriteLine($"{"Field",-12} | {"Value",-30}");
        Console.WriteLine(new string('-', 50));

        Console.WriteLine($"{"Name",-12} | {Firstname} {Lastname}");
        Console.WriteLine($"{"Gender",-12} | {Gender}");
        Console.WriteLine($"{"City",-12} | {City}");
        Console.WriteLine($"{"Added Date",-12} | {_addedDate}");

        Console.WriteLine("\n-- Addresses --");
        Console.WriteLine($"{"Type",-12} | {"Address",-30} | {"Description",-20}");
        Console.WriteLine(new string('-', 70));
        foreach (var addr in _addresses)
            Console.WriteLine($"{addr.Type,-12} | {addr.HomeAddress,-30} | {addr.Description,-20}");

        Console.WriteLine("\n-- Phones --");
        Console.WriteLine($"{"Type",-12} | {"Phone",-20} | {"Description",-20}");
        Console.WriteLine(new string('-', 60));
        foreach (var ph in _phones)
            Console.WriteLine($"{ph.Type,-12} | {ph.PhoneNumber,-20} | {ph.Description,-20}");

        Console.WriteLine("\n-- Emails --");
        Console.WriteLine($"{"Type",-12} | {"Email",-30} | {"Description",-20}");
        Console.WriteLine(new string('-', 70));
        foreach (var em in _emails)
            Console.WriteLine($"{em.Type,-12} | {em.Email,-30} | {em.Description,-20}");

        Console.WriteLine("\n=================================================================\n");
    }

}
