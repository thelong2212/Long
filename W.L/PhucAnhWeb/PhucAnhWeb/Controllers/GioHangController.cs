using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult gioHang()
        {
            var sessionGioHang = Session[Common.CommonSession.CART_SESSION] as GioHang;
            if (sessionGioHang== null)
            {
                sessionGioHang = new GioHang();
            }
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
            return View(sessionGioHang);
        }
        public ActionResult AddItem(int id)
        {
            using(var db= new ApplicationDbContextt())
            {
                GioHang sessionGioHang = Session[Common.CommonSession.CART_SESSION] as GioHang;
                if (sessionGioHang==null)
                {
                    sessionGioHang = new GioHang();
                }
                SanPham sanPham = db.SanPhams.Where(x => x.SanPhamID == id).FirstOrDefault();
                sessionGioHang.Add(sanPham);
                Session[Common.CommonSession.CART_SESSION] = sessionGioHang;
                var req = Request.UrlReferrer.AbsolutePath;
                return RedirectToAction("gioHang");
            }
        }

        public ActionResult RemoveProduct(int id, int soLuong)
        {
            var sessionGioHang = Session[Common.CommonSession.CART_SESSION] as GioHang;
            sessionGioHang.ChangeAmount(id, soLuong);
            Session[Common.CommonSession.CART_SESSION] = sessionGioHang;
            return RedirectToAction("gioHang");
        }
        public ActionResult RemoveAllProduct(int id)
        {
            var sessionGioHang = Session[Common.CommonSession.CART_SESSION] as GioHang;
            sessionGioHang.RemoveAll(id);
            Session[Common.CommonSession.CART_SESSION] = sessionGioHang;
            return RedirectToAction("gioHang");
        }
        public ActionResult Total(int id)
        {
            var sessionGioHang = Session[Common.CommonSession.CART_SESSION] as GioHang;
            return RedirectToAction("gioHang");
        }
    }
}