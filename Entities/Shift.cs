using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities;

public class Shift
{
    [Key]
    public int ShiftId { get; set; }
    public string Name { get; set; }
}