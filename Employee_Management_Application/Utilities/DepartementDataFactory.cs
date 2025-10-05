using System.Data;

namespace Employee_Management_Application.Utilities;

internal class DepartementDataFactory
{
    public static void ListDepartement(DataTable departementTable)
    {
        Console.Clear();
        Console.WriteLine("============================================================");
        Console.WriteLine(" Departments with Staff Members ");
        Console.WriteLine("============================================================");
        Console.WriteLine("{0,-5} {1,-20} {2,-8} {3,-20} {4,-15}",
            "DeptId", "Department", "StaffId", "StaffName", "Type");
        Console.WriteLine("----------------------------------------------------------------------------");

        foreach (DataRow row in departementTable.Rows)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-8} {3,-20} {4,-15}",
                row["DepartmentId"],
                row["DepartmentName"],
                row["StaffId"],
                row["Name"],
                row["Type"]);
        }

        Console.WriteLine("----------------------------------------------------------------------------");
        Console.WriteLine($"Total Records: {departementTable.Rows.Count}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
