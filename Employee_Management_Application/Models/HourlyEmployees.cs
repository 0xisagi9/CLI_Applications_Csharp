using Microsoft.Data.SqlClient;

namespace Employee_Management_Application.Models;

internal class HourlyEmployees : Employees
{
    private decimal _rate;
    private int _hours;

    public decimal Rate
    {
        get => this._rate;
        set => this._rate = value;
    }
    public int Hours
    {
        get => this._hours;
        set => this._hours = value;
    }

    public HourlyEmployees(int id, string name, string phone, string email, string type, int departementId, string ssn, decimal rate, int hours)
        : base(id, name, phone, email, type, departementId, ssn)
    {
        this.Hours = hours;
        this.Rate = rate;
    }
    public HourlyEmployees(string name, string phone, string email, string type, int departementId, string ssn, decimal rate, int hours)
        : base(name, phone, email, type, departementId, ssn)
    {
        this.Hours = hours;
        this.Rate = rate;
    }

    public HourlyEmployees() { }



    public override string ProcedureName => "AddHourlyEmployee";

    public override void AddParameters(SqlCommand command)
    {
        base.AddParameters(command);
        command.Parameters.AddWithValue("@Rate", this.Rate);
        command.Parameters.AddWithValue("@Hours", this.Hours);
    }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
