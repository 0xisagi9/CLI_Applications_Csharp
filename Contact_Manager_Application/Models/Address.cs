using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Models;

internal class Address
{
    private string _address = string.Empty;
    private string _type = string.Empty;
    private string _description = string.Empty;

    public string HomeAddress
    {
        get => this._address;
        set
        {
            ArgumentNullException.ThrowIfNull(nameof(value));
            this._address = value;
        }
    }

    public string Type
    {
        get => this._type;
        set
        {
            ArgumentNullException.ThrowIfNull(nameof(value));
            this._type = value;
        }
    }

    public string Description
    {
        get => this._description;
        set
        {
            ArgumentNullException.ThrowIfNull(nameof(value));
            this._description = value;
        }
    }


    public Address(string address, string type, string description)
    {
        this.HomeAddress = address;
        this.Type = type;
        this.Description = description;
    }

    public void EditAddress(Address address)
    {
        this.HomeAddress = address.HomeAddress;
        this.Type = address.Type;
        this.Description = address.Description;
    }

}