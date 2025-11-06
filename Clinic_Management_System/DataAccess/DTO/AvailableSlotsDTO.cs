using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.DataAccess.DTO;

internal class AvailableSlotsDTO
{
    public string? Name { get; set; }
    public int DoctorId { get; set; }
    public int SlotId { get; set; }
    public string? Specification { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
