using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Models;

internal class EmailAddress
{
    private string _email = string.Empty;
    private string _type = string.Empty;
    private string _description = string.Empty;
    public string Email
    {
        get => this._email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(value);
            this._email = value;
        }
    }

    public string Type
    {
        get => this._type;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(value);
            this._type = value;
        }
    }

    public string Description
    {
        get => this._description;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(value);
            this._description = value;
        }
    }

    public EmailAddress(string email, string type, string description)
    {
        this.Email = email;
        this.Type = type;
        this.Description = description;
    }

    public void EditEmail(EmailAddress email)
    {
        this.Email = email.Email;
        this.Type = email.Type;
        this.Description = email.Description;
    }
}
