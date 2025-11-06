namespace Clinic_Management_System.Core.Utilites;

internal class InputUtility
{
    public static string ReadInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()!;
    }
}
