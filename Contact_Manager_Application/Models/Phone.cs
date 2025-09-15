using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Models;

internal class Phone
{
    private string _phoneNumber = string.Empty;
    private string _type = string.Empty;
    private string _description = string.Empty;

    public string PhoneNumber
    {
        get => this._phoneNumber;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            this._phoneNumber = value;
        }
    }

    public string Type
    {
        get => this._type;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            this._type = value;
        }
    }

    public string Description
    {
        get => this._description;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            this._description = value;
        }
    }
    public Phone()
    {

    }
    public Phone(string phoneNumber, string type, string description)
    {
        this._phoneNumber = phoneNumber;
        this._type = type;
        this._description = description;
    }

    public void EditPhone(Phone phone)
    {
        this.PhoneNumber = phone.PhoneNumber;
        this.Type = phone.Type;
        this.Description = phone.Description;
    }


}
