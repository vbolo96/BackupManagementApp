using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackupManagementApp.Dtos
{
    public class BackupSystemDto
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

    }
}