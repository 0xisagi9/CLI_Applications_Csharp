namespace Employee_Management_Application.Models;

internal class Volunteers : StaffMembers
{
    private decimal _value;
    public decimal Value
    {
        get => this._value;
        set => this._value = value;
    }

    public Volunteers(int id, string name, string phone, string email, string type, Departement departement, decimal value)
        : base(id, name, phone, email, type, departement)
    {
        this.Value = value;
    }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
