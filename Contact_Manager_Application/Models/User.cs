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
        Console.WriteLine($"========== {this.Firstname} Information ==========");
        Console.WriteLine($"ID        : {Id}");
        Console.WriteLine($"Name      : {Firstname} {Lastname}");
        Console.WriteLine($"Gender    : {Gender}");
        Console.WriteLine($"City      : {City}");
        Console.WriteLine($"Added Date: {_addedDate}");

        Console.WriteLine("\n-- Addresses --");
        foreach (Address addr in this._addresses)
            Console.WriteLine($"  {addr.HomeAddress}");

        Console.WriteLine("\n-- Phones --");
        foreach (var ph in this._phones)
            Console.WriteLine($"  {ph.PhoneNumber}");

        Console.WriteLine("\n-- Emails --");
        foreach (var em in this._emails)
            Console.WriteLine($"  {em.Email}");

        Console.WriteLine("\n-----------------------------------------------------------------\n");
    }
}
