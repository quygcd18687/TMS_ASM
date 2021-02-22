using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;
using TMS.ViewModels;

namespace TMS.Controllers
{
    public class AssignedCourseController : Controller
    {
        private ApplicationDbContext _context;
        public AssignedCourseController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(int id)
        {
           
            var trainerInCourse = _context.Users.OfType<Trainer>().Where(t => t.UsersId == id).ToList();
            var traineeInCourse = _context.Users.OfType<Trainee>().Where(t => t.UsersId == id).ToList();
            var CategoryOfCourse = _context.Categories.Where(m => m.Id == id).ToList();
                    
            var listCourseView = new ListCourseView()
            {
                Trainers = trainerInCourse,
                Trainees = traineeInCourse,
                
                Course = _context.Courses.SingleOrDefault(c => c.Id == id) 

            };
            return View(listCourseView);
        }
        [HttpGet]
        public ActionResult CreateTrainerAssign(int id)
        {
            var trainerNotInCourse = _context.Users.OfType<Trainer>().Where(c => c.CourseId == null).ToList();
            var trainerandtraineecourselist = new ListCourseView
            {
                Trainers = trainerNotInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(trainerandtraineecourselist);
        }

        [HttpPost]
        public ActionResult CreateTrainerAssign(string CourseId, int TrainerId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.UsersId == TrainerId);
            trainer.CourseId = courseId;
            _context.SaveChanges();
            return RedirectToAction("Index/", new { id = CourseId });
        }
        [HttpGet]
        public ActionResult ChangeTrainerAssign(int CourseId, int id)
        {
            var trainerChange = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.UsersId == id);
            var CoursesExclude = _context.Courses.Where(c => c.Id != CourseId);

            var changeViewmodel = new ChangeAssignForTrainer()
            {
                Courses = CoursesExclude,
                Trainer = trainerChange,
            };
            return View(changeViewmodel);
        }

        [HttpPost]
        public ActionResult ChangeTrainerAssign(string CourseId, int id)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.UsersId == id);
            trainer.CourseId = courseId;
            _context.SaveChanges();
            return RedirectToAction("Index/", new { Id = CourseId });
        }
        [HttpPost]
        public ActionResult DeleteTrainerAssign(string CourseId, int TrainerId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.UsersId == TrainerId);
            trainer.CourseId = null;
            _context.SaveChanges();
            return RedirectToAction("Index/" + CourseId);
        }

        ///traineeasssign/////

        [HttpGet]
        public ActionResult CreateTraineeAssign(int id)
        {
            var traineeNotInCourse = _context.Users.OfType<Trainee>().Where(c => c.CourseId == null).ToList();
            var listCourseView = new ListCourseView()
            {
                Trainees = traineeNotInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(listCourseView);
        }

        [HttpPost]
        public ActionResult CreateTraineeAssign(string CourseId, int TraineeId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainee = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.UsersId == TraineeId);
            trainee.CourseId = courseId;
            _context.SaveChanges();
            return RedirectToAction("Index/" + CourseId);
        }

        [HttpGet]
        public ActionResult ChangeTraineeAssign(int CourseId, int TraineeId)
        {
            var traineechange = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.UsersId == TraineeId);
            var coursesexclude = _context.Courses.Where(c => c.Id != CourseId);

            var changeViewmodel = new ChangeAssignForTrainee()
            {
                Courses = coursesexclude,
                Trainee = traineechange,
            };
            return View(changeViewmodel);
        }

        [HttpPost]
        public ActionResult ChangeTraineeAssign(string CourseId, int TrainerId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainee = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.UsersId == TrainerId);
            trainee.CourseId = courseId;
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = CourseId });
        }
        [HttpPost]
        public ActionResult DeleteTraineeAssign(string CourseId, int TraineeId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainee = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.UsersId == TraineeId);
            trainee.CourseId = null;
            _context.SaveChanges();
            return RedirectToAction("Index/" + CourseId);
        }
    }
}