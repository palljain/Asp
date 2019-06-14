using System;
using System.Linq;
using EmployeesData;
using System.Web.Mvc;
using System.Collections.Generic; 

namespace EmployeeServices.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View();  
        }
        public ActionResult Getdata()
        {
            EmployeeDBEntities2 entities = new EmployeeDBEntities2();
            List<Employee> employee = entities.Employees.ToList();
            return Json(employee, JsonRequestBehavior.AllowGet);           
        }

        [HttpGet]
        public ActionResult FormData()
        {            
            return View();
        } 
        
        [HttpPost]     
        public ActionResult FormData(Employee employee)
        {            
            EmployeeDBEntities2 entities = new EmployeeDBEntities2();

            if (ModelState.IsValid)
            {
                entities.Employees.Add(employee);
                entities.SaveChanges();
              //  ViewBag.ItemData = entities.Employees.ToList();
                return RedirectToAction("Index");
            }
            return View("FormData");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeDBEntities2 entities = new EmployeeDBEntities2();
            Employee employee = entities.Employees.Single(x => x.ID == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            EmployeeDBEntities2 entities = new EmployeeDBEntities2();
            Employee Data = entities.Employees.Single(x => x.ID == id);
            if (ModelState.IsValid)
            {
                UpdateModel(Data);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            EmployeeDBEntities2 entities = new EmployeeDBEntities2();
            Employee employee = entities.Employees.Single(x => x.ID == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id, string Firstname)
        {
            EmployeeDBEntities2 entities = new EmployeeDBEntities2();
            Employee employee = entities.Employees.Single(x => x.ID == id);
            entities.Employees.Remove(employee);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
