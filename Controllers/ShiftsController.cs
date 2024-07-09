using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController : ControllerBase
{
    private readonly IShiftRepository _shiftRepository;
    private readonly IMapper _mapper;

    public ShiftsController(IShiftRepository shiftRepository, IMapper mapper)
    {
        _shiftRepository = shiftRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShiftDto>>> GetAllShifts()
    {
        var shifts = await _shiftRepository.GetAllAsync();
        var shiftDtos = _mapper.Map<List<ShiftDto>>(shifts);
        return Ok(shiftDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftDto>> GetShift(int id)
    {
        var shift = await _shiftRepository.GetByIdAsync(id);
        if (shift == null)
        {
            return NotFound();
        }
        var shiftDto = _mapper.Map<ShiftDto>(shift);
        return Ok(shiftDto);
    }

    [HttpPost]
    public async Task<ActionResult<ShiftDto>> CreateShift(ShiftDto shiftDto)
    {
        var shift = _mapper.Map<Shift>(shiftDto);
        shift = await _shiftRepository.CreateAsync(shift);
        shiftDto = _mapper.Map<ShiftDto>(shift);
        return CreatedAtAction(nameof(GetShift), new { id = shiftDto.Id }, shiftDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShift(int id, ShiftDto shiftDto)
    {
        if (id != shiftDto.Id)
        {
            return BadRequest();
        }

        var shift = _mapper.Map<Shift>(shiftDto);
        await _shiftRepository.UpdateAsync(shift);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShift(int id)
    {
        await _shiftRepository.DeleteAsync(id);
        return NoContent();
    }
}
