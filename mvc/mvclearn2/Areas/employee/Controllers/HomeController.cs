using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvclearn2.Areas.employee.Controllers
{
    public class HomeController : Controller
    {
        // GET: employee/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}