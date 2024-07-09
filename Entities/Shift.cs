namespace WebApplication1.Entities;

public class Shift
{
    public int ShiftId { get; set; }
    public DateTime Date { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}