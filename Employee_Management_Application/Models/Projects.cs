namespace Employee_Management_Application.Models;

internal class Projects
{
    private int _id;
    private string _location = string.Empty;
    private decimal _currentCost;
    private int _managerId;
    private readonly List<Budgets> _budgets = [];

    public int Id
    {
        get => this._id; set => this._id = value;
    }
    public string Location
    {
        get => this._location;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            this._location = value;
        }
    }
    public decimal CurrentCost
    {
        get => this._currentCost;
        set => this._currentCost = value;
    }

    public int ManagerId
    {
        get => this._managerId;
        set
        {
            this._managerId = value;
        }
    }

    public IReadOnlyList<Budgets> Budgets => this._budgets.AsReadOnly();

    public Projects(int id, string location, decimal currentCost, int managerId)
    {
        this.Id = id;
        this.Location = location;
        this.CurrentCost = currentCost;
        this.ManagerId = managerId;
    }

    public Projects(string location, decimal currentCost, int managerId)
    {
        this.Location = location;
        this.CurrentCost = currentCost;
        this.ManagerId = managerId;
    }

    public Projects() { }
    public void AddBudget(Budgets budget) => this._budgets.Add(budget);
}
