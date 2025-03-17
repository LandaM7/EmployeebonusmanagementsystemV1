using EmployeeBonusManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBonusManagementSystem.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<BonusEntity> Bonuses { get; set; }
    public DbSet<BonusConfigurationEntity> BonusConfigurations { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<EmployeeDepartmentEntity> EmployeeDepartments { get; set; }
    public DbSet<RecommenderEmployeeEntity> RecommenderEmployees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
