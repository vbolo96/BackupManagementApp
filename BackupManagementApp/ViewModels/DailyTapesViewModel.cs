using BackupManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.ViewModels
{
    public class DailyTapesViewModel
    {
        public int? Id { get; set; }
        public List<Tape> Tapes { get; set; }
        public List<bool> CheckStatus { get; set; }

        public DateTime CheckingDate { get; set; }

        public IEnumerable<BackupSystem> BackupSystems { get; set; }
        public IEnumerable<BackupTypes> BackupTypes { get; set; }

        public IEnumerable<Day> Days { get; set; }
        public IEnumerable<Week> Weeks { get; set; }
        public IEnumerable<Month> Months { get; set; }

        [Required]
        [StringLength(8)]
        public string BarCode { get; set; }

        [Display(Name = "Backup System")]
        [Required]
        public byte? BackupSystemId { get; set; }

        [Display(Name = "Backup Type")]
        [Required]
        public byte? BackupTypesId { get; set; }

        [Display(Name = "Day")]
        public byte? DayId { get; set; }
        [Display(Name = "Week")]
        public byte? WeekId { get; set; }
        [Display(Name = "Month")]
        public byte? MonthId { get; set; }

        [Required]
        [StringLength(255)]
        public string Details { get; set; }

        public Tape Tape { get; set; }
        public DailyTapesViewModel()
        {

        }
        public DailyTapesViewModel(Tape tape)
        {
           
            Id = tape.Id;
            BarCode = tape.BarCode;
            BackupTypesId = tape.BackupTypesId;
            BackupSystemId = tape.BackupSystemId;
            DayId = tape.DayId;
            WeekId = tape.WeekId;
            MonthId = tape.MonthId;
            Details = tape.Details;
        }
    }
}