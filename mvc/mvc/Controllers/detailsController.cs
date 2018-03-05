using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class detailsController : Controller
    {
        // GET: details
        public ActionResult property()
        {
            details d = new Models.details();
            d.name = "Rahim";
            d.address = "Klaabagan";
            d.roll = 10;
            return View(d);
        }
    }
}