using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Core.Interfaces;
using Clinic_Management_System.DataAccess.DTO;
using Clinic_Management_System.DataAccess.Repository;
using System.Data.Common;

namespace Clinic_Management_System.Business.Services;

internal class PatientService
    (AppointmentSlotRepository appointmentSlotRepo,
    AppointmentRepository appointmentRepository,
    PatientRepository patientRepo)
{

    private readonly AppointmentSlotRepository _appointmentSlotRepo = appointmentSlotRepo;
    private readonly PatientRepository _patientRepo = patientRepo;
    private readonly AppointmentRepository _appointmentRepo = appointmentRepository;

    public IEnumerable<AvailableSlotsDTO> GetAllAvailabeSlots()
    {
        return _appointmentSlotRepo.GetAllAvailableSlot();
    }

    public void BookAppointment(Appointment appointment)
    {
        _appointmentRepo.BookAppointment(appointment);
    }

    public IEnumerable<Appointment> ViewPatientAppointment(int patientId)
    {
        return _appointmentRepo.ViewAppointmentById(patientId);
    }

    public void UpdatePatient(Patient patient)
    {
        _patientRepo.Update(patient);
    }

}
