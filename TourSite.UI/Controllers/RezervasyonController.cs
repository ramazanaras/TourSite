using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.UI.Models;
namespace TourSite.UI.Controllers
{
    public class RezervasyonController : Controller
    {
        Tablolar db = new Tablolar();
        [HttpPost]
        public ActionResult detay(Rezervasyon kayit)
        {
            Rezervasyon sonuc = db.rezervasyon.Where(x => x.eposta == kayit.eposta && x.reztarihi == kayit.reztarihi).FirstOrDefault();
            if (sonuc != null)
                return View(sonuc);
            else
                return RedirectToAction("index", "home");
        }

    }
}