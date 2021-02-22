using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Models;

namespace TMS.ViewModels
{
    public class CourseCategoryViewModels
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}