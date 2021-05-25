using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class StaffsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public StaffsController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );
        }
        // GET: Staffs
        public ActionResult Index(string searchInput)
        {
            var staffs = _context.Staffs.ToList();

            if (!searchInput.IsNullOrWhiteSpace())
            {
                staffs = _context.Staffs
                     .Where(s => s.FullName.Contains(searchInput))
                     .ToList();
            }
            return View(staffs);
        }
        public ActionResult Edit(string id)
        {
            var staffInDb = _context.Staffs.SingleOrDefault(t => t.Id == id);
            if (staffInDb == null)
            {
                return HttpNotFound();
            }
            return View(staffInDb);
        }
        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var staffInDb = _context.Staffs.SingleOrDefault(s => s.Id == staff.Id);
            {
                staffInDb.FullName = staff.FullName;
                staffInDb.Location = staff.Location;
                staffInDb.DateOfBirth = staff.DateOfBirth;
                staffInDb.Email = staff.Email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);
            var staffInDb = _context.Staffs.SingleOrDefault(s => s.Id == id);
            if (userInDb == null)
            {

                return HttpNotFound();
            }
            if (staffInDb == null)
            {
                return HttpNotFound();
            }
            _context.Staffs.Remove(staffInDb);
            _context.Users.Remove(userInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}