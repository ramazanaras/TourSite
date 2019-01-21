using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite.Models;
using TourSite.Login;
namespace TourSite.Controllers
{
    public class HomeController : Controller
    {
        /*
         [LoginFilter] kısıtlamamızı HomeController sınıfının Index() metodunun başına yazmamızdaki neden, projemizde çalışacak ilk metodun buradaki Index() metodu olmasıdır. Bu filtre sayesinde kullanıcı giriş yetkisi olmayan kişiler login (login.cshtml) sayfasına yönlendirilecektır.
 Bundan sonra HomeController hariç her bir Controller sınıfımızın başına, aşağıda görüldüğü gibi, [LoginFilter] kısıtlamamızı yazalım ve projemizi derleyip çalışmasını test edelim.
              */
        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(Kullanici kul)
        {
            Tablolar db = new Tablolar();
            //İlk Login klasörün, ikinci Login sınıfın adıdır 79 

            Login.Login.aktifKul = db.kullanici.FirstOrDefault(x => x.kadi == kul.kadi && x.sifre == kul.sifre);

            if (Login.Login.aktifVarmi)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Bulunamadı.";
                return View();
            }
        }
        public ActionResult logout()
        {
            Login.Login.cikisYap();
            return RedirectToAction("login", "Home");
        }



    }
}