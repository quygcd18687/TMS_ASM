using System.Linq;
using System.Web.Mvc;
using TMS.Models;
using TMS.ViewModels;
using System.Data.Entity;
namespace TMS.Controllers
{
	public class CoursesController : Controller
	{
		private ApplicationDbContext _context;
		public CoursesController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Course
		public ActionResult Index()
		{
			return View(_context.Courses.Include(t => t.Category).ToList());
		}


		/// <summary>
		/// This function is used to create a new course
		/// </summary>
		/// <returns></returns>
		public ActionResult Create()
		{
			var viewModel = new CourseCategoryViewModels()
			{
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]

		public ActionResult Create(Course course)
		{
			var courseInDb = _context.Courses.Where(t => t.Name == course.Name);
			if (course.Name =="")
			{
				return RedirectToAction("Create");
			}
			if (courseInDb.Count() > 0)
			{
				return RedirectToAction("Create");
			}
			if(!ModelState.IsValid)
            {
				return RedirectToAction("Create");
            }
			else
			{
				var newCourse = new Course()
				{
					Name = course.Name,
					Description = course.Description,
					CategoryId = course.CategoryId
				};
				_context.Courses.Add(newCourse);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
			if (courseInDb == null) return HttpNotFound();
			var viewModel = new CourseCategoryViewModels()
			{
				Course = courseInDb,
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(Course course)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CourseCategoryViewModels()
				{
					Course = course,
					Categories = _context.Categories.ToList()
				};
				return View(viewModel);
			}
			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);
			courseInDb.Name = course.Name;
			courseInDb.Description = course.Description;
			courseInDb.CategoryId = course.CategoryId;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
			if (courseInDb == null) return HttpNotFound();
			var trainer = _context.Trainers.Where(t => t.CourseId == id);
			foreach (var item in trainer)
			{
				item.course = null;
				item.CourseId = null;
			}
			var trainee = _context.Trainees.Where(t => t.CourseId == id);
			foreach (var item in trainee)
			{
				item.course = null;
				item.CourseId = null;

			}
			_context.Courses.Remove(courseInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}