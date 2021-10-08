using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnh_done.Areas.Admin.Models;
using PhucAnh_done.Common;
using PhucAnh_done.DAO;

namespace PhucAnh_done.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult logoutAdmin()
        {
            Session[Common.CommonSession.USER_SESSION] = null;
            return RedirectToAction("Index");
        }
        public ActionResult loginAdmin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new LoginUser();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.UserID;
                    userSession.GroupID = user.GroupID;
                    Session.Add(CommonSession.USER_SESSION, userSession);
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View("Index");
        }
    }
}