namespace WebApplication1.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Role> Roles { get; set; } = new List<Role>();
    public List<Shift> Shifts { get; set; } = new List<Shift>();
}