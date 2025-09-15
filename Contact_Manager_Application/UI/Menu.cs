using Contact_Manager_Application.Models;
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

    public static void ShowUpdateMenu(User user)
    {
        Console.Clear();
        Console.WriteLine("===================================================");
        Console.WriteLine("              Update User Information              ");
        Console.WriteLine("===================================================");

        Console.WriteLine($"  [1]  Update First Name ({user.Firstname})");
        Console.WriteLine($"  [2]  Update  Last Name ({user.Lastname})");
        Console.WriteLine($"  [3]  Update Gender ({user.Gender})");
        Console.WriteLine($"  [4]  Update City ({user.City})");
        Console.WriteLine($"  [5]  Add Email");
        Console.WriteLine($"  [6]  Add Phone");
        Console.WriteLine($"  [7]  Add Address");
        Console.WriteLine($"  [8]  Exit");
        Console.WriteLine("===================================================");
    }
}
