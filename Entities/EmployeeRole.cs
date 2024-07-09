﻿namespace WebApplication1.Entities;

public class EmployeeRole
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
}