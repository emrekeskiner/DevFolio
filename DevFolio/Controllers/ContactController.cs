using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        // GET: Contact

        public ActionResult MessageList()
        {
            var values = db.TblContact.ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult ReadMessage(int id)
        {
            var values = db.TblContact.Find(id);
            values.IsRead = true;
            db.SaveChanges();
            return View(values);
        }

        public ActionResult SendMessage()
        {
            return View();
        }

       
    }
}