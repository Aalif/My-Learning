using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index(int did)
        {
            personContext personContext = new personContext();
            List<person> p = personContext.entityperson.Where(x=> x.DepartmentId == did).ToList();

            return View(p);

        }
        public ActionResult persondetails(int id)
        {
            personContext pContext = new personContext();
            person p = pContext.entityperson.Single( x=> x.EmployeeId == id);

            return View(p);
        }
    }
}