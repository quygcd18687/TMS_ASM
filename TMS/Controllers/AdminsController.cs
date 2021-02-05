using System.Linq;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        
        public ActionResult Index()
        {
            return View();
        }
        
    }
}