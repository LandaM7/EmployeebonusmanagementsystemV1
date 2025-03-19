using EmployeeBonusManagementSystem.Application.Features.Employees.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Application.Services.Interfaces
{
	public interface IEmployeeService<T>
	{
		Task AddEmployeeAsync(EmployeeDto employeeDto, string role);
		Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
		//Task<EmployeeDto> GetEmployeeByIdAsync(string id);
	}
}