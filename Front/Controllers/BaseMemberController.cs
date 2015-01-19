using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.UserLimitMVC.Common;

namespace Admin.Controllers
{
    public class BaseMemberController : Controller
    {
        Result result = new Result();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //用户登陆功能
        public ActionResult Login(string username, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    if (username == "tanyun" && password == "tanyun")
                    {
                        Session["userName"] = username;
                        result.status = "true";
                        result.message = "登陆成功！";
                    }
                    else
                    {
                        result.status = "false";
                        result.message = "用户名或密码错误！";
                    }

                }
                return Content(JsonHelper.ToJson(result));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Register()
        {



            return View();
        }
        [HttpPost]
        //用户注册功能
        public ActionResult Register(FormCollection collection)
        {
            if (Session["mobileCode"] != null && !string.IsNullOrEmpty(Session["mobileCode"].ToString()))
            {
                if (string.IsNullOrEmpty(collection["vitationCode"].ToString())
                   || collection["vitationCode"].ToString() != Session["mobileCode"].ToString())
                {
                    result.status = "false";
                    result.message = "手机验证码填写不正确或为空！";
                    return Content(JsonHelper.ToJson(result));
                }
                if (string.IsNullOrEmpty(collection["username"].ToString()))
                {
                    result.status = "false";
                    result.message = "用户名不能为空！";
                    return Content(JsonHelper.ToJson(result));
                }
                if (string.IsNullOrEmpty(collection["password"].ToString()) || collection["password"].ToString().Length < 6)
                {
                    result.status = "false";
                    result.message = "密码不能为空或长度少于6位！";
                    return Content(JsonHelper.ToJson(result));
                }
                if (string.IsNullOrEmpty(collection["phone"].ToString()) || collection["password"].ToString().Length != 11)
                {
                    result.status = "false";
                    result.message = "手机号码不能为空或格式不正确！";
                    return Content(JsonHelper.ToJson(result));
                }
                if (string.IsNullOrEmpty(collection["type"].ToString()))
                {
                    //注册用户类型（CREDITOR为出借人，DEBTOR为借款人）
                    result.status = "false";
                    result.message = "用户类型不能为空或格式不正确！";
                    return Content(JsonHelper.ToJson(result));
                }
                //  collection["invitationCode"]
                result.status = "true";
                result.message = "恭喜您，注册成功！";
                return Content(JsonHelper.ToJson(result));
            }
            result.status = "false";
            result.message = "手机验证码不正确或为空";
            return Content(JsonHelper.ToJson(result));
        }
        //获取用户账户信息
        public ActionResult getAccount()
        {
            string userName = IsLogin();
            return View();
        }
        //获取手机验证码
        public ActionResult GetPhoneCode()
        {
            KenceryValidateCode code = new KenceryValidateCode();
            Session["mobileCode"] = code.CreateValidateCode(6);
            return Content(Session["mobileCode"].ToString());
        }
        //判断用户是否存在
        public string IsLogin()
        {

            if (Session["userName"] == null && string.IsNullOrEmpty(Session["userName"].ToString()))
            {
                RedirectToAction("Login");

            }
            return Session["userName"].ToString();
        }

    }
}
