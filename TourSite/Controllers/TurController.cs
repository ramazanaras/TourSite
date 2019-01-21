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
    public class TurController : Controller
    {


        Tablolar db = new Tablolar();
        public ActionResult Index()
        {
            return View(db.tur.ToList());
        }

        public ActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ekle(Tur kayit)
        {
            db.tur.Add(kayit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult sil(int id = 0)
        {
            Tur kayit = db.tur.Find(id);
            db.tur.Remove(kayit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult duzelt(int id = 0)
        {
            Tur kayit = db.tur.Find(id);
            return View(kayit);
        }


        [HttpPost]
        public ActionResult duzelt(Tur kayit)
        {
            db.Entry(kayit).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult resimler(int turid = 0)
        {
            return View(db.turresimleri.Where(kayit => kayit.tur_id == turid).ToList());
        }


        public ActionResult resimekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult resimekle(HttpPostedFileBase resimadi, int turid)
        {
            if (resimadi.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/images"), Guid.NewGuid().ToString() + "_" + Path.GetFileName(resimadi.FileName));
                resimadi.SaveAs(filePath);
                TurResimleri tr = new TurResimleri();

                tr.tur_id = turid;
                tr.resimadi = Path.GetFileName(filePath);
                db.turresimleri.Add(tr);
                db.SaveChanges();
            }
            return View();
        }


        public ActionResult resimsil(int[] resim_id)
        {
            foreach (int resimID in resim_id)
            {
                //resimler TurResimleris tablosundan silinir 
                TurResimleri kayit = db.turresimleri.Find(resimID);
                db.turresimleri.Remove(kayit);

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