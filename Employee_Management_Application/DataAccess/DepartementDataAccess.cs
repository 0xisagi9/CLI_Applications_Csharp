using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Employee_Management_Application.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Tokens;
namespace Employee_Management_Application.DataAccess;
internal class DepartementDataAccess
{
    private readonly string _connectionString;
    public DepartementDataAccess()
    {
        IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        this._connectionString = config.GetConnectionString("DefaultConnection")!;
    }

    public DataTable GetAllDepartment()
    {
        DataTable dataTable = new();

        using SqlConnection connection = new(this._connectionString);
        string Query = "SELECT D.DepartmentId,D.DepartmentName,S.StaffId,S.Name,S.Type\r\nFROM Department D INNER JOIN StaffMembers S ON S.DepartmentId = D.DepartmentId ORDER BY D.DepartmentID";
        SqlDataAdapter adapter = new(Query, connection);
        adapter.Fill(dataTable);
        return dataTable;
    }

    public void InsertDepartment(string name)
    {
        //1. Fill Data With Rows From Database
        DataTable dataTable = new();
        using SqlConnection connection = new(this._connectionString);
        string selectQuery = "SELECT DepartmentId, DepartmentName FROM Department";
        SqlDataAdapter adapter = new(selectQuery, connection);
        adapter.Fill(dataTable);

        //2. Insert Command
        string insertQuery = "INSERT INTO [dbo].[Department]([DepartmentName]) VALUES(@name)";
        SqlCommand command = new(insertQuery, connection);
        adapter.InsertCommand = command;
        adapter.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "DepartmentName");

        //3. Insert Row
        DataRow newRow = dataTable.NewRow();
        newRow["DepartmentName"] = name;
        dataTable.Rows.Add(newRow);

        int rowsAffected = adapter.Update(dataTable);
        WriteLine(rowsAffected > 0
           ? $"Department '{name}' inserted successfully."
           : "Insert failed.");

    }

    public void UpdateDepartment(int id, string name)
    {

        //1. Fill Data With Rows From Database
        DataTable dataTable = new();
        using SqlConnection connection = new(this._connectionString);
        string selectQuery = "SELECT DepartmentId, DepartmentName FROM Department";
        SqlDataAdapter adapter = new(selectQuery, connection);
        adapter.Fill(dataTable);

        //2. Update Command
        string updateQuery = "UPDATE Department SET DepartmentName = @name WHERE DepartmentId = @id";
        SqlCommand command = new(updateQuery, connection);
        adapter.UpdateCommand = command;
        adapter.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "DepartmentName");
        adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "DepartmentId");

        //3. Find the Row to Update
        DataRow[] rows = dataTable.Select($"DepartmentId = {id}");
        if (rows.Length > 0)
        {
            rows[0]["DepartmentName"] = name;
            int rowsAffected = adapter.Update(dataTable);
            WriteLine(rowsAffected > 0 ? $"Department #{id} updated to '{name}'." : "Update failed.");
        }
        else
        {
            WriteLine($"Department with ID {id} not found.");
        }

    }

    public void DeleteDepartment(int id)
    {
        //1. Fill Data Table with Rows From Database
        DataTable dataTable = new();
        using SqlConnection connection = new(this._connectionString);
        string selectQuery = "SELECT DepartmentId, DepartmentName FROM Department";
        SqlDataAdapter adapter = new(selectQuery, connection);
        adapter.Fill(dataTable);
        //2. Delete Command
        string deleteQuery = "DELETE FROM Department WHERE DepartmentId= @id";
        SqlCommand command = new(deleteQuery, connection);
        adapter.DeleteCommand = command;
        adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 0, "DepartmentId");

        //3. Find the Row To Delete
        DataRow[] rows = dataTable.Select($"DepartmentId = {id}");
        if (rows.Length > 0)
        {
            rows[0].Delete();
            int rowsAffected = adapter.Update(dataTable);
            WriteLine(rowsAffected > 0 ? $"Department #{id} deleted successfully." : "Delete failed.");
        }
        else
        {
            WriteLine($"Department with ID {id} not found.");
        }
    }
}
