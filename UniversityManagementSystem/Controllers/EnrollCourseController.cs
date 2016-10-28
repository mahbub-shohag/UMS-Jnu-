using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class EnrollCourseController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: EnrollCourse
        //public ActionResult Index()
        //{
        //    var enrollCourses = db.EnrollCourses.Include(e => e.Course).Include(e => e.Student);
        //    return View(enrollCourses.ToList());
        //}

        //// GET: EnrollCourse/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EnrollCourse enrollCourse = db.EnrollCourses.Find(id);
        //    if (enrollCourse == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(enrollCourse);
        //}

        //// GET: EnrollCourse/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name");
        //    return View();
        //}

        //// POST: EnrollCourse/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "EnrollCourseId,StudentId,CourseId,EnrollDate,GradeName")] EnrollCourse enrollCourse)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.EnrollCourses.Add(enrollCourse);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollCourse.CourseId);
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", enrollCourse.StudentId);
        //    return View(enrollCourse);
        //}

        //// GET: EnrollCourse/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EnrollCourse enrollCourse = db.EnrollCourses.Find(id);
        //    if (enrollCourse == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollCourse.CourseId);
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", enrollCourse.StudentId);
        //    return View(enrollCourse);
        //}

        //// POST: EnrollCourse/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "EnrollCourseId,StudentId,CourseId,EnrollDate,GradeName")] EnrollCourse enrollCourse)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(enrollCourse).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollCourse.CourseId);
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", enrollCourse.StudentId);
        //    return View(enrollCourse);
        //}

        //// GET: EnrollCourse/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EnrollCourse enrollCourse = db.EnrollCourses.Find(id);
        //    if (enrollCourse == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(enrollCourse);
        //}

        //// POST: EnrollCourse/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    EnrollCourse enrollCourse = db.EnrollCourses.Find(id);
        //    db.EnrollCourses.Remove(enrollCourse);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


        //////////////////////////

        public ActionResult Index()
        {
            var enrollcourses = db.EnrollCourses.Include(e => e.Student).Include(e => e.Course);
            return View(enrollcourses.ToList());
        }

        //
        // GET: /EnrollCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollcourse);
        }

        //
        // GET: /EnrollCourse/Create

        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId");
            ViewBag.CourseId = new SelectList("", "CourseId", "Code");
            return View();
        }

        //
        // POST: /EnrollCourse/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnrollCourse enrollcourse)
        {
            if (ModelState.IsValid)
            {
                var result = db.EnrollCourses.Count(u => u.StudentId == enrollcourse.StudentId && u.CourseId == enrollcourse.CourseId) == 0;
                if (result)
                {
                    TempData["success"] = "Course Enrolled";
                    db.EnrollCourses.Add(enrollcourse);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
                else
                {
                    TempData["Already"] = "Student Has Already Enrolled This Course";
                    return RedirectToAction("Create");
                }
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId", enrollcourse.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollcourse.CourseId);
            return View(enrollcourse);
        }

        public PartialViewResult CourseLoad(int? studentId)
        {

            List<Course> courseList = new List<Course>();
            if (studentId != null)
            {
                Student aStudent = db.Students.Find(studentId);
                courseList = db.Courses.Where(e => e.DepartmentId == aStudent.DepartmentId).ToList();
                ViewBag.CourseId = new SelectList(courseList, "CourseId", "Code");
            }
            return PartialView("~/Views/shared/_FilteredCourse.cshtml");
        }

        public PartialViewResult StudentInfoLoad(int? studentId)
        {
            if (studentId != null)
            {
                Student aStudent = db.Students.FirstOrDefault(s => s.StudentId == studentId);
                ViewBag.Name = aStudent.Name;
                ViewBag.Email = aStudent.Email;
                ViewBag.Dept = aStudent.Department.Name;
                return PartialView("~/Views/Shared/_StudentInformation.cshtml");
            }
            else
            {
                return PartialView("~/Views/Shared/_StudentInformation.cshtml");
            }

        }

        //
        // GET: /EnrollCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId", enrollcourse.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollcourse.CourseId);
            return View(enrollcourse);
        }

        //
        // POST: /EnrollCourse/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EnrollCourse enrollcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId", enrollcourse.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollcourse.CourseId);
            return View(enrollcourse);
        }

        //
        // GET: /EnrollCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollcourse);
        }

        //
        // POST: /EnrollCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            db.EnrollCourses.Remove(enrollcourse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



        ////////////////////////////


    }
}
