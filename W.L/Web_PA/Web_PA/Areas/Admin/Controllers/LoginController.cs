using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_PA.Areas.Admin.Models;
using Web_PA.Common;
using Web_PA.DAO;

namespace Web_PA.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult logoutAdmin()
        {
            //Session[Common.CommonSession.USER_SESSION] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        [HttpPost]
        
        public ActionResult Index(LoginModel model)
        {
            if (Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            //if (ModelState.IsValid)
            //{
            //    var dao = new UserDAO();
            //    var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
            //    if (result == 1)
            //    {
            //        var user = dao.GetByID(model.UserName);
            //        var userSession = new LoginUser();
            //        userSession.UserName = user.UserName;
            //        userSession.UserID = user.UserID;
            //        userSession.GroupID = user.GroupID;
            //        Session.Add(CommonSession.USER_SESSION, userSession);
            //        return RedirectToAction("Index", "HomeAdmin");
            //    }
            //    else if (result == 0)
            //    {
            //        ModelState.AddModelError("", "Tài khoản không tồn tại.");
            //    }
            //    else if (result == -1)
            //    {
            //        ModelState.AddModelError("", "Tài khoản đang bị khoá.");
            //    }
            //    else if (result == -2)
            //    {
            //        ModelState.AddModelError("", "Mật khẩu không đúng.");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Đăng nhập không đúng.");
            //    }
            //}
            return View(model);
        }
    }
}