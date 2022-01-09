using BackupManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class ValidateWeeklyBackupDaySelection :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<int> dailyBDays = new List<int>();
            
            var DaysSettings = (BackupDaysSettingsViewModel)validationContext.ObjectInstance;

            var dailyBackupDays = DaysSettings.Days.Where(d => d.IsDailyTape == true).ToList();
            var weeklyBackupDay = DaysSettings.Day.Id;

            foreach (var day in dailyBackupDays)
            {
                dailyBDays.Add(dailyBackupDays.IndexOf(day)+1);
            }

            return dailyBDays.Contains(weeklyBackupDay) ? new ValidationResult("This Day is already selected for a different backup type."): ValidationResult.Success;
        }
    }
}