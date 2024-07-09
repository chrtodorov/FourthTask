using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces;

public interface IShiftRepository
{
    Task<Shift> GetByIdAsync(int id);
    Task<List<Shift>> GetAllAsync();
    Task<Shift> CreateAsync(Shift shift);
    Task<Shift> UpdateAsync(Shift shift);
    Task DeleteAsync(int id);
}
