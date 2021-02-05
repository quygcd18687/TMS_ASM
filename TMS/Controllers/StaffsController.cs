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
        public ActionResult Details(string id)
        {
            var staffInfo = _context.Users.OfType<Staff>().SingleOrDefault(m => m.Id == id);
            return View(staffInfo);
        }
    }
}