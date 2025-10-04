using Microsoft.Data.SqlClient;

namespace Employee_Management_Application.Models;

internal abstract class StaffMembers
{
    private int _id;
    private string _name = string.Empty;
    private string _phone = string.Empty;
    private string _email = string.Empty;
    private string _type = string.Empty;
    private int _departementId;

    public int Id
    {
        get => this._id;
        set { this._id = value; }
    }
    public string Name
    {
        get => this._name;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            this._name = value;
        }
    }
    public string Phone
    {
        get => this._phone;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            this._phone = value;
        }
    }
    public string Email
    {
        get => this._email;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            this._email = value;
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
    public int DepartementId
    {
        get => this._departementId;
        set { this._departementId = value; }
    }

    public StaffMembers(int id, string name, string phone, string email, string type, int departementId)
    {
        this.Id = id;
        this.Name = name;
        this.Phone = phone;
        this.Email = email;
        this.Type = type;
        this.DepartementId = departementId;

    }
    public StaffMembers(string name, string phone, string email, string type, int departementId)
    {
        this.Name = name;
        this.Phone = phone;
        this.Email = email;
        this.Type = type;
        this.DepartementId = departementId;
    }

    public StaffMembers() { }

    public abstract string ProcedureName { get; }

    public abstract decimal Pay();

    public abstract void AddParameters(SqlCommand command);



}
