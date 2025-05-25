namespace SalaryCalculator.API.Models
{
    public class SalaryCalculationInput
    {
        public int PartTimePercent { get; set; }
        public string ProfessionalLevelName { get; set; } = string.Empty;
        public string ManagementLevelName { get; set; } = string.Empty;
        public int SeniorityYears { get; set; }
        public bool LawBonusEligible { get; set; }
        public string LawBonusGroupName { get; set; } = string.Empty;
    }
}
