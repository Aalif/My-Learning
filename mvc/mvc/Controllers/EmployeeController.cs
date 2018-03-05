using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Businessobject;

namespace mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            bussinesslayer b = new bussinesslayer();
            List <employee> e = b.bemployee.ToList();
            return View(e);
        }
        //create
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(employee em)
        {
            if (ModelState.IsValid)
            {
                bussinesslayer bemp = new bussinesslayer();
                bemp.addemployee(em);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        //edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            bussinesslayer b = new bussinesslayer();
            employee em = b.bemployee.Single( x => x.ID == id );
            return View(em);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(int id)
        {
            bussinesslayer b = new bussinesslayer();
            employee em = b.bemployee.Single(x => x.ID == id);
            UpdateModel(em, new string[] {"Gender", "City" });
            if (ModelState.IsValid)
            {
                b.updateemployee(em);
                return RedirectToAction("Index");
            }
            return View(em);

        }
        //delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bussinesslayer b = new bussinesslayer();
            b.deleteemploye(id);
            return RedirectToAction("Index");
        }
    }
}