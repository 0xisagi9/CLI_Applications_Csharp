using Clinic_Management_System.Business;
using Clinic_Management_System.Configuration;
using Clinic_Management_System.DataAccess;
using Clinic_Management_System.Core;
using Clinic_Management_System.DataAccess.DatabaseConnect;
using Clinic_Management_System.DataAccess.Repository;
using System.Data;
using Clinic_Management_System.Business.Services;
using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Presentation.Menu;
namespace Clinic_Management_System;

internal class Program
{
    static void Main(string[] args)
    {
        var appConfig = new AppConfiguration();
        var conectionString = appConfig.GetConncetionString();
        var factory = new SqlConnectionFactory(conectionString);
        var connection = factory.CreateConnection();

        var userRepo = new UserRepository(connection);
        var doctorRepo = new DoctorRepository(connection);
        var patientRepo = new PatientRepository(connection);
        var appointmentRepo = new AppointmentRepository(connection);
        var appointmentSlotRepo = new AppointmentSlotRepository(connection);

        var authService = new AuthService(userRepo);
        var doctorService = new DoctorService(appointmentSlotRepo, doctorRepo);
        var patientService = new PatientService(appointmentSlotRepo, appointmentRepo, patientRepo);
        var appointmentSlotService = new AppointmentSlotService(appointmentSlotRepo);
        var appointmentService = new AppointmentService(appointmentRepo);
        WelcomMenu.WelcomeToApplication(authService, doctorService, patientService, appointmentService, appointmentSlotService);
    }


}
