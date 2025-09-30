namespace Employee_Management_Application.Models;

internal class Departement
{
    private int _id;
    private string _name = string.Empty;
    private readonly List<StaffMembers> _members = [];

    public int Id
    {
        get => this._id;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, nameof(value));
            this._id = value;
        }
    }
    public string Name
    {
        get => this._name;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            this._name = value;
        }
    }
    public IReadOnlyList<StaffMembers> Members => _members.AsReadOnly();
    public void AddMember(StaffMembers member) => this._members.Add(member);

    public Departement(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

}
