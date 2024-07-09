using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;

    public EmployeeRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _context.Employees.Include(e => e.Roles).ToList();
    }

    public Employee GetEmployeeById(int id)
    {
        return _context.Employees
            .Include(e => e.Roles)
            .FirstOrDefault(e => e.EmployeeId == id);
    }

    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    public void DeleteEmployee(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}