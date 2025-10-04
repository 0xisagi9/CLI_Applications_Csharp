using Microsoft.Data.SqlClient;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public Employees(int id, string name, string phone, string email, string type, int departementId, string ssn)
       : base(id, name, phone, email, type, departementId)
    {
        this.SSN = ssn;
    }
    public Employees(string name, string phone, string email, string type, int departementId, string ssn)
       : base(name, phone, email, type, departementId)
    {
        this.SSN = ssn;
    }

    public Employees() { }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Prodecure Name for StoredProcedures in SQL Database
    /// </summary>

    public override string ProcedureName => "AddEmployee";
    /// <summary>
    /// Add Custom Parameters Specific For the Type of Employee
    /// </summary>
    /// <param name="command"></param>
    public override void AddParameters(SqlCommand command)
    {
        command.Parameters.AddWithValue("@Name", this.Name);
        command.Parameters.AddWithValue("@Phone", this.Phone);
        command.Parameters.AddWithValue("@Email", this.Email);
        command.Parameters.AddWithValue("@DepartmentId", this.DepartementId);
        command.Parameters.AddWithValue("@SSN", this.SSN);
    }

}
