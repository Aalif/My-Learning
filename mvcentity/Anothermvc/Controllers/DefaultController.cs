using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anothermvc.Models;
using System.Text;

namespace Anothermvc.Controllers
{
    public class DefaultController : Controller
    {

        // GET: Default
        public ActionResult Index()
        {
            learnEntities bd = new learnEntities();
            ViewBag.PersonDetail = new SelectList(bd.PersonDetails, "id", "name","15");
           
            return View();
        }
        [HttpGet]
        public ActionResult More()
        {
            typesmore t = new typesmore();
            return View(t);
        }
        [HttpPost]
        public string More(typesmore tp)
        {
            if (string.IsNullOrEmpty(tp.getdetails))
            {
                return "Yor are not selected anything";
            }
            else
            {
                return "Yor are selected anything" + tp.getdetails;
            }
        }
        [HttpGet]
        public ActionResult Check()
        {
            learnEntities t = new learnEntities();
            return View(t.PersonDetails);
        }
        public string Check(IEnumerable<PersonDetail> tp)
        {
            if (tp.Count(x => x.IsSelected) == 0)
            {
                return "You are not selected anything";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - ");
                foreach (PersonDetail p in tp)
                {
                    if (p.IsSelected)
                    {
                        sb.Append(p.name + ", ");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString();
            }
        }
    }

}