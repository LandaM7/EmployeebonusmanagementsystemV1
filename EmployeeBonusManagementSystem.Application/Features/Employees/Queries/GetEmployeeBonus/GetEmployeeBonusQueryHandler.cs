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
		private readonly IBonusRepository _bonusRepository;
		private readonly IMapper _mapper;

		public GetEmployeeBonusQueryHandler(IBonusRepository bonusRepository, IMapper mapper)
		{
			_bonusRepository = bonusRepository;
			_mapper = mapper;
		}

		public async Task<List<GetEmployeeBonusDto>> Handle(GetEmployeeBonusQuery request, CancellationToken cancellationToken)
		{
			var bonusis = await _bonusRepository.GetEmployeeBonus(request.PersonalNumber);
			return _mapper.Map<List<GetEmployeeBonusDto>>(bonusis);
		}
	}
}
