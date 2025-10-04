namespace Employee_Management_Application.Utilities;

internal class InputUtility
{
    public static string ReadInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine()!;
    }
}
