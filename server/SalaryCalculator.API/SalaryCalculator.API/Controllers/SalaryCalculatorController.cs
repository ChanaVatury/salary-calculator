using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.API.Models;
using SalaryCalculator.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalaryCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryCalculatorController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryCalculatorController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet("part-time-percents")]
        public async Task<IActionResult> GetPartTimePercents()
        {
            var list = await _salaryService.GetPartTimePercentsAsync();
            return Ok(list);
        }

        [HttpGet("professional-levels")]
        public async Task<IActionResult> GetProfessionalLevels()
        {
            var list = await _salaryService.GetProfessionalLevelsAsync();
            return Ok(list);
        }

        [HttpGet("management-levels")]
        public async Task<IActionResult> GetManagementLevels()
        {
            var list = await _salaryService.GetManagementLevelsAsync();
            return Ok(list);
        }

        [HttpGet("law-bonus-groups")]
        public async Task<IActionResult> GetLawBonusGroups()
        {
            var list = await _salaryService.GetLawBonusGroupsAsync();
            return Ok(list);
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> CalculateSalary([FromBody] SalaryCalculationInput input)
        {
            var result = await _salaryService.CalculateSalaryAsync(input);
            return Ok(result);
        }
    }
}
