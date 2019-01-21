using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TourSite.Models;
using System.IO;
namespace TourSite.Controllers
{
    public class SayfaController : Controller
    {


        Tablolar db = new Tablolar();
        public ActionResult Index()
        {
            return View(db.sayfa.ToList());
        }

        public ActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ekle(Sayfa kayit)
        {
            db.sayfa.Add(kayit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult sil(int id = 0)
        {
            Sayfa kayit = db.sayfa.Find(id);
            db.sayfa.Remove(kayit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult duzelt(int id = 0)
        {
            Sayfa kayit = db.sayfa.Find(id);
            return View(kayit);
        }


        [HttpPost]
        public ActionResult duzelt(Sayfa kayit)
        {
            db.Entry(kayit).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult resimler(int sayfaid = 0)
        {
            return View(db.sayfaresimleri.Where(kayit => kayit.sayfa_id == sayfaid).ToList());
        }

        public ActionResult resimekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult resimekle(HttpPostedFileBase resimadi, int sayfaid)
        {
            if (resimadi.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/images"), Guid.NewGuid().ToString() + "_" + Path.GetFileName(resimadi.FileName));
                resimadi.SaveAs(filePath);
                SayfaResimleri sr = new SayfaResimleri();

                sr.sayfa_id = sayfaid;
                sr.resimadi = Path.GetFileName(filePath);
                db.sayfaresimleri.Add(sr);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult resimsil(int[] resim_id)
        {
            foreach (int resimID in resim_id)
            {
                //resimler SayfaResimleris tablosundan silinir 
                SayfaResimleri kayit = db.sayfaresimleri.Find(resimID);
                db.sayfaresimleri.Remove(kayit);

                //resimler images klasöründen silinir 
                string fullPath = Request.MapPath("~/Content/images/" + kayit.resimadi);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            db.SaveChanges();
            return Json("Seçili resimler silindi!");
        }




    }
}