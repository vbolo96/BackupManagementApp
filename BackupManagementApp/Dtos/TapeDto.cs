using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Dtos
{
    public class TapeDto
    {
        public int Id { get; set; }
        
        public string BarCode { get; set; }

        public BackupSystemDto BackupSystem { get; set; }
        public byte BackupSystemId { get; set; }

        public BackupTypesDto BackupTypes { get; set; }
        public byte BackupTypesId { get; set; }
              
        public byte DayId { get; set; }
       
        public byte? WeekId { get; set; }
       
        public byte? MonthId { get; set; }

        public string Details { get; set; }
    }
}