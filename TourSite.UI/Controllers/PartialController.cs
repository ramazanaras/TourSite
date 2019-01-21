using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.UI.Models;
namespace TourSite.UI.Controllers
{
    public class PartialController : Controller
    {
        Tablolar db = new Tablolar();
        public PartialViewResult menu()
        {
            return PartialView("menu", db.sayfa.Where(kayit => kayit.konum == konum_bilgisi.Ust && kayit.onay == true).ToList());
        }

        public PartialViewResult solmenu()
        {
            return PartialView("solmenu", db.sayfa.Where(kayit => kayit.konum == konum_bilgisi.Sol && kayit.onay == true).ToList());
        }

        public PartialViewResult altmenu()
        {
            return PartialView("altmenu", db.sayfa.Where(kayit => kayit.konum == konum_bilgisi.Alt && kayit.onay == true).ToList());
        }

    }
}