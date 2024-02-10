﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class TestimonialController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Testimonial
        public ActionResult TestimonialList()
        {
            var values = db.TblTestimonial.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial p)
        {
            p.Status = true;
            db.TblTestimonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)
        {
            var value = db.TblTestimonial.Find(p.TestimonialID);
            value.NameSurname = p.NameSurname;
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            value.Status = p.Status;
            db.SaveChanges();

            return RedirectToAction("TestimonialList");
        }

        public ActionResult StatusChangeTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}