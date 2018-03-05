using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvclearn2.Areas.employeer
{
    public class HomeController : Controller
    {
        // GET: employeer/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}