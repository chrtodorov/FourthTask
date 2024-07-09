using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly DataContext _context;

    public RoleRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<List<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> CreateAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<Role> UpdateAsync(Role role)
    {
        _context.Entry(role).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task DeleteAsync(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }
}