using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IConfiguration _configuration;
        private EmplyoeesCRUD db;
        public EmployeesController(IConfiguration configuration)
        {
            _configuration= configuration;  
            db=new EmplyoeesCRUD(configuration);
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            var list= db.GetEmployees();
            return View(list);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            var emp = db.GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employees employee)
        {
            try
            {
                int result = db.AddEmployee(employee);
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

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp=db.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employees employee)
        {
            try
            {
                int result = db.EditEmployee(employee);
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

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = db.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Deletefrom(int id )
        {
            try
            {
                int result = db.DeleteEmployee(id);
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
