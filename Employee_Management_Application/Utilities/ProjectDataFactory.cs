using System.Data;

namespace Employee_Management_Application.Utilities;

internal class ProjectDataFactory
{
    public static void ListProjects(DataTable projectTable)
    {
        Console.Clear();
        Console.WriteLine("===============================================================================================");
        Console.WriteLine(" Projects with Managers ");
        Console.WriteLine("===============================================================================================");
        Console.WriteLine("{0,-8} {1,-15} {2,-12} {3,-12} {4,-20} {5,-10} {6,-10}",
            "ProjID", "Location", "Cost", "ManagerId", "ManagerName", "DeptId", "Type");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");

        foreach (DataRow row in projectTable.Rows)
        {
            Console.WriteLine("{0,-8} {1,-15} {2,-12:C} {3,-12} {4,-20} {5,-10} {6,-10}",
                row["ProjectId"],
                row["Location"],
                row["CurrentCost"],
                row["ManagerStaffId"],
                row["Name"],
                row["DepartmentId"],
                row["Type"]);
        }

        Console.WriteLine("----------------------------------------------------------------------------------------------");
        Console.WriteLine($"Total Projects: {projectTable.Rows.Count}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
