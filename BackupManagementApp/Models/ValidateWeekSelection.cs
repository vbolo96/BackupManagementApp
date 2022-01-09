using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class ValidateWeekSelection : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tape = (Tape)validationContext.ObjectInstance;

            if (tape.BackupTypesId == BackupTypes.WeeklyBackup && tape.WeekId != null)
                return ValidationResult.Success;

            if (tape.BackupTypesId == BackupTypes.WeeklyBackup && tape.WeekId == null)
                return new ValidationResult("Week should be selected for weekly tapes.");

            if(tape.BackupTypesId !=BackupTypes.WeeklyBackup && tape.WeekId!=null)
                return new ValidationResult("No week should be selected for this type of tape.");

            return tape.BackupTypesId!=BackupTypes.WeeklyBackup ? ValidationResult.Success: new ValidationResult("Week should be selected for weekly tapes.");

        }
    }
}