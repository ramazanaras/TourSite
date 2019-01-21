using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.UI.Models;
using PagedList;
using PagedList.Mvc;
namespace TourSite.UI.Controllers
{
    public class TurController : Controller
    {
        Tablolar db = new Tablolar();
        public ActionResult Index(int sayfa = 1)
        {
            return View(db.tur.Where(kayit => kayit.onay == true).OrderByDescending(kayit => kayit.id).ToPagedList(sayfa, 2));
        }




        public ActionResult detay(int turId)
        {
            return View(db.tur.Where(kayit => kayit.id == turId).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult yeniyorum(TurYorumlari kayit)
        {
            kayit.onay = false;
            kayit.tarih = DateTime.Now;
            db.turyorumlari.Add(kayit);
            db.SaveChanges();
            return RedirectToAction("detay", new { turId = kayit.tur_id });

            /*
             detay.cshtml görünüm sayfasında doğrulama (validation) kodlarının çalışması için _Layout.cshtml sayfasında jquery.validate.js ve jquery.validate.unobtrusive.min.js dosyalarına referans oluşturmalıyız.
             */
        }



        [HttpPost]
        public ActionResult yenirezervasyon(Rezervasyon kayit)
        {
            kayit.onay = false;
            kayit.reztarihi = DateTime.Now;
            db.rezervasyon.Add(kayit);
            db.SaveChanges();
            return RedirectToAction("detay", new { turId = kayit.tur_id });
        }
        public JsonResult sonyorumlar()
        {
            var yorumlar = db.turyorumlari.Select(x => new
            {
                turadi = x.Tur.turadi,
                adsoyad = x.adsoyad,
                yorum = x.yorum,
                onay = x.onay,
                tarih = x.tarih
            }).Where(x => x.onay == true).OrderByDescending(x => x.tarih).Take(2).ToList();
            return Json(yorumlar, JsonRequestBehavior.AllowGet);
        }

    }
}



/*
 NOT: ToPagedList ifadesindeki ikinci parametre (örneğimizde 2), bir sayfada kaç kayıt listeleneceğini belirtir. 
Ardından sayfa sayfa listeleme yapacağımız View sayfası açılır. Bunun için TurController.cs sınıfında iken Index() metodu sağ tıklanır ve açılan menüden Go To View seçeneği tıklanır. PagedList.Mvc ve PagedList paket kütüphaneleri Index.cshtml sayfasına eklenir. Kodların en üstüne aşağıdaki tanımlar yazılır.
@using PagedList @using PagedList.Mvc
@model IEnumerable<MVC2.Models.Tur> şeklindeki model tanımı da @model IPagedList<MVC2.Models.Tur> şeklinde değiştirilir.

Liste sonunda kayıtlarımızın sayfa numaralandırmasını gösterecek ve ilgili sayfa tıklandığında, o sayfanın kayıtlarını listelemek için, TurController’ındaki Index() metodunu tetikleyecek kodları @foreach döngü bloğundan sonra yazalım.
     
    <div class="pagedList">
    @Html.PagedListPager(Model, sayfa => Url.Action("index", new { sayfa }), PagedListRenderOptions.PageNumbersOnly)
</div>


     */
