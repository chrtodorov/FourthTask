using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RolesController(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoleDto>>> GetAllRoles()
    {
        var roles = await _roleRepository.GetAllAsync();
        var roleDtos = _mapper.Map<List<RoleDto>>(roles);
        return Ok(roleDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDto>> GetRole(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        var roleDto = _mapper.Map<RoleDto>(role);
        return Ok(roleDto);
    }

    [HttpPost]
    public async Task<ActionResult<RoleDto>> CreateRole(RoleDto roleDto)
    {
        var role = _mapper.Map<Role>(roleDto);
        role = await _roleRepository.CreateAsync(role);
        roleDto = _mapper.Map<RoleDto>(role);
        return CreatedAtAction(nameof(GetRole), new { id = roleDto.Id }, roleDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, RoleDto roleDto)
    {
        if (id != roleDto.Id)
        {
            return BadRequest();
        }

        var role = _mapper.Map<Role>(roleDto);
        await _roleRepository.UpdateAsync(role);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        await _roleRepository.DeleteAsync(id);
        return NoContent();
    }
}