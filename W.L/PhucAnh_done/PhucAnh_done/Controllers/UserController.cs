using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnh_done.Common;
using PhucAnh_done.DAO;
using PhucAnh_done.Models;

namespace PhucAnh_done.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangXuat()
        {
            Session[CommonSession.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult DangNhap(LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), false);
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new LoginUser();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.UserID;
                    userSession.GroupID = user.GroupID;
                    Session.Add(CommonSession.USER_SESSION, userSession);
                    return Redirect("/");
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
            return View(model);
        }

        [HttpPost]
        public ActionResult DangKy(RegisterModels model)
        {
            if (ModelState.IsValid)
            {
                var register = new UserDAO();
                if (register.CheckUserName(model.Name))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (register.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã đăng ký");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Name = model.Name;
                    user.Email = model.Email;
                    user.PasswordSalt = Encryptor.MD5Hash(model.Password);
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    user.Address = model.Address;
                    user.DiaChiChiTiet = model.DiaChiChiTiet;
                    user.Status = true;
                    var result = register.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModels();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email đã đăng ký");
                    }
                }
            }
            return View(model);
        }
    }
}