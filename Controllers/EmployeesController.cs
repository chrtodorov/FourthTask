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
    public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
    {
        return Ok(await _employeeRepository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> Get(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
    {
        var newEmployee = await _employeeRepository.AddAsync(employee);
        return CreatedAtAction(nameof(Get), new { id = newEmployee.EmployeeId }, newEmployee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Employee employee)
    {
        if (id != employee.EmployeeId)
            return BadRequest();

        await _employeeRepository.UpdateAsync(employee);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _employeeRepository.DeleteAsync(id);
        return NoContent();
    }
}