using Microsoft.Data.SqlClient;

namespace Employee_Management_Application.Models;

internal class SalariedEmployees : Employees
{
    private decimal _salary;
    public decimal Salary
    {
        get => this._salary;
        set => this._salary = value;
    }

    public SalariedEmployees(int id, string name, string phone, string email, string type, int departementId, string ssn, decimal slary)
        : base(id, name, phone, email, type, departementId, ssn)
    {
        this.Salary = slary;
    }

    public SalariedEmployees(string name, string phone, string email, string type, int departementId, string ssn, decimal salary)
        : base(name, phone, email, type, departementId, ssn)
    {
        this.Salary = salary;
    }

    public SalariedEmployees() { }

    public override string ProcedureName => "AddSalariedEmployee";
    public override void AddParameters(SqlCommand command)
    {
        base.AddParameters(command);
        command.Parameters.AddWithValue("@Salary", this.Salary);
    }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
