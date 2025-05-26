namespace SalaryCalculator.API.Models
{
    public class SalaryCalculationRecord
    {
            public int Id { get; set; }
            public int PartTimePercentId { get; set; }
            public PartTimePercent PartTimePercent { get; set; }
            public int ProfessionalLevelId { get; set; }
            public ProfessionalLevel ProfessionalLevel { get; set; }
            public int ManagementLevelId { get; set; }
            public ManagementLevel ManagementLevel { get; set; }
            public decimal SeniorityYears { get; set; }
            public bool IsEligibleForLawBonus { get; set; }
            public int? LawBonusGroupId { get; set; }
            public LawBonusGroup LawBonusGroup { get; set; }
            public DateTime CreatedAt { get; set; }
    }
}
