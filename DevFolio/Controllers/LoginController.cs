using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(TblAdmin p)
        {
            var admin = db.TblAdmin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
                
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["adminUserName"] = admin.UserName.ToString();
                return RedirectToAction("ProfileList", "Profile");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}