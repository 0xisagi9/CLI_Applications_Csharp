using Clinic_Management_System.Business.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.DataAccess.Repository;

internal class PatientRepository(IDbConnection connection) : Repository<Patient>(connection, "Patient")
{
    public override IEnumerable<Patient> GetAll()
    {
        return _connection.Query<Patient>($"SELECT * FROM [User] U INNER JOIN Patient P on P.PatientId = u.UserId AND u.IsActive = 1");
    }
    public override Patient GetById(int id)
    {
        var sql = $"SELECT * FROM [User] WHERE UserId = {id}";
        return _connection.Query<Patient>(sql).Single();
    }
    public override void Add(Patient entity)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Name", entity.Name);
        parameters.Add("@Role", entity.Role);
        parameters.Add("@Email", entity.Email);
        parameters.Add("@Password", entity.Password);
        parameters.Add("@MedicalNotes", entity.MedicalNotes);
        _connection.Execute("AddPatient", parameters, commandType: CommandType.StoredProcedure);
    }
    public override void Update(Patient entity)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@DoctorId", entity.UserId);
        parameters.Add("@Name", entity.Name);
        parameters.Add("@Email", entity.Email);
        parameters.Add("@Password", entity.Password);
        parameters.Add("@Role", entity.Role);
        parameters.Add("@MedicalNotes", entity.MedicalNotes);
        _connection.Execute("UpdatePatient", parameters, commandType: CommandType.StoredProcedure);
    }
    public override void Delete(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@PatientId", id);
        _connection.Execute("DeactivatePatient", parameters, commandType: CommandType.StoredProcedure);
    }

    public bool Exist(int id)
    {
        string sql = "SELECT COUNT(1) FROM Patient WHERE PatientId = @PatientId";
        return _connection.ExecuteScalar<int>(sql, new { PatientId = id }) > 0;
    }

}
