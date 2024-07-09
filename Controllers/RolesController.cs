using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;

    public RolesController(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Role>> GetAllRoles()
    {
        return Ok(_roleRepository.GetAllRoles());
    }

    [HttpGet("{id}")]
    public ActionResult<Role> GetRoleById(int id)
    {
        var role = _roleRepository.GetRoleById(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public ActionResult<Role> PostRole(Role role)
    {
        _roleRepository.AddRole(role);
        return CreatedAtAction("GetRoleById", new { id = role.RoleId }, role);
    }

    [HttpPut("{id}")]
    public IActionResult PutRole(int id, Role role)
    {
        if (id != role.RoleId)
        {
            return BadRequest();
        }

        _roleRepository.UpdateRole(role);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRole(int id)
    {
        _roleRepository.DeleteRole(id);
        return NoContent();
    }
}