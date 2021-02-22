using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Models;

namespace TMS.ViewModels
{
    public class AssignCourseForTrainer
    {
        public Course Course { get; set; }
        public Trainer Trainers { get; set; }
    }
}