using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Anothermvc.Models;

namespace Anothermvc.Controllers
{
    public class PersonDetailsController : Controller
    {
        private learnEntities db = new learnEntities();

        // GET: PersonDetails
        public ActionResult Index()
        {
            return View(db.PersonDetails.ToList());
        }

        // GET: PersonDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonDetail personDetail = db.PersonDetails.Find(id);
            if (personDetail == null)
            {
                return HttpNotFound();
            }
            return View(personDetail);
        }

        // GET: PersonDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "higesteducation,status,age,id,name")] PersonDetail personDetail)
        {
            if (ModelState.IsValid)
            {
                db.PersonDetails.Add(personDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personDetail);
        }

        // GET: PersonDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonDetail personDetail = db.PersonDetails.Find(id);
            if (personDetail == null)
            {
                return HttpNotFound();
            }
            return View(personDetail);
        }

        // POST: PersonDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "higesteducation,status,age,id,name")] PersonDetail personDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personDetail);
        }

        // GET: PersonDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonDetail personDetail = db.PersonDetails.Find(id);
            if (personDetail == null)
            {
                return HttpNotFound();
            }
            return View(personDetail);
        }

        // POST: PersonDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonDetail personDetail = db.PersonDetails.Find(id);
            db.PersonDetails.Remove(personDetail);
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
