using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetAllEmployees()
    {
        return Ok(_employeeRepository.GetAllEmployees());
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployeeById(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public ActionResult<Employee> PostEmployee(Employee employee)
    {
        _employeeRepository.AddEmployee(employee);
        return CreatedAtAction("GetEmployeeById", new { id = employee.EmployeeId }, employee);
    }

    [HttpPut("{id}")]
    public IActionResult PutEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeId)
        {
            return BadRequest();
        }

        _employeeRepository.UpdateEmployee(employee);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        _employeeRepository.DeleteEmployee(id);
        return NoContent();
    }
}