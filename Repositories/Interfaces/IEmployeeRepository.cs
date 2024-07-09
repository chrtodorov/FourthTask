using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> GetByIdAsync(int id);
    Task<List<Employee>> GetAllAsync();
    Task<Employee> CreateAsync(Employee employee);
    Task<Employee> UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}