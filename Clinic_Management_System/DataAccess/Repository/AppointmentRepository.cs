using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Core.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.DataAccess.Repository;

internal class AppointmentRepository(IDbConnection connection) : Repository<Appointment>(connection, "Appointment")
{
    public void BookAppointment(Appointment appointment)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@SlotId", appointment.SlotId);
        parameters.Add("@PatientId", appointment.PatientID);


        _connection.Execute("AddAppointment", parameters, commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Appointment> ViewAppointmentById(int patientId)
    {
        var sql = "SELECT * FROM Appointment WHERE PatientId = @PatientId";
        return _connection.Query<Appointment>(sql, new { PatientId = patientId });
    }
}
