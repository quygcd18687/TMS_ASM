using System.Linq;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class StaffsController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Staffs
        public StaffsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var StaffList = _context.Users.OfType<Staff>().ToList();
            return View(StaffList);
        }
        public ActionResult Details(int id)
        {
            var staffInfo = _context.Users.OfType<Staff>().SingleOrDefault(m => m.UsersId == id);
            return View(staffInfo);
        }
        public ActionResult Delete(int id)
        {
            var trainerDb = _context.Trainers.SingleOrDefault(t => t.UsersId == id);
            _context.Trainers.Remove(trainerDb);
            _context.SaveChanges();
            return View();
        }
    }
}