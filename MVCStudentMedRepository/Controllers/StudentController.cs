using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCStudentMedRepository.Data;
using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudent studentRep;

		public StudentController(IStudent studentRep)
		{
			this.studentRep = studentRep;
		}
		// GET: StudentController
		public ActionResult Index()
		{
			return View(studentRep.GetAll());
		}

		// GET: StudentController/Details/5
		public ActionResult Details(int id)
		{
			return View(studentRep.GetById(id));
		}

		// GET: StudentController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: StudentController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Student student)
		{
			try
			{
				if (ModelState.IsValid)
				{
					studentRep.Create(student);
					return RedirectToAction(nameof(Index));
				}
				else
				{
					return View();
				}
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentController/Edit/5
		public ActionResult Edit(int id)
		{
			if (id == null || studentRep.GetAll() == null)
			{
				return NotFound();
			}

			var student = studentRep.GetById(id);
			if (student == null)
			{
				return NotFound();
			}
			return View(student);
		}

		// POST: StudentController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Student student)
		{
			if (id != student.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					studentRep.Update(student);
					return RedirectToAction(nameof(Index));
				}
				catch (Exception)
				{
					return View();
				}
			}
			return View(student);
		}

		// GET: StudentController/Delete/5
		public ActionResult Delete(int id)
		{
			if (id == null || studentRep.GetAll() == null)
			{
				return NotFound();
			}

			var student = studentRep.GetById(id);
			if (student == null)
			{
				return NotFound();
			}
			return View(student);
		}

		// POST: StudentController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (ModelState.IsValid)
			{
				try
				{
					studentRep.Delete(id);
					return RedirectToAction(nameof(Index));
				}
				catch (Exception)
				{
					return View();
				}
			}
			return View(studentRep.GetById(id));
		}
	}
}
