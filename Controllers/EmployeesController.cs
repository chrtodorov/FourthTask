using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllAsync();
        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
        return Ok(employeeDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        var employeeDto = _mapper.Map<EmployeeDto>(employee);
        return Ok(employeeDto);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        employee = await _employeeRepository.CreateAsync(employee);
        employeeDto = _mapper.Map<EmployeeDto>(employee);
        return CreatedAtAction(nameof(GetEmployee), new { id = employeeDto.Id }, employeeDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto employeeDto)
    {
        if (id != employeeDto.Id)
        {
            return BadRequest();
        }

        var employee = _mapper.Map<Employee>(employeeDto);
        await _employeeRepository.UpdateAsync(employee);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteAsync(id);
        return NoContent();
    }
}