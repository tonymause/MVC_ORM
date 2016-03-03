using System;
using System.Web.Mvc;
using EntityFrameworkMVC.Models;

namespace EntityFrameworkMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _repo;

        public EmployeeController()
        {
            _repo = new EmployeeRepository(new LocalDatabaseEntities());
        }

        public ActionResult Index()
        {
            var employees = _repo.All();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _repo.Add(employee);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var employee = _repo.Get(id);
                return View(employee);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var employee = _repo.Get(id);
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var employee = _repo.Get(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }
    }
}