namespace SalaryCalculator.API.Models
{
    public class SalaryCalculationResult
    {
        public decimal BaseSalary { get; set; }
        public decimal SeniorityBonusPercent { get; set; }
        public decimal SeniorityBonusAmount { get; set; }
        public decimal LawBonusAmount { get; set; }
        public decimal SalaryBeforeRaise { get; set; }
        public decimal RaisePercent { get; set; }
        public decimal RaiseAmount { get; set; }
        public decimal SalaryAfterRaise { get; set; }
    }
}
