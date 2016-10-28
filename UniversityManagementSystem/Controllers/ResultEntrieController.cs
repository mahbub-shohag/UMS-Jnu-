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
    public class ResultEntrieController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: ResultEntrie
        //public ActionResult Index()
        //{
        //    var resultEntries = db.ResultEntries.Include(r => r.Course).Include(r => r.Grade).Include(r => r.Student);
        //    return View(resultEntries.ToList());
        //}

        //// GET: ResultEntrie/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ResultEntry resultEntry = db.ResultEntries.Find(id);
        //    if (resultEntry == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(resultEntry);
        //}

        //// GET: ResultEntrie/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
        //    ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name");
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name");
        //    return View();
        //}

        //// POST: ResultEntrie/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ResultEntryId,StudentId,CourseId,GradeId")] ResultEntry resultEntry)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ResultEntries.Add(resultEntry);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", resultEntry.CourseId);
        //    ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", resultEntry.GradeId);
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", resultEntry.StudentId);
        //    return View(resultEntry);
        //}

        //// GET: ResultEntrie/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ResultEntry resultEntry = db.ResultEntries.Find(id);
        //    if (resultEntry == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", resultEntry.CourseId);
        //    ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", resultEntry.GradeId);
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", resultEntry.StudentId);
        //    return View(resultEntry);
        //}

        //// POST: ResultEntrie/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ResultEntryId,StudentId,CourseId,GradeId")] ResultEntry resultEntry)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(resultEntry).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", resultEntry.CourseId);
        //    ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", resultEntry.GradeId);
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", resultEntry.StudentId);
        //    return View(resultEntry);
        //}

        //// GET: ResultEntrie/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ResultEntry resultEntry = db.ResultEntries.Find(id);
        //    if (resultEntry == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(resultEntry);
        //}

        //// POST: ResultEntrie/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ResultEntry resultEntry = db.ResultEntries.Find(id);
        //    db.ResultEntries.Remove(resultEntry);
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

        ////////////////////////////////

        public ActionResult Index()
        {
            var resultentries = db.ResultEntries.Include(r => r.Student).Include(r => r.Course).Include(r => r.Grade);
            return View(resultentries.ToList());
        }

        //
        // GET: /ResultEntry/Details/5

        public ActionResult Details(int id = 0)
        {
            ResultEntry resultentry = db.ResultEntries.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            return View(resultentry);
        }

        //
        // GET: /ResultEntry/Create

        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId");
            ViewBag.CourseId = new SelectList("", "CourseId", "Code");
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name");
            return View();
        }

        //
        // POST: /ResultEntry/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResultEntry resultentry)
        {
            if (ModelState.IsValid)
            {
                var result =
                    db.ResultEntries.Count(
                        r => r.StudentId == resultentry.StudentId && r.CourseId == resultentry.CourseId) == 0;
                if (result)
                {
                    Grade aGrade = db.Grades.Where(g => g.GradeId == resultentry.GradeId).FirstOrDefault();
                    EnrollCourse resultEnrollCourse =
                        db.EnrollCourses.FirstOrDefault(r => r.CourseId == resultentry.CourseId && r.StudentId == resultentry.StudentId);

                    if (resultEnrollCourse != null) resultEnrollCourse.GradeName = aGrade.Name;

                    db.ResultEntries.Add(resultentry);
                    db.SaveChanges();
                    TempData["success"] = "Result Successfully Entered";
                    return RedirectToAction("Create");
                }
                else
                {
                    TempData["Already"] = "Result Of This Course has Already Been Assigned";
                    return RedirectToAction("Create");
                }
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId", resultentry.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", resultentry.CourseId);
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", resultentry.GradeId);
            return View(resultentry);
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
        // GET: /ResultEntry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ResultEntry resultentry = db.ResultEntries.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId", resultentry.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", resultentry.CourseId);
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", resultentry.GradeId);
            return View(resultentry);
        }

        //
        // POST: /ResultEntry/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResultEntry resultentry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId", resultentry.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", resultentry.CourseId);
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", resultentry.GradeId);
            return View(resultentry);
        }

        //
        // GET: /ResultEntry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ResultEntry resultentry = db.ResultEntries.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            return View(resultentry);
        }

        //
        // POST: /ResultEntry/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultEntry resultentry = db.ResultEntries.Find(id);
            db.ResultEntries.Remove(resultentry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public PartialViewResult CourseLoad(int? studentId)
        {
            List<EnrollCourse> enrollmentList = new List<EnrollCourse>();
            List<Course> courseList = new List<Course>();
            if (studentId != null)
            {
                enrollmentList = db.EnrollCourses.Where(e => e.StudentId == studentId).ToList();
                foreach (EnrollCourse anEnrollment in enrollmentList)
                {
                    Course aCourse = db.Courses.FirstOrDefault(c => c.CourseId == anEnrollment.CourseId);
                    courseList.Add(aCourse);
                }
                ViewBag.CourseId = new SelectList(courseList, "CourseId", "Code");
            }
            return PartialView("~/Views/shared/_FilteredCourse.cshtml");
        }

        public ActionResult ViewResult()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationId");
            return View();
        }

        public PartialViewResult ResultInfoLoad(int? studentId)
        {

            List<EnrollCourse> enrollCourseList = new List<EnrollCourse>();

            if (studentId != null)
            {
                enrollCourseList = db.EnrollCourses.Where(r => r.StudentId == studentId).ToList();

                if (enrollCourseList.Count == 0)
                {
                    Student aStudent = db.Students.Find(studentId);
                    ViewBag.NotEnrolled = aStudent.RegistrationId + "  : has not taken any course";
                }
            }

            return PartialView("~/Views/shared/_resultInformation.cshtml", enrollCourseList);
        }



        ////////////////////////////////
    }
}
