using AutoMapper;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Features.Employees.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagementSystem.Application.Features.Employees.Queries.GetEmployeeBonus
{
    internal class GetEmployeeBonusQueryHandler : IRequestHandler<GetEmployeeBonusQuery, List<GetEmployeeBonusDto>>
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMapper _mapper;

		public GetEmployeeBonusQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
		{
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}

		public async Task<List<GetEmployeeBonusDto>> Handle(GetEmployeeBonusQuery request, CancellationToken cancellationToken)
		{
			//TODO   -------- add this ------------- 
			var employees = await _employeeRepository.GetAllEmployeesAsync();
			return _mapper.Map<List<GetEmployeeBonusDto>>(employees);
		}
	}
}
