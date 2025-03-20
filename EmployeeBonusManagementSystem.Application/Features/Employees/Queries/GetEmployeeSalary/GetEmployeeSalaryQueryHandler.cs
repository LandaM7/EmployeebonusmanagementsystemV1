using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Features.Employees.Queries.GetEmployeeBonus;
using MediatR;

namespace EmployeeBonusManagementSystem.Application.Features.Employees.Queries.GetEmployeeSalary
{
    internal class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, List<GetEmployeeSalaryDto>>
    {
	    private readonly IEmployeeRepository _employeeRepository;
	    private readonly IMapper _mapper;

	    public GetEmployeeSalaryQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
	    {
		    _employeeRepository = employeeRepository;
		    _mapper = mapper;
	    }

	    public async Task<List<GetEmployeeSalaryDto>> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken)
	    {
		    var salary = await _employeeRepository.GetEmployeeSalary(request.personalNumber);
		    return _mapper.Map<List<GetEmployeeSalaryDto>>(salary);
	    }
    }
}
