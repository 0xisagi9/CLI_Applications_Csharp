namespace Clinic_Management_System.Business.Models;

internal class AppointmentSlot
{
    public int SlotId { get; set; }
    public int DoctorId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsBooked { get; set; }

    public bool IsActive { get; set; }

    public AppointmentSlot() { }

    public AppointmentSlot(int slotId, int doctorId, DateTime? startTime, DateTime? endTime, bool isBooked, bool isActive)
    {
        SlotId = slotId;
        DoctorId = doctorId;
        StartTime = startTime;
        EndTime = endTime;
        IsBooked = isBooked;
        IsActive = isActive;
    }

    public AppointmentSlot(int doctorId, DateTime? startTime, DateTime? endTime)
    {
        DoctorId = doctorId;
        StartTime = startTime;
        EndTime = endTime;

    }

    public override string ToString()
    {
        return $"Slot ID: {SlotId}, " +
          $"Doctor ID: {DoctorId}, " +
          $"Start Time: {(StartTime.HasValue ? StartTime.Value.ToString("yyyy-MM-dd HH:mm") : "N/A")}, " +
          $"End Time: {(EndTime.HasValue ? EndTime.Value.ToString("yyyy-MM-dd HH:mm") : "N/A")}, " +
          $"Is Booked: {(IsBooked ? "Yes" : "No")}," +
          $"Is Active: {(IsActive ? "Yes" : "No")}";
    }


}
