using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCStudentMedRepository.Data;
using MVCStudentMedRepository.Models;
using MVCStudentMedRepository.ViewModels;

namespace MVCStudentMedRepository.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IStudent studentRep;
        private readonly ICourse courseRep;
        private readonly IStudentCourse studentCourseRep;

        public StudentCourseController(IStudent studentRep, ICourse courseRep, IStudentCourse studentCourseRep)
        {
            this.studentRep = studentRep;
            this.courseRep = courseRep;
            this.studentCourseRep = studentCourseRep;
        }

        // GET: StudentCourse
        public IActionResult Index()
        {

            //StudentCourseViewModel studentCourseVM = new StudentCourseViewModel();
            //studentCourseVM.StudentCourse = studentCourseRep.GetAll();
            //studentCourseVM.Student = studentRep.GetById(studentCourseVM.StudentCourse.StudentId);
            //studentCourseVM.Course = courseRep.GetById(studentCourseVM.StudentCourse.CourseId);
            return View(studentCourseRep.GetAll());
        }

        // GET: StudentCourse/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || studentCourseRep.GetById(id) == null)
            {
                return NotFound();
            }
            StudentCourseViewModel studentCourseVM = new StudentCourseViewModel();
            studentCourseVM.StudentCourse = studentCourseRep.GetById(id);
            studentCourseVM.Student = studentRep.GetById(studentCourseVM.StudentCourse.StudentId);
            studentCourseVM.Course = courseRep.GetById(studentCourseVM.StudentCourse.CourseId);
            return View(studentCourseVM);
        }

        // GET: StudentCourse/Create
        public IActionResult Create()
        {
            ViewBag.Students = new SelectList(studentRep.GetAll(), "Id", "FirstName");
            ViewBag.Courses = new SelectList(courseRep.GetAll(), "Id", "Name");
            return View();
        }

        // POST: StudentCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StudentId,CourseId,Grade,Completed")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                studentCourseRep.Create(studentCourse);
                return RedirectToAction(nameof(Index));
            }
            return View(studentCourse);
        }

        // GET: StudentCourse/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.Students = new SelectList(studentRep.GetAll(), "Id", "FirstName");
            ViewBag.Courses = new SelectList(courseRep.GetAll(), "Id", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = studentCourseRep.GetById(id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            return View(studentCourse);
        }

        // POST: StudentCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,StudentId,CourseId,Grade,Completed")] StudentCourse studentCourse)
        {
            if (id != studentCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    studentCourseRep.Update(studentCourse);
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentCourse);
        }

        // GET: StudentCourse/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null || studentCourseRep.GetAll() == null)
            {
                return NotFound();
            }

            StudentCourseViewModel studentCourseVM = new StudentCourseViewModel();
            studentCourseVM.StudentCourse = studentCourseRep.GetById(id);
            studentCourseVM.Student = studentRep.GetById(studentCourseVM.StudentCourse.StudentId);
            studentCourseVM.Course = courseRep.GetById(studentCourseVM.StudentCourse.CourseId);
            if (studentCourseVM == null)
            {
                return NotFound();
            }

            return View(studentCourseVM);
        }

        // POST: StudentCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    studentCourseRep.Delete(studentCourse);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View();
                }

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
