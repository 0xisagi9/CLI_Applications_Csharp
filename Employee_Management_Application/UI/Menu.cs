using Employee_Management_Application.Models;
using Employee_Management_Application.DataAccess;
using Employee_Management_Application.Utilities;
using static Employee_Management_Application.Utilities.InputUtility;

namespace Employee_Management_Application.UI;

internal class Menu
{
    public static void MainMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Employee Management System ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Manage Staff Members");
            Console.WriteLine("2. Manage Departement");
            Console.WriteLine("3. Manage Projects");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=====================================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    StaffMemberMenu();
                    break;
                case "2":
                    DepartementMenu();
                    break;
                case "3":
                    ProjectMenu();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public static void StaffMemberMenu()
    {
        bool back = false;
        var staffDAL = new StaffDataAccess();

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Staff Members Menu ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Add New Staff Member");
            Console.WriteLine("2. Update Staff Member");
            Console.WriteLine("3. Delete Staff Member");
            Console.WriteLine("4. View All Staff Members");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("=====================================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nAdding new staff member...\n");
                    var addMember = StaffMemberDataFactory.AddStaffMember();
                    staffDAL.InsertStaffMember(addMember);
                    WriteLine("Adding Member Successfully........");
                    ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Updating staff member...");
                    var updateMember = StaffMemberDataFactory.UpdateStaffMember();
                    staffDAL.UpdateStaffMember(updateMember.Id, updateMember);
                    WriteLine("Updating Member Successfully........");
                    ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Deleting staff member...");
                    int id = int.Parse(ReadInput("Enter Id to Delete: "));
                    staffDAL.DeleteStaffMember(id);
                    WriteLine("Deleting Member Successfully........");
                    ReadKey();
                    break;
                case "4":
                    Clear();
                    StaffMemberDataFactory.ListStaffMember(staffDAL.GetAllStaff());
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");

                    break;
            }
        }
    }

    public static void DepartementMenu()
    {
        bool back = false;
        var departDAL = new DepartementDataAccess();

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Department Menu ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Add New Department");
            Console.WriteLine("2. Update Department");
            Console.WriteLine("3. Delete Department");
            Console.WriteLine("4. View All Departments");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("=====================================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    WriteLine("Comming Soon");
                    ReadKey();
                    break;
                case "2":
                    WriteLine("Comming Soon");
                    ReadKey();
                    break;
                case "3":
                    WriteLine("Comming Soon");
                    ReadKey();
                    break;
                case "4":
                    DepartementDataFactory.ListDepartement(departDAL.GetAllDepartment());
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    public static void ProjectMenu()
    {
        bool back = false;
        var projDAL = new ProjectsDataAccess();

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Projects Menu ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Add New Project");
            Console.WriteLine("2. Update Project");
            Console.WriteLine("3. Delete Project");
            Console.WriteLine("4. View All Project");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("=====================================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    WriteLine("Comming Soon");
                    ReadKey();
                    break;
                case "2":
                    WriteLine("Comming Soon");
                    ReadKey();
                    break;
                case "3":
                    WriteLine("Comming Soon");
                    ReadKey();
                    break;
                case "4":
                    ProjectDataFactory.ListProjects(projDAL.GetAllProjects());
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

