using EmployeeBonusManagementSystem.Domain.Entities;

namespace EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee
{
    public class EmployeeDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public int? RecommenderEmployeeId { get; set; }
        public String Role { get; set; }
    }
}
