using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<Role> GetByIdAsync(int id);
    Task<List<Role>> GetAllAsync();
    Task<Role> CreateAsync(Role role);
    Task<Role> UpdateAsync(Role role);
    Task DeleteAsync(int id);
}