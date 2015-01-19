using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.UserLimitMVC.IBLL;
using LYZJ.UserLimitMVC.Common.select;
using LYZJ.UserLimitMVC.BLL;
using LYZJ.UserLimitMVC.Common;
using LYZJ.UserLimitMVC.Model;

namespace Admin.Controllers
{
    public class BorrowingProductController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(borrowingproduct model)
        {
            model.CreateOn = DateTime.Now;
            if (_borrowingproductService.AddEntity(model) != null)
            {
                result.status = true;
                result.message = "新增成功!";
            }
            else
            {
                result.status = true;
                result.message = "新增失败!";
            }
            return Content(JsonHelper.ToJson(result));
        }
        [HttpPost]
        public ActionResult Edit(borrowingproduct model)
        {
            var Entitiy = _borrowingproductService.LoadEntities(m => m.ID == model.ID).FirstOrDefault();
            Entitiy.ModeFeature = model.ModeFeature;
            Entitiy.Name = model.Name;
            Entitiy.OfferData = model.OfferData;
            Entitiy.SimpleDesc = model.SimpleDesc;
            Entitiy.SuitCrowd = model.SuitCrowd;
            Entitiy.ApplyProcess = model.ApplyProcess;
            Entitiy.CreditLine = model.CreditLine;
            if (_borrowingproductService.UpdateEntity() > 0)
            {
                result.status = true;
                result.message = "编辑成功!";
            }
            else
            {
                result.status = false;
                result.message = "编辑失败!";
            }
            return Content(JsonHelper.ToJson(result));
        }
        [HttpPost]
        public ActionResult Delete(int? ID = 0)
        {

            var Entitiy = _borrowingproductService.LoadEntities(m => m.ID == ID).FirstOrDefault();
            if (_borrowingproductService.DeleteEntity(Entitiy))
            {
                result.status = true;
                result.message = "删除成功!";
            }
            else
            {
                result.status = false;
                result.message = "删除失败!";
            }
            return Content(JsonHelper.ToJson(result));
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
            var Entitiy = _borrowingproductService.LoadEntities(m => m.ID == ID).FirstOrDefault();
            return Content(JsonHelper.ToJson(Entitiy)); ;
        }
    }
}
