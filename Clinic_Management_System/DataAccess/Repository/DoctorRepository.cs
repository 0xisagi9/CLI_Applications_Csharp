using Clinic_Management_System.Business.Models;
using Dapper;
using System.Data;
using System.Runtime;

namespace Clinic_Management_System.DataAccess.Repository;

internal class DoctorRepository(IDbConnection connection) : Repository<Doctor>(connection, "Doctor")
{

    public override IEnumerable<Doctor> GetAll()
    {
        return _connection.Query<Doctor>($"SELECT * FROM [User] U INNER JOIN Doctor D on d.DoctorId = u.UserId AND u.IsActive = 1");
    }

    public override Doctor GetById(int id)
    {
        var sql = $"SELECT * FROM [User] WHERE UserId = {id}";
        return _connection.Query<Doctor>(sql).Single();
    }
    public override void Add(Doctor entity)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Name", entity.Name);
        parameters.Add("@Role", entity.Role);
        parameters.Add("@Email", entity.Email);
        parameters.Add("@Password", entity.Password);
        parameters.Add("@Specification", entity.Specification);
        _connection.Execute("AddDoctor", parameters, commandType: CommandType.StoredProcedure);
    }

    public override void Delete(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@DoctorId", id);
        _connection.Execute("DeactivateDoctor", parameters, commandType: CommandType.StoredProcedure);
    }
    public override void Update(Doctor entity)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@DoctorId", entity.UserId);
        parameters.Add("@Name", entity.Name);
        parameters.Add("@Email", entity.Email);
        parameters.Add("@Password", entity.Password);
        parameters.Add("@Role", entity.Role);
        parameters.Add("@Specification", entity.Specification);
        _connection.Execute("UpdateDoctor", parameters, commandType: CommandType.StoredProcedure);
    }

    public bool Exist(int id)
    {
        string sql = "SELECT COUNT(1) FROM Doctor WHERE DoctorId = @DoctorId";
        return _connection.ExecuteScalar<int>(sql, new { DoctorId = id }) > 0;
    }

}
