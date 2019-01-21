using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TourSite.Login
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Login.aktifVarmi)
            {
                //kullanıcı giriş yapmamışsa HomeController’ın içindeki login() metoduna(action) yönlendirme yapar.

                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary { { "Controller", "Home" }, { "Action", "login" } });
            }

        }
    }
}