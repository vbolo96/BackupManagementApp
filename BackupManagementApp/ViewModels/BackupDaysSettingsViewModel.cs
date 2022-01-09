using BackupManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackupManagementApp.ViewModels
{
    public class BackupDaysSettingsViewModel
    {        
        public List<Day> Days { get; set; }

        [ValidateWeeklyBackupDaySelection]
        public Day Day { get; set; }

    }
}