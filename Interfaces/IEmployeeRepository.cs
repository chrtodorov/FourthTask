using WebApplication1.Entities;

namespace WebApplication1.Interfaces;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAllEmployees();
    Employee GetEmployeeById(int id);
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int id);
}