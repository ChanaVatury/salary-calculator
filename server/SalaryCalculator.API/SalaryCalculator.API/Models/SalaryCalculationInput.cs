using SalaryCalculator.API.Enums;

namespace SalaryCalculator.API.Models
{
    public class SalaryCalculationInput
    {
        public PartTimePercentEnum PartTimePercent { get; set; }
        public ProfessionalLevelEnum ProfessionalLevel { get; set; }
        public ManagementLevelEnum ManagementLevel { get; set; }
        public decimal SeniorityYears { get; set; }
        public bool LawBonusEligible { get; set; }
        public LawBonusGroupEnum? LawBonusGroup { get; set; } // אם !LawBonusEligible => None

    }
}
