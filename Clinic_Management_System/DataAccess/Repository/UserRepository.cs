using Clinic_Management_System.Business.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.DataAccess.Repository;

internal class UserRepository(IDbConnection connection) : Repository<User>(connection, "[User]")
{
    public User? GetByEmail(string email)
    {
        return _connection.QuerySingleOrDefault<User>("SELECT * FROM [User] WHERE Email = @Email",
            new { Email = email });
    }
    public override User GetById(int userId)
    {
        return _connection.Query<User>(
            "SELECT * FROM [User] WHERE UserId = @UserId", new { UserId = userId }).Single();
    }
    public override void Add(User entity)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Name", entity.Name);
        parameters.Add("@Email", entity.Email);
        parameters.Add("@Password", entity.Password);
        parameters.Add("@Role", entity.Role);
        _connection.Execute("AddUser", parameters, commandType: CommandType.StoredProcedure);
    }

    public bool ExistByEmail(string email)
    {
        var count = _connection.ExecuteScalar<int>("SELECT COUNT(1) FROM [User] WHERE Email = @Email",
            new { Email = email });
        return count > 0;
    }
    public override void Delete(int userId)
    {
        _connection.Execute(
            "UPDATE [User] SET IsActive = 0 WHERE UserId = @UserId", new { UserId = userId });
    }
    public override IEnumerable<User> GetAll()
    {
        return _connection.Query<User>("SELECT * FROM [User]");
    }



}
