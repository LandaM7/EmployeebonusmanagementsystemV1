//using EmployeeBonusManagementSystem.Application.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace EmployeeBonusManagementSystem.Api.Controllers
//{
//    [ApiController]
//    [Route("api/reports")]
//    public class ReportController : ControllerBase
//    {
//        private readonly ReportService _reportService;

//        public ReportController(ReportService reportService)
//        {
//            _reportService = reportService;
//        }

//        [HttpGet("TotalBonuses")]
//        public async Task<IActionResult> GetTotalBonuses([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
//        {
//            var result = await _reportService.GetTotalBonusesAsync(startDate, endDate);
//            return Ok(result);
//        }

//        [HttpGet("Top10Employees")]
//        public async Task<IActionResult> GetTop10EmployeesByBonus([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
//        {
//            var result = await _reportService.GetTop10EmployeesByBonusAsync(startDate, endDate);
//            return Ok(result);
//        }

//        [HttpGet("Top10Recommenders")]
//        public async Task<IActionResult> GetTop10RecommendersByBonus([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
//        {
//            var result = await _reportService.GetTop10RecommendersByBonusAsync(startDate, endDate);
//            return Ok(result);
//        }

//        [HttpGet("TotalBonusesByDepartment")]
//        public async Task<IActionResult> GetTotalBonusesByDepartment([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
//        {
//            var result = await _reportService.GetTotalBonusesByDepartmentAsync(startDate, endDate);
//            return Ok(result);
//        }


//        [HttpGet("TotalSalariesByDepartment")]
//        public async Task<IActionResult> GetTotalSalariesByDepartment([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
//        {
//            var result = await _reportService.GetTotalSalariesByDepartmentAsync(startDate, endDate);
//            return Ok(result);
//        }
//    }
//}


