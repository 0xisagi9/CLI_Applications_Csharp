using Clinic_Management_System.Business.Models;
using Clinic_Management_System.DataAccess.DTO;
using Dapper;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.DataAccess.Repository;

internal class AppointmentSlotRepository(IDbConnection connection) : Repository<AppointmentSlot>(connection, "AppointmentSlot")
{
    public IEnumerable<AppointmentSlot> GetSlotsByDoctorId(int doctorId, bool? isActive = null, bool? isBooked = null)
    {
        var query = new StringBuilder("SELECT * FROM AppointmentSlot WHERE DoctorId = @DoctorId");
        var parameters = new DynamicParameters();
        parameters.Add("@DoctorId", doctorId);

        if (isActive.HasValue)
        {
            query.Append(" AND IsActive = @IsActive");
            parameters.Add("@IsActive", isActive);
        }

        if (isBooked.HasValue)
        {
            query.Append(" AND IsBooked = @IsBooked");
            parameters.Add("@IsBooked", isBooked);
        }


        return _connection.Query<AppointmentSlot>(query.ToString(), parameters);
    }

    public IEnumerable<AvailableSlotsDTO> GetAllAvailableSlot()
    {
        var sql = @"
       SELECT U.UserId, U.Name, D.Specification, SL.SlotId, SL.StartTime, SL.EndTime 
        FROM AppointmentSlot SL INNER JOIN Doctor D ON D.DoctorId = SL.DoctorId AND SL.IsActive = 1 AND SL.IsBooked = 0
        INNER JOIN [User] U ON U.UserId = D.DoctorId";
        return _connection.Query<AvailableSlotsDTO>(sql);
    }


    public override IEnumerable<AppointmentSlot> GetAll()
    {
        var sql = "SELECT * FROM [AppointmentSlot] WHERE IsActive = 1";
        return _connection.Query<AppointmentSlot>(sql);
    }

    public override AppointmentSlot GetById(int id)
    {
        var sql = $"SELECT * FROM [AppointmentSlot] WHERE SlotId = {id}";
        return _connection.Query<AppointmentSlot>(sql).Single();
    }

    public override void Add(AppointmentSlot entity)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@DoctorId", entity.DoctorId);
        parameters.Add("@StartTime", entity.StartTime);
        parameters.Add("@EndTime", entity.EndTime);
        _connection.Execute("AddAppointmentSlot", parameters, commandType: CommandType.StoredProcedure);
    }

    public override void Delete(int id)
    {
        _connection.Execute("DeactivateSlot", new { SlotId = id }, commandType: CommandType.StoredProcedure);
    }

    public override void Update(AppointmentSlot entity)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@SlotId", entity.SlotId);
        parameters.Add("@DoctorId", entity.DoctorId);
        parameters.Add("@StartTime", entity.StartTime);
        parameters.Add("@EndTime", entity.EndTime);
        parameters.Add("@IsBooked", entity.IsBooked);
        parameters.Add("@IsActive", entity.IsActive);

        _connection.Execute("UpdateAppointmentSlot", parameters, commandType: CommandType.StoredProcedure);
    }



}
