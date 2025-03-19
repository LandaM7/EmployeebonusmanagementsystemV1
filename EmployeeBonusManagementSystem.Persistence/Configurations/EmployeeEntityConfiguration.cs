using EmployeeBonusManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeBonusManagementSystem.Persistence.Configurations;

public class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.PersonalNumber)
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.Salary)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(e => e.UserName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.Password)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.IsPasswordChanged)
            .IsRequired();

        builder.Property(e => e.PasswordChangeDate)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .IsRequired();

        builder.HasOne<DepartmentEntity>()
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne<EmployeeEntity>()
			.WithMany() 
			.HasForeignKey(e => e.RecommenderEmployeeId) 
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne<EmployeeEntity>()
			.WithMany() 
			.HasForeignKey(e => e.CreateByUserId) 
			.OnDelete(DeleteBehavior.Restrict);

	}
}