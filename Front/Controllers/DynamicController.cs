using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
    public class DynamicController : Controller
    {
        //
        // GET: /Dynamic/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }

    }
}
