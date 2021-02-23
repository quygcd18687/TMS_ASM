using System;
using System.ComponentModel.DataAnnotations;

namespace TMS.Models
{
    public class Account : ApplicationUser
    {
       
        [Required]
        public string FullName { get; set; }
        [Required]  
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Location { get; set; }
        public Int32? CourseId { get; set; }
        public Course course { get; set; }
    }
}