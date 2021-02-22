using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;
using TMS.ViewModels;
using System.Data.Entity;
namespace TMS.Controllers
{


	public class CourseController : Controller
	{

		private ApplicationDbContext _context;
		public CourseController()
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
			if (!ModelState.IsValid)
			{
				return View();
			}
			var newCourse = new Course()
			{
				Name = course.Name,
				Description = course.Description,
				Category = course.Category
			};

			_context.Courses.Add(newCourse);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}



		/// <summary>
		/// This function is used for course editing
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
			var categoriesInDb = _context.Categories;
			if (courseInDb == null) return HttpNotFound();
			//var categories = categoriesInDb.toList();
			//ViewBag.Categories = new SelectList(categories, "Id", "Name", "Desceription");
			return View(courseInDb);
		}

		[HttpPost]
		public ActionResult Edit(Course course)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var InforCourseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);

			if (InforCourseInDb == null) return HttpNotFound();

			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);

			courseInDb.Name = course.Name;
			courseInDb.Description = course.Description;
			courseInDb.Category = course.Category;
		
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)

		{

			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);

			if (courseInDb == null) return HttpNotFound();

			_context.Courses.Remove(courseInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}