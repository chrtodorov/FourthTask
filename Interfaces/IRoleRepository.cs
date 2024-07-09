using WebApplication1.Entities;

namespace WebApplication1.Interfaces;

public interface IRoleRepository
{
    IEnumerable<Role> GetAllRoles();
    Role GetRoleById(int id);
    void AddRole(Role role);
    void UpdateRole(Role role);
    void DeleteRole(int id);
}