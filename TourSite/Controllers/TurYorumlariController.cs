using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.Login;
using TourSite.Models;
using PagedList;
using PagedList.Mvc;

namespace TourSite.Controllers
{
    [LoginFilter]
    public class TurYorumlariController : Controller
    {
        // 
        // GET: /TurYorumlari/ 
        Tablolar db = new Tablolar();
        public ActionResult Index(int sayfa = 1)
        {
            //NOT: ToPagedList ifadesindeki ikinci parametre (örneğimizde 2), bir sayfada kaç kayıt listeleneceğini belirtir.
            return View(db.turyorumlari.OrderByDescending(x => x.tarih).ThenBy(x => x.id).ToPagedList(sayfa, 2));
        }


        public ActionResult sil(int yorum_ID = 0)
        {
            TurYorumlari kayit = db.turyorumlari.Find(yorum_ID);
            db.turyorumlari.Remove(kayit);
            db.SaveChanges();
            return Json("Yorum başarıyla silindi!");
        }
        public ActionResult onay(int yorum_ID, bool durum)
        {
            TurYorumlari kayit = db.turyorumlari.Find(yorum_ID);
            kayit.onay = durum;
            db.SaveChanges();
            string mesaj;
            if (durum) mesaj = "Yorum onaylandı!";
            else mesaj = "Yorum onayı kaldırıldı!";
            return Json(mesaj);
        }

        [HttpGet]
        public JsonResult yorumoku(int yorum_ID)
        {
            TurYorumlari kayit = db.turyorumlari.Find(yorum_ID);
            if (kayit == null)
            {
                return null;
            }
            else
            {
                var data = new
                {
                    y_adsoyad = kayit.adsoyad,
                    y_eposta = kayit.eposta,
                    y_tarih = kayit.tarih.ToString("yyyy-MM-dd"),
                    y_yorum = kayit.yorum,
                    y_onay = kayit.onay,
                    y_turadi = kayit.Tur.turadi
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        

        public ActionResult duzelt(TurYorumlari ty)
        {
            TurYorumlari kayit = db.turyorumlari.Find(ty.id);
            kayit.adsoyad = ty.adsoyad;
            kayit.eposta = ty.eposta;
            kayit.tarih = ty.tarih;
            kayit.yorum = ty.yorum;
            kayit.onay = ty.onay;
            db.SaveChanges();
            return Json("Yorum başarıyla güncellendi!");
        }

    }
}