using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories;

public class ShiftRepository : IShiftRepository
{
    private readonly DataContext _context;

    public ShiftRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Shift> GetAllShifts()
    {
        return _context.Shifts.Include(s => s.Employee).Include(s => s.Role).ToList();
    }

    public Shift GetShiftById(int id)
    {
        return _context.Shifts
            .Include(s => s.Employee)
            .Include(s => s.Role)
            .FirstOrDefault(s => s.ShiftId == id);
    }

    public void AddShift(Shift shift)
    {
        _context.Shifts.Add(shift);
        _context.SaveChanges();
    }

    public void UpdateShift(Shift shift)
    {
        _context.Shifts.Update(shift);
        _context.SaveChanges();
    }

    public void DeleteShift(int id)
    {
        var shift = _context.Shifts.Find(id);
        if (shift != null)
        {
            _context.Shifts.Remove(shift);
            _context.SaveChanges();
        }
    }
}