using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvclearn2.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}