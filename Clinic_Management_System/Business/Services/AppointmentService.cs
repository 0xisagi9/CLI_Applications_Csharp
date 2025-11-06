using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Business.Services
{
    internal class AppointmentService(IRepository<Appointment> appointmentRepo)
    {
        private readonly IRepository<Appointment> _appointmentRepo = appointmentRepo;

        public IEnumerable<Appointment> GetAllAppointments() => _appointmentRepo.GetAll();

        public void AddNewAppointment(Appointment appointment)
        {
            try
            {
                _appointmentRepo.Add(appointment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Add New Appointment, {ex.Message}");
            }
        }
    }
}
