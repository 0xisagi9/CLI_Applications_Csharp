namespace Employee_Management_Application.Models;

internal class ExecutiveEmployees : Employees
{
    private decimal _salary;
    private decimal _bonus;

    public decimal Salary
    {
        get => this._salary;
        set => this._salary = value;
    }
    public decimal Bonus
    {
        get => this._bonus;
        set => this._bonus = value;
    }


    public ExecutiveEmployees(int id, string name, string phone, string email, string type, Departement departement, string ssn, decimal salary, decimal bonus)
        : base(id, name, phone, email, type, departement, ssn)
    {
        this.Salary = salary;
        this.Bonus = bonus;
    }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
