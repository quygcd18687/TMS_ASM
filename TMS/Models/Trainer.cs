using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class Trainer: Account
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string WorkingPlace { get; set; }
        
    }
}