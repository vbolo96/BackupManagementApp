using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class History
    {
        public int Id { get; set; }     
        [MaxLength(8)]
        [MinLength(8)]      
        public string BarCode { get; set; }
      
        [Display(Name = "Backup System")]        
        public byte BackupSystemId { get; set; }        

        [Display(Name = "Backup Type")]      
        public byte BackupTypesId { get; set; }
       
        [Display(Name = "Day")]
        public byte DayId { get; set; }
       
        [Display(Name = "Week")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "N/A")]

        public byte? WeekId { get; set; }
     
        [Display(Name = "Month")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "N/A")]
        public byte? MonthId { get; set; }
      
        [StringLength(255)]
        public string Details { get; set; }
        public DateTime CheckedDate { get; set; }

        public BackupSystem BackupSystem { get; set; }
        public BackupTypes BackupTypes { get; set; }
        public Day Day { get; set; }
        public Month Month { get; set; }
        public Week Week { get; set; }

        public static readonly string NotAssigned = "Not Assigned";
    }
}