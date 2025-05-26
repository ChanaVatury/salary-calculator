using SalaryCalculator.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalaryCalculator.API.Models
{
    public class SalaryCalculationInput
    {
        [Required]
        public PartTimePercentEnum PartTimePercent { get; set; }
        [Required]
        public ProfessionalLevelEnum ProfessionalLevel { get; set; }
        [Required]
        public ManagementLevelEnum ManagementLevel { get; set; }
        [Required]
        public decimal SeniorityYears { get; set; }
        public bool LawBonusEligible { get; set; }
        public LawBonusGroupEnum? LawBonusGroup { get; set; } // אם !LawBonusEligible => None

    }
}
