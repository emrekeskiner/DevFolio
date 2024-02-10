using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult AboutList()
        {
            ViewBag.aboutCount = db.TblAbout.Count();
            var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            var countAbout = db.TblAbout.Count();
            if (countAbout > 0)
            {
                ViewBag.countAbout = countAbout;

            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(TblAbout p)
        {
            var countAbout = db.TblAbout.Count();
            if (countAbout > 0)
            {
                return RedirectToAction("AboutList");
            }
            else
            {
                db.TblAbout.Add(p);
                db.SaveChanges();
            }


           
            return RedirectToAction("AboutList");
        }

        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            db.TblAbout.Remove(values);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbout.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            var values = db.TblAbout.Find(p.AboutID);
            values.Description= p.Description;
            db.SaveChanges();

            return RedirectToAction("AboutList");
        }
    }
}
