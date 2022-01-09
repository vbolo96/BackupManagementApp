using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class Day
    {       
        public byte Id { get; set; }
       
        [StringLength(12)]       
        public string Name { get; set; }
        public bool IsDailyTape { get; set; }
        public bool IsWeeklyTape { get; set; }

    }
}