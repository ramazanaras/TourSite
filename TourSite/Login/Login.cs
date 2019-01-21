using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourSite.Models;
namespace TourSite.Login
{
    public class Login
    {
        public static bool aktifVarmi
        {
            get { return aktifKul != null; }
        }
        public static Kullanici aktifKul
        {
            get
            {
                return (Kullanici)System.Web.HttpContext.Current.Session["login"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["login"] = value;
            }
        }
        public static void cikisYap()
        {
            aktifKul = null;
            System.Web.HttpContext.Current.Session.Abandon();
        }
    }

}