using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult ProjectList()
        {
            return View();
        }

        public ActionResult CreateProject()
        {
            return View();
        }
    }
}