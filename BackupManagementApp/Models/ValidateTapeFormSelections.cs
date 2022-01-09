using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class ValidateTapeFormSelections: ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tape = (Tape)validationContext.ObjectInstance;

            if (tape.BackupTypesId == 1 && tape.WeekId == null && tape.MonthId == null)
                return ValidationResult.Success;

            //if (tape.BackupTypesId == 2 && tape.WeekId == null)
            //    return new ValidationResult("Week number must be selected for weekly tapes.");

            //if (tape.BackupTypesId == 3 && tape.MonthId == null)
            //    return new ValidationResult("Month must be selected for monthly tapes.");

            return tape.BackupTypesId != 0 ? ValidationResult.Success : new ValidationResult("Please select a BackupType");
        }

    }
}