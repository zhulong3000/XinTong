using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.UserLimitMVC.Common;

namespace Front.Controllers
{
    public class FinanceProductController : BaseController
    {
        public ActionResult GetList()
        {
            //根据条件查询结果
            var data = _financeproductService.LoadEntities(m => m.ID != 0);
            var result = new { total = data.Count(), rows = data };
            return Content(JsonHelper.ToJson(result));
        }
        public ActionResult Details_data(int? ID = 0)
        {
            var Entitiy = _financeproductService.LoadEntities(m => m.ID == ID).FirstOrDefault();
            return Content(JsonHelper.ToJson(Entitiy));
        }

        public ActionResult Details(int? ID = 0)
        {
            ViewBag.data =_financeproductService.LoadEntities(m => m.ID == ID).FirstOrDefault(); ;
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        //
        // GET: /FinanceProduct/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FinanceProduct/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FinanceProduct/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /FinanceProduct/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FinanceProduct/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /FinanceProduct/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
