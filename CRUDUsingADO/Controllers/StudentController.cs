using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private StudentCRUD db;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
            db = new StudentCRUD(_configuration);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var list = db.GetStudent();
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int rollno)
        {
            var stud = db.GetStudentByRollNo(rollno);
            return View(stud);
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
                int result = db.AddStudent(student);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int rollno)
        {
            var stud = db.GetStudentByRollNo(rollno);
            return View(stud);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int result=db.EditStudent(student);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int rollno)
        {
            var stud = db.GetStudentByRollNo(rollno);
            return View(stud);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Deletefrom(int rollno)
        {
            try
            {
               int result=db.DeleteStudent(rollno);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
