using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TourSite.Models;
using TourSite.Login;
namespace TourSite.Controllers
{
    /*
     NOT: [LoginFilter] kısıtlamasını sınıf tanımının (public class xxxController : Controller) başına yazarak, sınıftaki bütün metodlara kullanıcı girişi yapılarak ulaşılmasını sağlamış oluruz.
         */
    [LoginFilter]
    public class KullaniciController : Controller
    {


        Tablolar db = new Tablolar();
        public ActionResult Index()
        {
            return View(db.kullanici.ToList());
        }

        public ActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ekle(Kullanici kayit)
        {
            db.kullanici.Add(kayit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult sil(int id = 0)
        {
            Kullanici kayit = db.kullanici.Find(id);
            db.kullanici.Remove(kayit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult duzelt(int id = 0)
        {
            Kullanici kayit = db.kullanici.Find(id);
            return View(kayit);
        }


        [HttpPost]
        public ActionResult duzelt(Kullanici kayit)
        {
            db.Entry(kayit).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}