using SalaryCalculator.API.DAL;
using SalaryCalculator.API.Enums;
using SalaryCalculator.API.Models;

namespace SalaryCalculator.API.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _repository;

        public SalaryService(ISalaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PartTimePercent>> GetPartTimePercentsAsync()
        {
            return await _repository.GetPartTimePercentsAsync();
        }

        public async Task<List<ProfessionalLevel>> GetProfessionalLevelsAsync()
        {
            return await _repository.GetProfessionalLevelsAsync();
        }

        public async Task<List<ManagementLevel>> GetManagementLevelsAsync()
        {
            return await _repository.GetManagementLevelsAsync();
        }

        public async Task<List<LawBonusGroup>> GetLawBonusGroupsAsync()
        {
            return await _repository.GetLawBonusGroupsAsync();
        }

        public async Task<SalaryCalculationResult> CalculateSalaryAsync(SalaryCalculationInput input)
        {
            const int baseHoursPerMonth = 170; // 100% משרה
            decimal baseHourlyRate = 0; // שכר לשעה

            // 1. קביעת שכר שעתי לפי רמה מקצועית
            switch (input.ProfessionalLevel)
            {
                case ProfessionalLevelEnum.Beginner:
                    baseHourlyRate = 100; // שכר יסוד לשעה למתחיל
                    break;
                case ProfessionalLevelEnum.Experienced:
                    baseHourlyRate = 120; // שכר יסוד לשעה למנוסה 
                    break;
                default:
                    baseHourlyRate = 100; // ברירת מחדל
                    break;
            }

            // 2. הוספת תוספת לרמה ניהולית (20 ש"ח לכל רמה)
            int managementLevelNumber = (int)input.ManagementLevel;
            baseHourlyRate += managementLevelNumber * 20;

            // 3. חישוב שכר יסוד לפי אחוז משרה
            decimal salaryBase = baseHourlyRate * baseHoursPerMonth * ((int)input.PartTimePercent / 100m);

            // 4. חישוב תוספת ותק (1.25% לכל שנת ותק)
            decimal seniorityBonusPercent = 1.25m * input.SeniorityYears;
            decimal seniorityBonusAmount = salaryBase * (seniorityBonusPercent / 100m);

            // 5. חישוב תוספת עבודה בחוק (1% לקבוצה א', 0.5% לקבוצה ב')
            decimal lawBonusAmount = 0;
            if (input.LawBonusEligible)
            {
                switch (input.LawBonusGroup)
                {
                    case LawBonusGroupEnum.GroupA:
                        lawBonusAmount = salaryBase * 0.01m;
                        break;
                    case LawBonusGroupEnum.GroupB:
                        lawBonusAmount = salaryBase * 0.005m;
                        break;
                }
            }

            // 6. חישוב שכר לפני תוספת העלאה
            decimal salaryBaseBeforeRaise = salaryBase + seniorityBonusAmount + lawBonusAmount;

            // 7. קביעת אחוז העלאה לפי מדרגות שכר
            decimal raisePercent = 0;
            if (salaryBaseBeforeRaise <= 20000)
                raisePercent = 1.5m;
            else if (salaryBaseBeforeRaise <= 30000)
                raisePercent = 1.25m;
            else
                raisePercent = 1.0m;

            // תוספת של 0.1% לכל רמת ניהול
            raisePercent += managementLevelNumber * 0.1m;

            // 8. חישוב גובה ההעלאה
            decimal raiseAmount = salaryBaseBeforeRaise * (raisePercent / 100m);

            // 9. שכר כולל לאחר ההעלאה
            decimal salaryBaseAfterRaise = salaryBaseBeforeRaise + raiseAmount;

            // 10. בניית תוצאת החישוב
            var result = new SalaryCalculationResult
            {
                BaseSalary = salaryBase,
                SeniorityBonusPercent = seniorityBonusPercent,
                SeniorityBonusAmount = seniorityBonusAmount,
                LawBonusAmount = lawBonusAmount,
                SalaryBeforeRaise = salaryBaseBeforeRaise,
                RaisePercent = raisePercent,
                RaiseAmount = raiseAmount,
                SalaryAfterRaise = salaryBaseAfterRaise
            };

            return await Task.FromResult(result);
        }

        //public async Task<SalaryCalculationResult> CalculateSalaryAsync(SalaryCalculationInput input)
        //{
        //    // ---------------

        //    // 1. חישוב שכר יסוד לפי חלקיות משרה, רמה מקצועית וניהולית
        //    // 2. חישוב תוספת וותק, תוספת עבודה בחוק
        //    // 3. חישוב תוספת העלאה לפי שכר בסיס ורמה ניהולית
        //    // 4. החזרת התוצאה עם כל הפרטים

        //    // ---------------

        //    // דוגמה של חישוב לפי הנתונים שלך

        //    const int baseHoursPerMonth = 170;
        //    decimal baseHourlyRate = 0;

        //    // שכר יסוד לפי רמה מקצועית
        //    switch (input.ProfessionalLevelName)
        //    {
        //        case "מתחיל":
        //            baseHourlyRate = 100;
        //            break;
        //        case "מנוסה":
        //            baseHourlyRate = 120;
        //            break;
        //        default:
        //            baseHourlyRate = 100;
        //            break;
        //    }

        //    // הוספת תשלום לפי רמה ניהולית
        //    int managementLevelNumber = 0;
        //    if (input.ManagementLevelName != "ללא" && int.TryParse(input.ManagementLevelName.Replace("רמת ניהול ", ""), out int level))
        //    {
        //        managementLevelNumber = level;
        //    }
        //    else if (input.ManagementLevelName == "ללא")
        //    {
        //        managementLevelNumber = 0;
        //    }

        //    baseHourlyRate += managementLevelNumber * 20;

        //    // קבלת אחוז משרה
        //    int percentPartTime = input.PartTimePercent;

        //    // חישוב שכר יסוד לפי חלקיות משרה
        //    decimal salaryBase = baseHourlyRate * baseHoursPerMonth * (percentPartTime / 100m);

        //    // חישוב תוספת וותק (1.25% לשנה)
        //    decimal seniorityBonusPercent = 1.25m * input.SeniorityYears;
        //    decimal seniorityBonusAmount = salaryBase * (seniorityBonusPercent / 100m);

        //    // חישוב תוספת עבודה בחוק
        //    decimal lawBonusAmount = 0;
        //    if (input.LawBonusEligible)
        //    {
        //        if (input.LawBonusGroupName == "קבוצה א'")
        //            lawBonusAmount = salaryBase * 0.01m; // 1%
        //        else if (input.LawBonusGroupName == "קבוצה ב'")
        //            lawBonusAmount = salaryBase * 0.005m; // 0.5%
        //    }

        //    // שכר בסיס כולל תוספות לפני העלאה
        //    decimal salaryBaseBeforeRaise = salaryBase + seniorityBonusAmount + lawBonusAmount;

        //    // חישוב תוספת העלאה
        //    decimal raisePercent = 0;
        //    if (salaryBaseBeforeRaise <= 20000)
        //        raisePercent = 1.5m;
        //    else if (salaryBaseBeforeRaise <= 30000)
        //        raisePercent = 1.25m;
        //    else
        //        raisePercent = 1.0m;

        //    // הוספת 0.1% לכל רמת ניהול לתוספת
        //    raisePercent += managementLevelNumber * 0.1m;

        //    decimal raiseAmount = salaryBaseBeforeRaise * (raisePercent / 100m);

        //    // שכר בסיס לאחר העלאה
        //    decimal salaryBaseAfterRaise = salaryBaseBeforeRaise + raiseAmount;

        //    // יצירת אובייקט תוצאה
        //    var result = new SalaryCalculationResult
        //    {
        //        BaseSalary = salaryBase,
        //        SeniorityBonusPercent = seniorityBonusPercent,
        //        SeniorityBonusAmount = seniorityBonusAmount,
        //        LawBonusAmount = lawBonusAmount,
        //        SalaryBeforeRaise = salaryBaseBeforeRaise,
        //        RaisePercent = raisePercent,
        //        RaiseAmount = raiseAmount,
        //        SalaryAfterRaise = salaryBaseAfterRaise
        //    };

        //    return await Task.FromResult(result);
        //}
    }
}
