using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.UserLimitMVC.Common;

namespace Front.Controllers
{
    public class BorrowingProductController : BaseController
    {
        public ActionResult List(){
          // 获取 列表的数据并返回视图
          ViewBag.BorrowList_data=_borrowingproductService.LoadEntities(m => m.ID != 0);
          return View();
        }
        public ActionResult GetList()
        {
            //根据条件查询结果
            var data = _borrowingproductService.LoadEntities(m => m.ID != 0);
            var result = new { total = data.Count(), rows = data };
            return Content(JsonHelper.ToJson(result));
        }
        public ActionResult Details(int? ID = 0)
        {
            ViewBag.data = _borrowingproductService.LoadEntities(m => m.ID == ID).FirstOrDefault();
            return View();
        }

        //
        // GET: /BorrowingProduct/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BorrowingProduct/Create

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
        // GET: /BorrowingProduct/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BorrowingProduct/Edit/5

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
        // GET: /BorrowingProduct/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BorrowingProduct/Delete/5

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
