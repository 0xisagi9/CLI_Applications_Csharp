namespace Employee_Management_Application.Models;

internal class SalariedEmployees : Employees
{
    private decimal _salary;
    public decimal Salary
    {
        get => this._salary;
        set => this._salary = value;
    }

    public SalariedEmployees(int id, string name, string phone, string email, string type, Departement departement, string ssn, decimal slary)
        : base(id, name, phone, email, type, departement, ssn)
    {
        this.Salary = slary;
    }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
