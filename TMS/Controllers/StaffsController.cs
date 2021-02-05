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
        [HttpGet]
        public ActionResult CreateStaff()
        {
            var StaffInfo = _context.Users.OfType<Staff>().ToList();
            return View(StaffInfo);
        }

        [HttpPost]
        public ActionResult CreateStaff(Staff staff)
        {
            var newStaff = new Staff()
            {
                UserName = staff.UserName,
                Id = staff.Id,

            };

            _context.Users.Add(newStaff);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}