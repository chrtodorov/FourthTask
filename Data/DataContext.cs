using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Shift> Shifts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Roles)
            .WithMany(r => r.Employees);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Shifts)
            .WithOne(s => s.Employee)
            .HasForeignKey(s => s.EmployeeId);

        modelBuilder.Entity<Shift>()
            .HasOne(s => s.Role)
            .WithMany()
            .HasForeignKey(s => s.RoleId)
            .IsRequired();
    }
}