using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.UserLimitMVC.IBLL;
using LYZJ.UserLimitMVC.BLL;
using LYZJ.UserLimitMVC.Common;
using LYZJ.UserLimitMVC.Model;

namespace Admin.Controllers
{
    public class FinanceProductController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(financeproduct model)
        {
            model.CeateOn = DateTime.Now;
            if (_financeproductService.AddEntity(model) != null)
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
        public ActionResult Edit(financeproduct model)
        {
            var Entitiy = _financeproductService.LoadEntities(m => m.ID == model.ID).FirstOrDefault();
            Entitiy.AnnualEarnings = model.AnnualEarnings;
            Entitiy.Case = model.Case;
            Entitiy.MinMoney = model.MinMoney;
            Entitiy.ModeFeature = model.ModeFeature;
            Entitiy.Name = model.Name;
            Entitiy.SimpleDesc = model.SimpleDesc;
            Entitiy.SuitCrowd = model.SuitCrowd;

            if (_financeproductService.UpdateEntity() > 0)
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

            var Entitiy = _financeproductService.LoadEntities(m => m.ID == ID).FirstOrDefault();
            if (_financeproductService.DeleteEntity(Entitiy))
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
            var data = _financeproductService.LoadEntities(m => m.ID != 0);
            var result = new { total = data.Count(), rows = data };
            return Content(JsonHelper.ToJson(result));
        }
        public ActionResult Details(int? ID = 0)
        {
            var Entitiy = _financeproductService.LoadEntities(m => m.ID == ID).FirstOrDefault();
            return Content(JsonHelper.ToJson(Entitiy)); ;
        }
    }
}
