using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using NHibernateMVC.Models;

namespace NHibernateMVC.Controllers
{
    using System.Web.Mvc;

    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var employees = session.Query<Employee>().ToList();
                return View(employees);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emplolyee)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(emplolyee);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var employeetoUpdate = session.Get<Employee>(id);

                    employeetoUpdate.Designation = employee.Designation;
                    employeetoUpdate.FirstName = employee.FirstName;
                    employeetoUpdate.LastName = employee.LastName;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(employeetoUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(employee);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }
    }
}