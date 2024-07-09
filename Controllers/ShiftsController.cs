using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftsController : ControllerBase
{
    private readonly IShiftRepository _shiftRepository;

    public ShiftsController(IShiftRepository shiftRepository)
    {
        _shiftRepository = shiftRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Shift>> GetAllShifts()
    {
        return Ok(_shiftRepository.GetAllShifts());
    }

    [HttpGet("{id}")]
    public ActionResult<Shift> GetShiftById(int id)
    {
        var shift = _shiftRepository.GetShiftById(id);
        if (shift == null)
        {
            return NotFound();
        }
        return Ok(shift);
    }

    [HttpPost]
    public ActionResult<Shift> PostShift(Shift shift)
    {
        _shiftRepository.AddShift(shift);
        return CreatedAtAction("GetShiftById", new { id = shift.ShiftId }, shift);
    }

    [HttpPut("{id}")]
    public IActionResult PutShift(int id, Shift shift)
    {
        if (id != shift.ShiftId)
        {
            return BadRequest();
        }

        _shiftRepository.UpdateShift(shift);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteShift(int id)
    {
        _shiftRepository.DeleteShift(id);
        return NoContent();
    }
}