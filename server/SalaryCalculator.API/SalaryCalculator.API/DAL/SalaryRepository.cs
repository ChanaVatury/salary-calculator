using Microsoft.EntityFrameworkCore;
using SalaryCalculator.API.Models;

namespace SalaryCalculator.API.DAL
{
    public class SalaryRepository: ISalaryRepository
    {
        private readonly SalaryDbContext _context;

        public SalaryRepository(SalaryDbContext context)
        {
            _context = context;
        }

        public async Task<List<PartTimePercent>> GetPartTimePercentsAsync()
        {
            return await _context.PartTimePercents.ToListAsync();
        }

        public async Task<List<ProfessionalLevel>> GetProfessionalLevelsAsync()
        {
            return await _context.ProfessionalLevels.ToListAsync();
        }

        public async Task<List<ManagementLevel>> GetManagementLevelsAsync()
        {
            return await _context.ManagementLevels.ToListAsync();
        }

        public async Task<List<LawBonusGroup>> GetLawBonusGroupsAsync()
        {
            return await _context.LawBonusGroups.ToListAsync();
        }

        public async Task SaveSalaryCalculationAsync(SalaryCalculationRecord record)
        {
            _context.SalaryCalculations.Add(record);
            await _context.SaveChangesAsync();
        }
    }

}
