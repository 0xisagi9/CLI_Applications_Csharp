

namespace Clinic_Management_System.Business.Models;

internal class AppointmentSlot
{
    public int SlotId { get; set; }
    public int DoctorId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsBooked { get; set; }

    public AppointmentSlot() { }

    public AppointmentSlot(int slotId, int doctorId, DateTime? startTime, DateTime? endTime, bool isBooked)
    {
        SlotId = slotId;
        DoctorId = doctorId;
        StartTime = startTime;
        EndTime = endTime;
        IsBooked = isBooked;
    }


}
