using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using more.Models;
using System.Data.Entity;

namespace more.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            dbcontext db = new dbcontext();
            Person person = db.Persons.Single(x => x.PersonID == id);
            return View(person);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            dbcontext db = new dbcontext();
            Person p = db.Persons.Single(x => x.PersonID == id);
            return View(p);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(Person p)
        {
            if (ModelState.IsValid)
            {
                dbcontext db = new dbcontext();
                Person pd = db.Persons.Single(x => x.PersonID == p.PersonID);
                pd.FirstName = p.FirstName;
                pd.LastName = p.LastName;
                pd.Address = p.Address;
                pd.City = p.City;
                db.Entry(pd).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details", new { id = p.PersonID });
            }
            return View(p);
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
