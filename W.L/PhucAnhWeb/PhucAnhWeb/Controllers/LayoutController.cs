using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnhWeb.Common;
using PhucAnhWeb.DAO;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Controllers
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
            //var sessionUserLogin = Session[Common.CommonSession.USER_SESSION] as LoginUser;
            //if (sessionUserLogin == null)
            //{
            //    sessionUserLogin = new LoginUser();
            //}
            //var UserLogin = UserDAO.Instance.GetByID(sessionUserLogin.UserID);
            //ViewData["UserLogin"] = UserLogin;
            using(var db= new ApplicationDbContextt())
            {
                var phanLoaiSanPham = db.PhanLoaiSanPhams.ToList();
                var danhMucSanPham = db.DanhMucSanPhams.ToList();
                var loaiDanhMucSanPham = db.LoaiDanhMucSanPhams.ToList();
                var phanLoaiTheoHang = db.PhanLoaiTheoHangSps.ToList();
                var sanPham = db.SanPhams.ToList();
                var loaiDMSP = from dmsp in danhMucSanPham
                               join loaiDM in loaiDanhMucSanPham on dmsp.DanhMucSanPhamPID equals loaiDM.DanhMucSanPhamPID
                               where dmsp.DanhMucSanPhamPID == loaiDM.DanhMucSanPhamPID
                               select dmsp;

                var DanhMuc = from plsp in phanLoaiSanPham
                              join dm in danhMucSanPham on plsp.DanhMucSanPhamID equals dm.DanhMucSanPhamID
                              where dm.Status == true
                              select plsp;
                
                ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                ViewData["loaiDMSP"] = loaiDMSP.ToList();
                ViewData["DanhMuc"] = DanhMuc.ToList();
            }
            return View();

        }
        public ActionResult footer()
        {
            return View();
        }
    }
}