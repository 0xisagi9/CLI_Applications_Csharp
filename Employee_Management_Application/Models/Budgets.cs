namespace Employee_Management_Application.Models;

internal class Budgets
{
    private int _id;
    private decimal _value;

    public int Id
    {
        get => this._id;
        set => this._id = value;
    }

    public decimal Value
    {
        get => this._value;
        set => this._value = value;
    }

    public Budgets(int id, decimal value)
    {
        this.Id = id;
        this.Value = value;
    }
}
