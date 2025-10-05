using Employee_Management_Application.DataAccess;
using Employee_Management_Application.Models;
using Employee_Management_Application.UI;
using System.Data;

namespace Employee_Management_Application;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Menu.MainMenu();

        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
        }

    }

}
