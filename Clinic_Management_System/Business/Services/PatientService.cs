using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Core.Interfaces;
using System.Data.Common;

namespace Clinic_Management_System.Business.Services;

internal class PatientService(IRepository<Patient> patientRepo)
{
    private readonly IRepository<Patient> _patientRepo = patientRepo;

    public IEnumerable<Patient> GetAllPatients() => _patientRepo.GetAll();

    public Patient GetPatientById(int patientId) => _patientRepo.GetById(patientId);

    public void AddNewPatient(Patient patient)
    {
        try
        {
            _patientRepo.Add(patient);
        }
        catch (Exception ex)
        {
            throw new Exception($"Falied to Add new Patient, {ex.Message}");

        }
    }

    public void DeletePatient(int patientId)
    {
        try
        {
            _patientRepo.Delete(patientId);
        }
        catch (Exception ex)
        {
            throw new Exception($"Patient with Id:{patientId} Not found, {ex.Message}");

        }
    }

    public void UpdatePatient(int patientId, Patient patient)
    {
        patient.UserId = patientId;
        _patientRepo.Update(patient);
    }

   
}
