using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class BackupTypes
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        //refactoring magic numbers for backup types
        public static readonly byte DailyBackup = 1;
        public static readonly byte WeeklyBackup = 2;
        public static readonly byte MonthlyBackup = 3;
        public static readonly byte YearlyBackup = 4;
    }
}