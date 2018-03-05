using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvclearn2.Controllers
{
    public class HomeController : Controller
    {
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            throw new Exception("Error");
        }
        [ChildActionOnly]
        public ActionResult List(List<string> name)
        {
            return View(name);
        }
    }
}