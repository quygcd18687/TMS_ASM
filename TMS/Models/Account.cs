using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class Account : ApplicationUser
    {
        [Key]
        public int UsersId { get; set; }
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