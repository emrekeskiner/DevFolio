using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProfileController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult ProfileList()
        {
            var value = db.TblProfile.ToList();
            ViewBag.profileCount = db.TblProfile.Count();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            var countProfile = db.TblProfile.Count();
            if (countProfile > 0)
            {
                ViewBag.countProfile = countProfile;
               
            }
         
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(TblProfile p)
        {
            var countProfile = db.TblProfile.Count();
            if(countProfile > 0)
            {
               return RedirectToAction("ProfileList");
            }
            else
            {
                db.TblProfile.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("ProfileList");

        }

        public ActionResult DeleteProfile(int id)
        {
            var values = db.TblProfile.Find(id);
            db.TblProfile.Remove(values);
            db.SaveChanges();

            return RedirectToAction("ProfileList");
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var values = db.TblProfile.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProfile(TblProfile p)
        {
            var values = db.TblProfile.Find(p.ProfileId);
            values.NameSurname = p.NameSurname;
            values.Title = p.Title;
            values.Email = p.Email;
            values.Phone = p.Phone;
            db.SaveChanges();

            return RedirectToAction("ProfileList");
        }
    }
}