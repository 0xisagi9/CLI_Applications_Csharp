namespace Employee_Management_Application.Models;

internal class Employees : StaffMembers
{
    private string _ssn = string.Empty;
    public string SSN
    {
        get => this._ssn;
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            this._ssn = value;
        }
    }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }

    public Employees(int id, string name, string phone, string email, string type, Departement departement, string ssn)
        : base(id, name, phone, email, type, departement)
    {
        this.SSN = ssn;
    }

}
