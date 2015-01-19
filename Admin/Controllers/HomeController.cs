using LYZJ.UserLimitMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class HomeController :BaseController
    {
        public ActionResult Index()
        {
            baseuser user = Session["UserInfo"] as baseuser;
            if (user != null)
            {
                ViewBag.UserName = user.RealName;
            }

            return View();
        }

    }
}
