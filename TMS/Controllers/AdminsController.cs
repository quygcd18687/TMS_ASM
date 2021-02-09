using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class AdminsController : Controller
    {
        private ApplicationDbContext _context;
        public AdminsController()
        {
            _context = new ApplicationDbContext();
      
        }
        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }

        
    }
}