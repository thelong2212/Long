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
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult header()
        {
            GioHang sessionGioHang = Session[Common.CommonSession.CART_SESSION] as GioHang;
            //soLuong
            if (sessionGioHang == null)
                ViewBag.SoLuong = 0;
            else
                ViewBag.SoLuong = sessionGioHang.TongSoLuong;
            var sessionUserLogin = Session[Common.CommonSession.USER_SESSION] as LoginUser;
            if (sessionUserLogin == null)
            {
                sessionUserLogin = new LoginUser();
            }
            var UserLogin = UserDAO.Instance.GetByID(sessionUserLogin.UserName);
            ViewData["UserLogin"] = UserLogin;
            return View();

        }
        public ActionResult footer()
        {
            return View();
        }
    }
}