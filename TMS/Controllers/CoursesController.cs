using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            //var courseslist = _context.Courses.ToList();
            //return View(courseslist);
            return View();
        }

    }
}