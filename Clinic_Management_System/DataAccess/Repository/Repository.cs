using Clinic_Management_System.Core.Interfaces;
using Dapper;
using System.Data;

namespace Clinic_Management_System.DataAccess.Repository;

internal class Repository<T>(IDbConnection connection, string tableName) : IRepository<T>
{
    protected readonly IDbConnection _connection = connection;
    protected readonly string _tableName = tableName;

    public virtual IEnumerable<T> GetAll()
    {
        return _connection.Query<T>($"SELECT * FROM {_tableName}");
    }

    public virtual T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public virtual void Add(T entity)
    {
        throw new NotImplementedException();
    }
    public virtual void Update(T entity)
    {
        throw new NotImplementedException();
    }
    public virtual void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
