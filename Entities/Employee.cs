namespace WebApplication1.Entities;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Shift> Shifts { get; set; }
}