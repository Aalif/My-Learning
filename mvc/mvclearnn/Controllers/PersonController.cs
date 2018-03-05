using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Businesslayer;
namespace mvclearnn.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            PersonLayer personLayer = new PersonLayer();
            List<PersonProperties> personproperties= personLayer.person_layer.ToList();
            return View(personproperties);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PersonProperties CpersonProperties)
        {
            if (ModelState.IsValid)
            {
                PersonLayer personlayer = new PersonLayer();
                personlayer.AddPerson(CpersonProperties);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Ediit 
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_get(int id)
        {

            PersonLayer cpersonlayer = new PersonLayer();
            PersonProperties cpersonproperties = cpersonlayer.person_layer.Single(p => p.ID == id); 
            return View(cpersonproperties);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(PersonProperties cPersonProperties)
        {
            if (ModelState.IsValid)
            {
                PersonLayer cpersonlayer = new PersonLayer();
                cpersonlayer.Editperson(cPersonProperties);
                return RedirectToAction("Index");
            }
            return View(cPersonProperties);

        }
        //delete 
        [HttpPost]
        public ActionResult Delete(int id)
        {
            PersonLayer cersonLayer = new PersonLayer();
            cersonLayer.Delete(id);
            return RedirectToAction("Index");
        }

    }
}