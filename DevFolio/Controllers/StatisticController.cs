using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult StatisticList()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = ((int?)db.TblSkill.Average(x=> x.SkillValue));
            ViewBag.lastSkillTitleName = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();


            return View();
        }
    }
}