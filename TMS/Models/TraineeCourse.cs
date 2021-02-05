using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class TraineeCourse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Required]
        public string TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public DateTime Time { get; set; }
    }
}