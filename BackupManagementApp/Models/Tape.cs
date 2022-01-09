using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class Tape
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        [RegularExpression("^RS\\d{4}L[1-9]{1}$", ErrorMessage = "BarCode should be like this format: RS0099L6")]
        public string BarCode { get; set; }
        [Display(Name = "Backup System")]
        public BackupSystem BackupSystem { get; set; }
        [Display(Name = "Backup System")]
        [Required]
        public byte BackupSystemId { get; set; }

        [Display(Name = "Backup Type")]
        public BackupTypes BackupTypes { get; set; }
        [Display(Name = "Backup Type")]
        [Required]
        [ValidateTapeFormSelections]
        public byte BackupTypesId { get; set; }
        [Display(Name = "Day")]
        public Day Day { get; set; }
        [Display(Name ="Day")]
        [Required]
        [ValidateDaySelection]
        public byte DayId { get; set; }
        [Display(Name = "Week")]
        public Week Week { get; set; }
        [Display(Name = "Week")]
        [ValidateWeekSelection]
        public byte? WeekId { get; set; }
        [Display(Name = "Month")]
        public Month Month { get; set; }
        [Display(Name = "Month")]
        [ValidateMonthSelection]
        public byte? MonthId { get; set; }

        [Required]
        [StringLength(255)]
        public string Details { get; set; }

    }
}