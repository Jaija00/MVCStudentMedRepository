using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCStudentMedRepository.Data;
using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Controllers
{
	public class CourseController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ICourse courseRep;
		public CourseController(ICourse courseRep)
		{
			this.courseRep = courseRep;
		}

		// GET: Course
		public ActionResult Index()
		{
			return View(courseRep.GetAll());
		}

		// GET: Course/Details/5
		public ActionResult Details(int id)
		{
			return View(courseRep.GetById(id));
		}

		// GET: Course/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Course/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind("Id,Name,Teacher,StartDate,EndDate")] Course course)
		{
			try
			{
				if (ModelState.IsValid)
				{
					courseRep.Create(course);
					return RedirectToAction(nameof(Index));
				}
				else
				{
					return View();
				}
			}
			catch (Exception)
			{
				return View();
			}

		}

		// GET: Course/Edit/5
		public ActionResult Edit(int id)
		{
			if (id == null || courseRep.GetAll() == null)
			{
				return NotFound();
			}

			var course = courseRep.GetById(id);
			if (course == null)
			{
				return NotFound();
			}
			return View(course);
		}

		// POST: Course/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Course course)
		{
			if (id != course.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					courseRep.Update(course);
					return RedirectToAction(nameof(Index));
				}
				catch (Exception)
				{
					return View();
				}
			}
			return View(course);
		}

		// GET: Course/Delete/5
		public ActionResult Delete(int id)
		{
			if (id == null || courseRep.GetAll() == null)
			{
				return NotFound();
			}

			var course = courseRep.GetById(id);
			if (course == null)
			{
				return NotFound();
			}
			return View(course);
		}

		// POST: Course/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (ModelState.IsValid)
			{
				try
				{
					courseRep.Delete(id);
					return RedirectToAction(nameof(Index));
				}
				catch (Exception)
				{
					return View();
				}
			}
			return View(courseRep.GetById(id));
		}
	}
}
