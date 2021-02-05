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
            return View(traineesList);
        }
        //public ActionResult ViewProfile(string id)
        //{
        //    //Trainee Trainees = _context.Accounts.SingleOrDefault(t => t.Id == id);
        //    return View();
        //}
    }
}