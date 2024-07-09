using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;

    public EmployeeRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateAsync(Employee employee)
    {
        _context.Entry(employee).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
}