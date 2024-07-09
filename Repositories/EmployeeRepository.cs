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

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.Include(e => e.Shifts).Include(e => e.Roles).ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Roles)
            .Include(e => e.Shifts)
            .FirstOrDefaultAsync(e => e.EmployeeId == id);
    }

    public async Task<Employee> AddAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task UpdateAsync(Employee employee)
    {
        var existingEmployee = await _context.Employees
            .Include(e => e.Roles) // Assuming you have a proper collection or join entity set up
            .Include(e => e.Shifts)
            .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
    
        if (existingEmployee == null)
        {
            throw new ArgumentNullException("Employee not found.");
        }

        // Update the main properties
        _context.Entry(existingEmployee).CurrentValues.SetValues(employee);

        // Update roles - Assuming employee.Roles is a list of enums or similar
        if (employee.Roles != null)
        {
            existingEmployee.Roles.Clear();
            foreach (var role in employee.Roles)
            {
                existingEmployee.Roles.Add(role);
            }
        }

        // Update shifts - Assuming a direct relationship or you can handle it similarly to roles
        if (employee.Shifts != null)
        {
            existingEmployee.Shifts.Clear(); // Clear existing shifts
            foreach (var shift in employee.Shifts)
            {
                existingEmployee.Shifts.Add(shift); // Add new/updated shifts
            }
        }

        // Save changes in the database
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await GetByIdAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    } 
}