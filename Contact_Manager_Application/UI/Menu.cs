using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.UI;

internal class Menu
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("===================================================");
        Console.WriteLine("              Welcome to Our Application           ");
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
