using Microsoft.Data.SqlClient;

namespace Employee_Management_Application.Models;

internal class Volunteers : StaffMembers
{
    private decimal _value;
    public decimal Value
    {
        get => this._value;
        set => this._value = value;
    }

    public Volunteers(int id, string name, string phone, string email, string type, int departementId, decimal value)
        : base(id, name, phone, email, type, departementId)
    {
        this.Value = value;
    }
    public Volunteers(string name, string phone, string email, string type, int departementId, decimal value)
        : base(name, phone, email, type, departementId)
    {
        this.Value = value;
    }

    public Volunteers() { }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }

    public override string ProcedureName => "AddVolunteer";
    public override void AddParameters(SqlCommand command)
    {
        command.Parameters.AddWithValue("@Name", this.Name);
        command.Parameters.AddWithValue("@Phone", this.Phone);
        command.Parameters.AddWithValue("@Email", this.Email);
        command.Parameters.AddWithValue("@DepartmentId", this.DepartementId);
        command.Parameters.AddWithValue("@Value", this.Value);
    }
}
