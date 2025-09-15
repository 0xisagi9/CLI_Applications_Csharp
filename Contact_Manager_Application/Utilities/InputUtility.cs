using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Utilities;

internal class InputUtility
{
    public static string ReadInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine()!;
    }
}
