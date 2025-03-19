using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagementSystem.Application.Features.Employees.Queries.GetEmployeeBonus
{
    public class GetEmployeeBonusDto
    {
        public string EmployeeFullName { get; set; }
        public decimal Bonus { get; set; }
        public DateTime DateOfBonus { get; set; }
     
    }
}
