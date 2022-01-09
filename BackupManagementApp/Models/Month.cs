using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Models
{
    public class Month
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(12)]
        public string Name { get; set; }
    }
}