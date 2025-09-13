using Student_Record_Manager.Models;
using Student_Record_Manager.Services;

namespace Student_Record_Manager
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                bool running = true;
                StudentManager Database = new();

                while (running)
                {
                    Console.Clear();
                    ShowMenu();
                    Console.Write("Enter your choice: ");
                    string? choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Id: ");
                            int addId = int.Parse(Console.ReadLine()!);
                            Console.Write("Enter Name: ");
                            string? addName = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            int addAge = int.Parse(Console.ReadLine()!);
                            Console.Write("Enter Grade: ");
                            decimal addGrade = decimal.Parse(Console.ReadLine()!);
                            Database.AddStudent(new Student(addId, addName, addAge, addGrade));
                            Console.WriteLine("\n Student added successfully!");
                            break;
                        case "2":
                            Console.Write("Enter Id to Update: ");
                            int updId = int.Parse(Console.ReadLine()!);
                            Console.Write("Enter New Name: ");
                            string? updName = Console.ReadLine();
                            Console.Write("Enter New Age: ");
                            int updAge = int.Parse(Console.ReadLine()!);
                            Console.Write("Enter New Grade: ");
                            decimal updGrade = decimal.Parse(Console.ReadLine()!);
                            Database.UpdateStudent(updId, updName, updAge, updGrade);
                            Console.WriteLine("\n Student updated successfully!");
                            break;
                        case "3":
                            Console.Write("Enter Id to Delete: ");
                            int delId = int.Parse(Console.ReadLine()!);
                            Database.DeleteStudent(delId);
                            Console.WriteLine("\n Student deleted successfully!");
                            break;
                        case "4":
                            Console.Write("Enter Id to Display: ");
                            int dispId = int.Parse(Console.ReadLine()!);
                            Database.DisplayStudent(dispId);
                            break;
                        case "5":
                            Database.PrintStudents();

                            break;
                        case "6":
                            running = false;
                            Console.WriteLine("\n Exiting... Goodbye!");
                            break;
                        default:
                            Console.WriteLine("\n Invalid choice, please try again.");
                            break;
                    }

                    if (running)
                    {
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        static void ShowMenu()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("              Welcome to Our School              ");
            Console.WriteLine("===================================================");
            Console.WriteLine("  [1]  Add User");
            Console.WriteLine("  [2]  Update User");
            Console.WriteLine("  [3]  Delete User");
            Console.WriteLine("  [4]  Display User");
            Console.WriteLine("  [5]  Display All Users");
            Console.WriteLine("  [6]  Exit");
            Console.WriteLine("===================================================");
        }
    }
}

