using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvclearnn.Models;
using PagedList;
using PagedList.Mvc;
namespace mvclearnn.Controllers
{
    public class HomeController : Controller
    {
        private learnEntities db = new learnEntities();

        // GET: Home
        public ActionResult Index(string Searchby, string Search, int ? Page)
        {
            if(Searchby == "City")
            {
                return View(db.Myemployees.Where(x => x.City== Search || Search == null).ToList().ToPagedList( Page ?? 1,1));
            }
            else
            {
                return View(db.Myemployees.Where(x => x.Name.StartsWith(Search) || Search == null).ToList().ToPagedList(Page ?? 1,3));
            }
 
        }

        // GET: Home/Details/5
        public PartialViewResult Details(int? id)
        {
            if (id == null)
            {
               // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Myemployee myemployee = db.Myemployees.Find(id);
            if (myemployee == null)
            {
              //  return HttpNotFound();
            }
            return PartialView("~/Shared/_My", myemployee);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,City,Photo,AlternateText")] Myemployee myemployee)
        {
            if (ModelState.IsValid)
            {
                db.Myemployees.Add(myemployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myemployee);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Myemployee myemployee = db.Myemployees.Find(id);
            if (myemployee == null)
            {
                return HttpNotFound();
            }
            return View(myemployee);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,City,Photo,AlternateText")] Myemployee myemployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myemployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myemployee);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Myemployee myemployee = db.Myemployees.Find(id);
            if (myemployee == null)
            {
                return HttpNotFound();
            }
            return View(myemployee);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Myemployee myemployee = db.Myemployees.Find(id);
            db.Myemployees.Remove(myemployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
