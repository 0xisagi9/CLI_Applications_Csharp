namespace Employee_Management_Application.Models;

internal class CommissionEmployees : Employees
{
    private decimal _target;
    public decimal Target
    {
        get => this._target;
        set => this._target = value;
    }

    public CommissionEmployees(int id, string name, string phone, string email, string type, Departement departement, string ssn, decimal target)
        : base(id, name, phone, email, type, departement, ssn)
    {
        this.Target = target;
    }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
