
using System.Runtime;

namespace Clinic_Management_System.Business.Models;

internal class Patient : User
{
    public string? MedicalNotes { get; set; }


    public Patient() : base() { }

    public Patient(int id, string name, string email, string password, string role, string medicalNotes) : base(id, name, email, password, role)
    {
        MedicalNotes = medicalNotes;
    }

    public Patient(string name, string email, string password, string role, string medicalNotes) : base(name, email, password, role)
    {
        MedicalNotes = medicalNotes;
    }

    public override string ToString() => base.ToString() + $"Medical Notes: {MedicalNotes}";
}
