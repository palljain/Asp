using log4net;
using System;
using System.Web.Mvc;

namespace EmployeeServices.Controllers
{
    public class loggingController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(loggingController));

        // GET: logging
        public ActionResult Index()
        {          
            log.Debug("Hi I am log4net Debug Level");
            log.Info("Hi I am log4net Info Level");
            log.Warn("Hi I am log4net Warn Level");
            return View();
        }        
    }
}