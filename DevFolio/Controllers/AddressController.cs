using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult AddressList()
        {
            var value = db.TblAddress.ToList();
            ViewBag.addressCount = db.TblAddress.Count();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateAddress()
        {
            var countAddress = db.TblAddress.Count();
            if (countAddress > 0)
            {
                ViewBag.countAddress = countAddress;

            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(TblAddress p)
        {
            var countAddress = db.TblAddress.Count();
            if (countAddress > 0)
            {
                return RedirectToAction("AddressList");
            }
            else
            {
                db.TblAddress.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("AddressList");

        }

        public ActionResult DeleteAddress(int id)
        {
            var values = db.TblAddress.Find(id);
            db.TblAddress.Remove(values);
            db.SaveChanges();

            return RedirectToAction("AddressList");
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = db.TblAddress.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAddress(TblAddress p)
        {
            var values = db.TblAddress.Find(p.AddressID);
            values.Description = p.Description;
            values.Location = p.Location;
            values.Email = p.Email;
            values.PhoneNumber = p.PhoneNumber;
            db.SaveChanges();

            return RedirectToAction("AddressList");
        }
    }
}