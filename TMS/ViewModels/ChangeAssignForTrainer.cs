﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Models;

namespace TMS.ViewModels
{
    public class ChangeAssignForTrainer
    {
        public IEnumerable<Course> Courses { get; set; }
        public Trainer Trainer { get; set; }
    }
}