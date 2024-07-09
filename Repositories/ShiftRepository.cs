using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories;

public class ShiftRepository : IShiftRepository
{
    private readonly DataContext _context;

    public ShiftRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Shift> GetByIdAsync(int id)
    {
        return await _context.Shifts.FindAsync(id);
    }

    public async Task<List<Shift>> GetAllAsync()
    {
        return await _context.Shifts.ToListAsync();
    }

    public async Task<Shift> CreateAsync(Shift shift)
    {
        _context.Shifts.Add(shift);
        await _context.SaveChangesAsync();
        return shift;
    }

    public async Task<Shift> UpdateAsync(Shift shift)
    {
        _context.Entry(shift).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return shift;
    }

    public async Task DeleteAsync(int id)
    {
        var shift = await _context.Shifts.FindAsync(id);
        _context.Shifts.Remove(shift);
        await _context.SaveChangesAsync();
    }
}