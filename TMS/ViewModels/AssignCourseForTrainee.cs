using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Models;

namespace TMS.ViewModels
{
    public class AssignCourseForTrainee
    {
        public Course Course { get; set; }
        public Trainee Trainees { get; set; }

    }
}