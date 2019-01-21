using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.Login;
using TourSite.Models;


namespace TourSite.Controllers
{
    [LoginFilter]
    public class RezervasyonController : Controller
    {
        Tablolar db = new Tablolar();
        public ActionResult Index()
        {
            return View(db.rezervasyon.ToList());
        }

        public ActionResult sil(int rez_ID = 0)
        {
            Rezervasyon kayit = db.rezervasyon.Find(rez_ID);
            db.rezervasyon.Remove(kayit);
            db.SaveChanges();
            return Json("Rezervasyon başarıyla silindi!");
        }

        public ActionResult onay(int rez_ID, bool durum)
        {
            Rezervasyon kayit = db.rezervasyon.Find(rez_ID);
            kayit.onay = durum;
            db.SaveChanges();
            string mesaj;
            if (durum) mesaj = "Rezervasyon onaylandı!";
            else mesaj = "Rezervasyon onayı kaldırıldı!";
            return Json(mesaj);
        }
        [HttpGet]
        public JsonResult rezervasyonoku(int rez_ID)
        {
            Rezervasyon kayit = db.rezervasyon.Find(rez_ID);
            if (kayit == null)
            {


                return null;
            }
            else
            {
                var data = new
                {
                    r_adi = kayit.ad,
                    r_soyadi = kayit.soyad,
                    r_eposta = kayit.eposta,
                    r_telefon = kayit.telefon,
                    r_turtarihi = kayit.turtarihi.ToString("yyyy-MM-dd"),
                    r_reztarihi = kayit.reztarihi.ToString("yyyy-MM-dd"),
                    r_aciklama = kayit.aciklama,
                    r_onay = kayit.onay,
                    r_turadi = kayit.Tur.turadi
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult duzelt(Rezervasyon ty)
        {
            Rezervasyon kayit = db.rezervasyon.Find(ty.id);
            kayit.ad = ty.ad;
            kayit.soyad = ty.soyad;
            kayit.eposta = ty.eposta;
            kayit.telefon = ty.telefon;
            kayit.turtarihi = ty.turtarihi;
            kayit.reztarihi = ty.reztarihi;
            kayit.aciklama = ty.aciklama;
            kayit.onay = ty.onay;
            db.SaveChanges();
            return Json("Rezervasyon başarıyla güncellendi!");
        }


        [HttpPost]
        public ActionResult Index(string aranan = null)
        {
            var t = from x in db.rezervasyon
                    select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.rezervasyon.Where(kayit => kayit.ad.Contains(aranan)
                || kayit.soyad.Contains(aranan)
                || kayit.Tur.turadi.Contains(aranan));
            }
            return View(t.OrderByDescending(kayit => kayit.id).ToList());
        }









    }
}