using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Models;

namespace TMS.ViewModels
{
    public class ListCourseView
    {

        public Course Course { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Trainee> Trainees { get; set; }

    }
}