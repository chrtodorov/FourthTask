using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly DataContext _context;

    public RoleRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Role> GetAllRoles()
    {
        return _context.Roles.ToList();
    }

    public Role GetRoleById(int id)
    {
        return _context.Roles.Find(id);
    }

    public void AddRole(Role role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();
    }

    public void UpdateRole(Role role)
    {
        _context.Roles.Update(role);
        _context.SaveChanges();
    }

    public void DeleteRole(int id)
    {
        var role = _context.Roles.Find(id);
        if (role != null)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}