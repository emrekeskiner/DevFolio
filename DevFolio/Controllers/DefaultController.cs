using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    
    public class DefaultController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {

            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {

            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.OrderBy(x=>x.SkillTitle).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAddress()
        {
            var values = db.TblAddress.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSocialMedia()
        {
            var values = db.TblSocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
    }
}