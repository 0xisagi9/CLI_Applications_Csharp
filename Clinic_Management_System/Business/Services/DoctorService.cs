using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Core.Interfaces;
using Clinic_Management_System.DataAccess.Repository;
using Microsoft.Data.SqlClient;
using System.Runtime;

namespace Clinic_Management_System.Business.Services;

internal class DoctorService(AppointmentSlotRepository appointmentSlotRepo, DoctorRepository doctorRepo)
{
    private readonly AppointmentSlotRepository _appointmentRepository = appointmentSlotRepo;
    private readonly DoctorRepository _doctorRepo = doctorRepo;

    public IEnumerable<AppointmentSlot> GetAllSlots(int doctorId, bool? IsActive = null, bool? IsBooked = null)
    {
        //1) Check if Doctor With DoctorId Exist or Not
        if (!_doctorRepo.Exist(doctorId))
        {
            throw new KeyNotFoundException($"Doctor with Id {doctorId} doesn't exist");
        }
        //2) Get All Appointment Slots For this Doctor
        return _appointmentRepository.GetSlotsByDoctorId(doctorId, IsActive, IsBooked);
    }

    public void AddNewAppointmentSlot(int doctorId, AppointmentSlot slot)
    {
        //1) Check if Doctor With DoctorId Exist or Not
        if (!_doctorRepo.Exist(doctorId))
        {
            throw new KeyNotFoundException($"Doctor with Id {doctorId} doesn't exist");
        }
        //2) Add New Slot
        slot.DoctorId = doctorId;
        _appointmentRepository.Add(slot);
    }

    public void RemoveAppointmentSlot(int doctorId, int slotId)
    {
        //1) Check if Doctor With DoctorId Exist or Not
        if (!_doctorRepo.Exist(doctorId))
        {
            throw new KeyNotFoundException($"Doctor with Id {doctorId} doesn't exist");
        }
        //2) Remove Slot
        _appointmentRepository.Delete(slotId);

    }

    public void UpdateAppointmentSlot(int doctorId, AppointmentSlot slot)
    {
        if (!_doctorRepo.Exist(doctorId))
            throw new KeyNotFoundException($"Doctor with Id {doctorId} doesn't exist");
        slot.DoctorId = doctorId;
        _appointmentRepository.Update(slot);
    }


}
