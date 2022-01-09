using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class ValidateMonthSelection : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tape = (Tape)validationContext.ObjectInstance;

            if (tape.BackupTypesId == BackupTypes.MonthlyBackup && tape.WeekId != null)
                return ValidationResult.Success;

            if (tape.BackupTypesId == BackupTypes.MonthlyBackup && tape.WeekId == null)
                return new ValidationResult("Month should be selected for monthly tapes.");

            if (tape.BackupTypesId != BackupTypes.MonthlyBackup && tape.WeekId != null && tape.MonthId!=null)
                return new ValidationResult("No month should be selected for this type of tape.");
            if (tape.BackupTypesId == BackupTypes.YearlyBackup && tape.MonthId != 12)
                return new ValidationResult("December must be selected for Yearly Tapes.");

            return tape.BackupTypesId != 3 ? ValidationResult.Success : new ValidationResult("Month should be selected for Monhly tapes.");

        }
    }
}