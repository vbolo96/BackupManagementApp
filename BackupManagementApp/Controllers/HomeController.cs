using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackupManagementApp.Controllers
{
     [AllowAnonymous]   
    public class HomeController : Controller
    {
        //using caching for these pages because they are showing only information, not updatable data
        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult About()
        {
            ViewBag.Message = "Application Description";

            return View();
        }
        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
    }
}