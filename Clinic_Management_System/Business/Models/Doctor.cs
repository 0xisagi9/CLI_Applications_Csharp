namespace Clinic_Management_System.Business.Models;

internal class Doctor : User
{
    public string? Specification { get; set; }

    public Doctor() : base() { }
    public Doctor(int id, string name, string email, string password, string role, string specification) : base(id, name, email, password, role)
    {
        Specification = specification;
    }
    public Doctor(string name, string email, string password, string role, string specification) : base(name, email, password, role)
    {
        Specification = specification;
    }

    public override string ToString() => base.ToString() + $" Specification:{Specification}";

}
