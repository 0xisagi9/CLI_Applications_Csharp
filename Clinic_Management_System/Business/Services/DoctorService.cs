using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Core.Interfaces;
using Microsoft.Data.SqlClient;
using System.Runtime;

namespace Clinic_Management_System.Business.Services;

internal class DoctorService(IRepository<Doctor> doctorRepo)
{
    private readonly IRepository<Doctor> _doctorRepo = doctorRepo;

    public IEnumerable<Doctor> GetAllDoctors() => _doctorRepo.GetAll();
    public void AddNewDoctor(Doctor doctor)
    {
        try
        {
            _doctorRepo.Add(doctor);
        }
        catch (Exception ex)
        {
            throw new Exception($"Falied to Add new Doctor, {ex.Message}");
        }
    }

    public void DeleteDoctor(int doctorId)
    {
        try
        {
            _doctorRepo.Delete(doctorId);
        }
        catch (Exception ex)
        {
            throw new Exception($"Doctor with Id:{doctorId} Not found, {ex.Message}");
        }
    }

    public Doctor GetDoctorById(int doctorId) => _doctorRepo.GetById(doctorId);

    public void UpdateDoctr(int doctorId, Doctor doctor)
    {
        doctor.UserId = doctorId;
        _doctorRepo.Update(doctor);
    }
}
