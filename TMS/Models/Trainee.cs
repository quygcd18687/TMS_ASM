using System;
using System.ComponentModel.DataAnnotations;

namespace TMS.Models
{
    public class Trainee : Account
    {
        public string Education { get; set; }
        [Required]
        public string Pro_Language { get; set; }
        [Required]
        public int ToeicScore { get; set; }
        [Required]
        public string Experience { get; set; }
        

    }
}
