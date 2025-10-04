using Employee_Management_Application.DataAccess;
using Employee_Management_Application.Models;
using System.Data;
using System.Xml.Schema;
using static Employee_Management_Application.Utilities.InputUtility;
namespace Employee_Management_Application.Utilities;

internal class StaffMemberDataFactory
{
    public static StaffMembers AddStaffMember()
    {
        string name = ReadInput("Enter Name: ")!;
        string phone = ReadInput("Enter Phone: ")!;
        string email = ReadInput("Enter Email: ")!;
        int departementId = int.Parse(ReadInput("Enter Departement Id: "));
        string ssn = ReadInput("Enter SSN: ")!;
        string type = ReadInput("Enter Employee Type: ")!;

        switch (type)
        {
            case "Hourly":
                int hour = int.Parse(ReadInput("Enter Hours: "));
                decimal rate = decimal.Parse(ReadInput("Enter Rate: "));
                return new HourlyEmployees(name, phone, email, type, departementId, ssn, rate, hour);
            case "Commission":
                decimal target = decimal.Parse(ReadInput("Enter Target Value: "));
                return new CommissionEmployees(name, phone, email, type, departementId, ssn, target);
            case "Salary":
                decimal ssalary = decimal.Parse(ReadInput("Enter Salary: "));
                return new SalariedEmployees(name, phone, email, type, departementId, ssn, ssalary);
            case "Executive":
                decimal esalary = decimal.Parse(ReadInput("Enter Salary: "));
                decimal bonus = decimal.Parse(ReadInput("Enter Bonus: "));
                return new ExecutiveEmployees(name, phone, email, type, departementId, ssn, esalary, bonus);
            case "Volunteer":
                decimal value = decimal.Parse(ReadInput("Enter Value: "));
                return new Volunteers(name, phone, email, type, departementId, value);
            default:
                return new Employees(name, phone, email, type, departementId, ssn);
        }
    }

    public static StaffMembers UpdateStaffMember()
    {
        int id = int.Parse(ReadInput("Enter Id: "));
        string name = ReadInput("Enter Name: ")!;
        string phone = ReadInput("Enter Phone: ")!;
        string email = ReadInput("Enter Email: ")!;
        int departementId = int.Parse(ReadInput("Enter Departement Id: "));
        string ssn = ReadInput("Enter SSN: ")!;
        string type = ReadInput("Enter Employee Type: ")!;

        switch (type)
        {
            case "Hourly":
                int hour = int.Parse(ReadInput("Enter Hours: "));
                decimal rate = decimal.Parse(ReadInput("Enter Rate: "));
                return new HourlyEmployees(id, name, phone, email, type, departementId, ssn, rate, hour);
            case "Commission":
                decimal target = decimal.Parse(ReadInput("Enter Target Value: "));
                return new CommissionEmployees(id, name, phone, email, type, departementId, ssn, target);
            case "Salary":
                decimal ssalary = decimal.Parse(ReadInput("Enter Salary: "));
                return new SalariedEmployees(id, name, phone, email, type, departementId, ssn, ssalary);
            case "Executive":
                decimal esalary = decimal.Parse(ReadInput("Enter Salary: "));
                decimal bonus = decimal.Parse(ReadInput("Enter Bonus: "));
                return new ExecutiveEmployees(id, name, phone, email, type, departementId, ssn, esalary, bonus);
            case "Volunteer":
                decimal value = decimal.Parse(ReadInput("Enter Value: "));
                return new Volunteers(id, name, phone, email, type, departementId, value);
            default:
                return new Employees(id, name, phone, email, type, departementId, ssn);
        }
    }
    public static void ListStaffMember(DataTable staffTable)
    {
        Console.Clear();
        Console.WriteLine("===============================================");
        Console.WriteLine(" Staff Members ");
        Console.WriteLine("===============================================");
        Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-35} {4,-10} {5,-15}",
             "ID", "Name", "Phone", "Email", "DeptId", "Type");
        Console.WriteLine("--------------------------------------------------------------------------------");

        foreach (DataRow row in staffTable.Rows)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-35} {4,-10} {5,-15}",
                row["StaffId"],
                row["Name"],
                row["Phone"],
                row["Email"],
                row["DepartmentId"],
                row["Type"]);
        }

        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine($"Total Staff: {staffTable.Rows.Count}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
