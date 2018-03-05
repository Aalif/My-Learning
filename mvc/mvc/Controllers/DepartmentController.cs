using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            personContext p = new personContext();
            List<Department> d = p.entitydepartment.ToList();
            return View(d);
        }
    }
}