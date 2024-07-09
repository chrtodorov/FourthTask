using WebApplication1.Entities;

namespace WebApplication1.Interfaces;

public interface IShiftRepository
{
    IEnumerable<Shift> GetAllShifts();
    Shift GetShiftById(int id);
    void AddShift(Shift shift);
    void UpdateShift(Shift shift);
    void DeleteShift(int id);
}