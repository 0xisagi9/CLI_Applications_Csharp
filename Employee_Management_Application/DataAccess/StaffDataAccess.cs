using Employee_Management_Application.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime;

namespace Employee_Management_Application.DataAccess;

internal class StaffDataAccess
{
    private readonly string _connectionString;

    public StaffDataAccess()
    {
        IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

        this._connectionString = config.GetConnectionString("DefaultConnection")!;
    }


    public DataTable GetAllStaff()
    {
        DataTable dataTable = new();
        using SqlConnection connection = new(this._connectionString);
        string selectQuery = "SELECT * FROM StaffMembers";
        SqlDataAdapter adapter = new(selectQuery, connection);
        adapter.Fill(dataTable);
        return dataTable;
    }


    public void InsertStaffMember(StaffMembers member)
    {
        using SqlConnection connection = new(this._connectionString);
        using SqlCommand command = new(member.ProcedureName, connection);
        command.CommandType = CommandType.StoredProcedure;

        member.AddParameters(command);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error while adding {member.Type} Employee: With Name {member.Name}");
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdateStaffMember(int id, StaffMembers member)
    {
        using SqlConnection connection = new(this._connectionString);
        using SqlCommand command = new("UpdateStaffMember", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@StaffId", id);
        command.Parameters.AddWithValue("@Name", member.Name);
        command.Parameters.AddWithValue("@Phone", member.Phone);
        command.Parameters.AddWithValue("Email", member.Email);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }


    }

    public void DeleteStaffMember(int id)
    {
        using SqlConnection connection = new(this._connectionString);
        using SqlCommand command = new("DeleteStaffMember", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Id", id);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    
}
