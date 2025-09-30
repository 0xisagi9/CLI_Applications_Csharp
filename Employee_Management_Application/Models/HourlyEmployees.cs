namespace Employee_Management_Application.Models;

internal class HourlyEmployees : Employees
{
    private decimal _rate;
    private int _hours;

    public decimal Rate
    {
        get => this._rate;
        set => this._rate = value;
    }
    public int Hours
    {
        get => this._hours;
        set => this._hours = value;
    }

    public HourlyEmployees(int id, string name, string phone, string email, string type, Departement departement, string ssn, decimal rate, int hours)
        : base(id, name, phone, email, type, departement, ssn)
    {
        this.Hours = hours;
        this.Rate = rate;
    }

    public override decimal Pay()
    {
        throw new NotImplementedException();
    }
}
