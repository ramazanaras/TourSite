using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.Models;
namespace TourSite.Controllers
{
    public class PartialController : Controller
    {
        Tablolar db = new Tablolar();
        public PartialViewResult ustmenu()
        {

            ViewBag.yeniyorumsayisi = db.turyorumlari.Where(kayit => kayit.onay == false).Count();

            ViewBag.yenirezsayisi = db.rezervasyon.Where(kayit => kayit.onay == false).Count();

            ViewBag.kullanici = Login.Login.aktifKul.adi + " " + Login.Login.aktifKul.soyadi;
            return PartialView("_ustmenu");
        }

    }
}