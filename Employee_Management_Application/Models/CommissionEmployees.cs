using Microsoft.Data.SqlClient;

namespace Employee_Management_Application.Models;

internal class CommissionEmployees : Employees
{
    private decimal _target;
    public decimal Target
    {
        get => this._target;
        set => this._target = value;
    }

    public CommissionEmployees(int id, string name, string phone, string email, string type, int departementId, string ssn, decimal target)
        : base(id, name, phone, email, type, departementId, ssn)
    {
        this.Target = target;
    }
    public CommissionEmployees(string name, string phone, string email, string type, int departementId, string ssn, decimal target)
        : base(name, phone, email, type, departementId, ssn)
    {
        this.Target = target;
    }

    public CommissionEmployees() { }

    public override string ProcedureName => "AddCommissionEmployee";

    public override void AddParameters(SqlCommand command)
    {
        base.AddParameters(command);
        command.Parameters.AddWithValue("@Target", this.Target);
    }
    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
