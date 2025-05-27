using SalaryCalculator.API.Models;

namespace SalaryCalculator.API.DAL
{
    public interface ISalaryRepository
    {
        Task<List<PartTimePercent>> GetPartTimePercentsAsync();
        Task<List<ProfessionalLevel>> GetProfessionalLevelsAsync();
        Task<List<ManagementLevel>> GetManagementLevelsAsync();
        Task<List<LawBonusGroup>> GetLawBonusGroupsAsync();
        Task SaveSalaryCalculationAsync(SalaryCalculationRecord record);
    }
}
