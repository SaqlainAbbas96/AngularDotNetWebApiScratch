using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities1 db = new EmployeeDBEntities1();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult AddComments()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddComments(Facebook fb)
        {
            if (ModelState.IsValid)
            {
                db.Facebooks.Add(fb);
                db.SaveChanges();
                return RedirectToAction("AddComments");
            }
            return View(fb);
        }

       
    }
}
