
namespace Clinic_Management_System.Business.Models;

internal class Appointment
{
    public int AppointmentId { get; set; }
    public int SlotId { get; set; }
    public int PatientID { get; set; }
    public string? Status { get; set; }

    public Appointment() { }

    public Appointment(int appointmentId, int slotId, int patientID, string? status)
    {
        AppointmentId = appointmentId;
        SlotId = slotId;
        PatientID = patientID;
        Status = status;
    }
}
