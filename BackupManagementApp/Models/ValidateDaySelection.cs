using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class ValidateDaySelection: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<int> dailyBDays = new List<int>();
            int weeklyBDay = 0;
            var _context = new ApplicationDbContext();
            var dailyBackupDays = _context.Days.Where(d => d.IsDailyTape == true).ToList();
            var weeklyBackupDay = _context.Days.Single(d => d.IsWeeklyTape == true);

            foreach (var day in dailyBackupDays)
            {
                dailyBDays.Add(day.Id);
            }
            weeklyBDay = weeklyBackupDay.Id;

            _context.Dispose();

            var tape = (Tape)validationContext.ObjectInstance;

            if (tape.BackupTypesId == BackupTypes.DailyBackup && tape.WeekId == null && tape.MonthId==null && tape.DayId!=0 && dailyBDays.Contains(tape.DayId))
                return ValidationResult.Success;
            if ((tape.BackupTypesId == BackupTypes.WeeklyBackup || tape.BackupTypesId == BackupTypes.MonthlyBackup || tape.BackupTypesId == BackupTypes.YearlyBackup) && tape.DayId != weeklyBDay)
                return new ValidationResult("Selected day is not set as weekly or monthly backup day in backup settings.");
            if(tape.BackupTypesId==BackupTypes.DailyBackup && !dailyBDays.Contains(tape.DayId))
                return new ValidationResult("Selected day is not set as daily backup day in backup settings.");

            return tape.DayId != 0 ? ValidationResult.Success : new ValidationResult("Day should be selected for every backup type.");
        }
    }
}