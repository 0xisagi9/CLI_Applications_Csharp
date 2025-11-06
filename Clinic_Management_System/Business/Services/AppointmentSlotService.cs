using Clinic_Management_System.Business.Models;
using Clinic_Management_System.Core.Interfaces;
using Clinic_Management_System.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Business.Services;

internal class AppointmentSlotService(IRepository<AppointmentSlot> slotRepo)
{
    private readonly IRepository<AppointmentSlot> _slotRepo = slotRepo;

    public IEnumerable<AppointmentSlot> GetAllSlots()
    {
        return _slotRepo.GetAll();
    }

    public AppointmentSlot GetSlotById(int slotId)
    {
        return _slotRepo.GetById(slotId);
    }

    public void AddNewSlot(AppointmentSlot slot)
    {
        try
        {
            _slotRepo.Add(slot);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to Add new Appointment Slot, {ex.Message}");

        }
    }

    public void DeleteSlot(int slotId)
    {
        try
        {
            _slotRepo.Delete(slotId);
        }
        catch (Exception ex)
        {
            throw new Exception($"Slot with Id:{slotId} Not found, {ex.Message}");
        }
    }

    public void UpdateSlot(AppointmentSlot slot)
    {
    }

    public bool IsExist(AppointmentSlot slot)
    {

        return true;
    }
}