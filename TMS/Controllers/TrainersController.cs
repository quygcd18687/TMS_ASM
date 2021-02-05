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
            var trainerlist = _context.Users.ToList();
            return View(trainerlist);
        }
        [HttpGet]
        public ActionResult UpdateProfile(string id)
        {
           
            var Trainers = _context.Users.SingleOrDefault(t => t.Id == id);
            if (Trainers == null) return HttpNotFound();

            return View(Trainers);
        }
        //[HttpPost]
        //public ActionResult UpdateProfile(Trainer trainer)
        //{
        //    var Trainers = _context.Users.SingleOrDefault(t => t.Id == trainer.Id);

        //    Trainers.UserName = trainer.UserName;
        //    Trainers.WorkingPlace = trainer.WorkingPlace;
        //    Trainers.Type = trainer.Type;

        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
    
}