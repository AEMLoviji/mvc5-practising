using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.Courses = db.Courses.ToList();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student newStudent, int[] selectedCourses)
        {
            var oldStudent = db.Students.Find(newStudent.Id);
            ChangeStudentProperties(oldStudent, newStudent, selectedCourses);

            db.Entry(oldStudent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void ChangeStudentProperties(Student oldStudent, Student newStudent, int[] selectedCourses)
        {
            oldStudent.Name = newStudent.Name;
            oldStudent.Surname = newStudent.Surname;

            oldStudent.Courses.Clear();
            if (selectedCourses != null)
            {
                var validCourses = db.Courses.Where(c => selectedCourses.Contains(c.Id));
                foreach (var c in validCourses)
                {
                    oldStudent.Courses.Add(c);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}