namespace WebApplication1.Entities;

public class EmployeeShift
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int ShiftId { get; set; }
    public Shift Shift { get; set; }
}