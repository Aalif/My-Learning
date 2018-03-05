using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anothermvc.Models;
using System.Text;

namespace Anothermvc.Controllers
{
    public class anotherController : Controller
    {
        // GET: another
        [HttpGet]
        public ActionResult Index()
        {
            learnEntities lr = new learnEntities();
            List<SelectListItem> ls = new List<SelectListItem>();
            foreach(PersonDetail p in lr.PersonDetails)
            {
                SelectListItem sl = new SelectListItem()
                {
                    Text = p.name,
                    Value = p.id.ToString(),
                    Selected = p.IsSelected
                };
                ls.Add(sl);
            }
            addmodelviews add = new addmodelviews();
            add.details = ls;
            return View(add);
        }
        [HttpPost]
        public string Index(IEnumerable<string> selectname)
        {
            if (selectname == null)
            {
                return "Select one";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - " + string.Join(",", selectname));
                return sb.ToString();
            }
        }
    }
}