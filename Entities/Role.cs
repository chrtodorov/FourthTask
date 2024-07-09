using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    public string Name { get; set; }
}