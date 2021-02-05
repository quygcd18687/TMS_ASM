using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class Account : ApplicationUser
    {
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Location { get; set; }
    }
}