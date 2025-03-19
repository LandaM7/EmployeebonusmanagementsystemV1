
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;

namespace EmployeeBonusManagement.Application.Services.Interfaces
{
	public interface IEmployeeService<T>
	{
		Task AddEmployeeAsync(EmployeeDto employeeDto);
		Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
		//Task<EmployeeDto> GetEmployeeByIdAsync(string id);
	}
}