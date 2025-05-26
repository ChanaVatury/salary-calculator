using SalaryCalculator.API.Models;

namespace SalaryCalculator.API.Services
{
    public interface ISalaryService
    {
        Task<List<PartTimePercent>> GetPartTimePercentsAsync();
        Task<List<ProfessionalLevel>> GetProfessionalLevelsAsync();
        Task<List<ManagementLevel>> GetManagementLevelsAsync();
        Task<List<LawBonusGroup>> GetLawBonusGroupsAsync();
        Task<SalaryCalculationResult> CalculateSalaryAsync(SalaryCalculationResult input);
    }
}
