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
        string Query = "SELECT DepartmentId, DepartmentName FROM Department";
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

        adapter.Update(dataTable);

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
            rows[0]["DepartmentName"] = name;

        adapter.Update(dataTable);
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
        if (!rows.IsNullOrEmpty())
            rows[0].Delete();

        adapter.Update(dataTable);


    }
}
