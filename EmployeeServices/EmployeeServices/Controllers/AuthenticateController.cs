using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesData;

namespace EmployeeServices.Controllers
{
    public class AuthenticateController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

    public ActionResult CheckData()
        {
            EmployeeDBEntities2 entities = new EmployeeDBEntities2();
            var employee = new Employee();
            var username = Request.Form["Username"];
            var password = Request.Form["Password"];

            var searchData = entities.Employees.Where(x => x.Firstname == username && x.Passwd == password ).SingleOrDefault();
        
            if (searchData != null)
            {
                return RedirectToAction("Index", "Employee" );
            }
            else
            {
                ViewBag.Title = "Invalid User";
            }
                return View();
            
        }
    }
}