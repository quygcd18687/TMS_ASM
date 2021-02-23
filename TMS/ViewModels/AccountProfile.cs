using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Models;

namespace TMS.ViewModels
{
    public class AccountProfile
    {
        public Trainer TrainersView { get; set; }
        public Trainee TraineesView { get; set; }
        public  ApplicationUser UsersView { get; set; }
    }
}