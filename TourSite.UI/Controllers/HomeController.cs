using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.UI.Models;
namespace TourSite.UI.Controllers
{
    public class HomeController : Controller
    {
        Tablolar db = new Tablolar();
        public ActionResult Index()
        {
            ViewBag.anasayfa = db.sayfa.Where(kayit => kayit.link == "anasayfa").FirstOrDefault();

            return View(db.sayfaresimleri.Where(kayit => kayit.Sayfa.baslik == "slider").ToList());
        }
    }
}