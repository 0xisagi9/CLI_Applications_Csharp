using Employee_Management_Application.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Employee_Management_Application.DataAccess;

internal class ProjectsDataAccess
{
    private readonly string _connectionString;
    public ProjectsDataAccess()
    {
        IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

        this._connectionString = config.GetConnectionString("DefaultConnection")!;
    }

    public DataTable GetAllProjects()
    {
        DataTable dataTable = new();

        using SqlConnection connection = new(this._connectionString);
        string Query = "SELECT P.ProjectId, P.Location,P.CurrentCost, P.ManagerStaffId, S.Name, S.DepartmentId, S.Type FROM Projects P INNER JOIN StaffMembers s ON S.StaffId = P.ManagerStaffId";
        SqlDataAdapter adapter = new(Query, connection);
        adapter.Fill(dataTable);
        return dataTable;
    }

    public void InsertProject(Projects project)
    {
        // Open Connection - Command - Command Type is StoredProcedure
    }
}
