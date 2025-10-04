using Microsoft.Data.SqlClient;

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

    public ExecutiveEmployees(int id, string name, string phone, string email, string type, int departementId, string ssn, decimal salary, decimal bonus)
        : base(id, name, phone, email, type, departementId, ssn)
    {
        this.Salary = salary;
        this.Bonus = bonus;
    }

    public ExecutiveEmployees(string name, string phone, string email, string type, int departementId, string ssn, decimal salary, decimal bonus)
        : base(name, phone, email, type, departementId, ssn)
    {
        this.Salary = salary;
        this.Bonus = bonus;
    }

    public ExecutiveEmployees() { }
    public override string ProcedureName => "AddExecutiveEmployee";

    public override void AddParameters(SqlCommand command)
    {
        base.AddParameters(command);
        command.Parameters.AddWithValue("@Salary", this.Salary);
        command.Parameters.AddWithValue("@Bonus", this.Bonus);
    }
    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
