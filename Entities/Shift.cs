namespace WebApplication1.Entities;

public class Shift
{
    public int ShiftId { get; set; }
    public string Name { get; set; }

    public ICollection<EmployeeShift> EmployeeShifts { get; set; }
}