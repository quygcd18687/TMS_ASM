using System.Linq;
using System.Web.Mvc;
using TMS.Models;


namespace TMS.Controllers
{
    public class TraineesController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Trainee
        public TraineesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var traineesList = _context.Users.OfType<Trainee>().ToList();
            return View(traineesList    );
        }
        public ActionResult ViewProfile(string id)
        {
            var traineeDb = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == id);
            return View(traineeDb);
        }
        [HttpGet]
        public ActionResult Update(string id)
        {
            var TraineeDb = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == id);
            if (TraineeDb == null) return HttpNotFound();

            return View(TraineeDb);
        }
        [HttpPost]
        public ActionResult Update(Trainee trainee)
        {

            var TraineeDb = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == trainee.Id);
            {

                TraineeDb.UserName = trainee.UserName;
                TraineeDb.DateOfBirth = trainee.DateOfBirth;
                TraineeDb.Education = trainee.Education;
                TraineeDb.Pro_Language = trainee.Pro_Language;
                TraineeDb.ToeicScore = trainee.ToeicScore;
                TraineeDb.Experience = trainee.Experience;
                TraineeDb.Location = trainee.Location;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var traineeDb = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == id);

            if (traineeDb == null) return HttpNotFound();

            _context.Trainees.Remove(traineeDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}