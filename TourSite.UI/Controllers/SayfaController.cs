using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.UI.Models;
namespace TourSite.UI.Controllers
{
    public class SayfaController : Controller
    {
        Tablolar db = new Tablolar();
        public ActionResult goster(string sayfa)
        {
            return View(db.sayfa.Where(kayit => kayit.link == sayfa && kayit.onay == true).FirstOrDefault());
        }
    }
}