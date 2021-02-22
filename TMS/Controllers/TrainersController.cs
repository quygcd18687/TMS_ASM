using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class TrainersController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Trainers
        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
             var trainersList = _context.Users.OfType<Trainer>().ToList();
            return View(trainersList);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var taskInDb = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.UsersId == id);
            if (taskInDb == null) return HttpNotFound();

            return View(taskInDb);
        }
        [HttpPost]
        public ActionResult Update(Trainer trainer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            var TrainerDb = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == trainer.Id);
            {
                
                TrainerDb.UserName = trainer.UserName;
                TrainerDb.DateOfBirth = trainer.DateOfBirth;
                TrainerDb.PhoneNumber = trainer.PhoneNumber;
                TrainerDb.WorkingPlace = trainer.WorkingPlace;
                TrainerDb.Email = trainer.Email;
                TrainerDb.Type = trainer.Type;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var trainerDb = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.UsersId == id);
            return View(trainerDb);
        }
        public ActionResult Delete(int id)
        {
            var trainerDb = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.UsersId == id);

            if (trainerDb == null) return HttpNotFound();

            _context.Trainers.Remove(trainerDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}