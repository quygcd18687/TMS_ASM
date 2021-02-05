using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class CourseTrainer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course course { get; set; }
        [Required]
        public string TraierId { get; set; }
        public Trainer Trainer { get; set; }
        public DateTime Time { get; set; }
    }
}