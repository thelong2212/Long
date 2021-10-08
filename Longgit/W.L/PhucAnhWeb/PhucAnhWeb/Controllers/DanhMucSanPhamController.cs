using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnhWeb.DAO;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        // GET: DanhMucSanPham
        public ActionResult DMTheoLoai(int? ID)
        {
            using (var db = new ApplicationDbContextt())
            {
                if (ID.HasValue)
                {
                    var TenLoaiDMSP = db.DanhMucSanPhams.Where(x => x.DanhMucSanPhamPID == ID);
                    var ListLoaiDMSP = new SanPhamDAO().LoaiDanhMucSanPham(ID);

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
                    ViewBag.TenLoaiDMSP = TenLoaiDMSP;
                    ViewData["TenLoaiDMSP"] = TenLoaiDMSP.ToList();
                    ViewData["ListLoaiDMSP"] = ListLoaiDMSP.ToList();

                    ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                    ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                    ViewData["loaiDMSP"] = loaiDMSP.ToList();
                    ViewData["DanhMuc"] = DanhMuc.ToList();
                }
            }
            return View();
        }
        public ActionResult DanhMucSanPham(int? ID)
        {
            using (var db = new ApplicationDbContextt())
            {
                if (ID.HasValue)
                {
                    //var TenDMSP = db.DanhMucSanPhams.Where(x => x.DanhMucSanPhamID == ID);
                    var TenDMSP = db.DanhMucSanPhams.Where(x => x.DanhMucSanPhamID == ID).Select(x => x.TenDanhMucSanPham).FirstOrDefault();
                    var ListDMSP = new SanPhamDAO().DanhMucSanPham(ID);

                    var phanLoaiSanPham = db.PhanLoaiSanPhams.ToList();
                    var danhMucSanPham = db.DanhMucSanPhams.ToList();
                    var loaiDanhMucSanPham = db.LoaiDanhMucSanPhams.ToList();
                    var phanLoaiTheoHang = db.PhanLoaiTheoHangSps.ToList();
                    var loaiDMSP = from dmsp in danhMucSanPham
                                   join loaiDM in loaiDanhMucSanPham on dmsp.DanhMucSanPhamPID equals loaiDM.DanhMucSanPhamPID
                                   where dmsp.DanhMucSanPhamPID == loaiDM.DanhMucSanPhamPID
                                   select dmsp;
                    var DanhMuc = from plsp in phanLoaiSanPham
                                  join dm in danhMucSanPham on plsp.DanhMucSanPhamID equals dm.DanhMucSanPhamID
                                  where dm.Status == true
                                  select plsp;

                    ViewBag.TenDMSP = TenDMSP;
                    ViewData["ListDMSP"] = ListDMSP.ToList();

                    ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                    ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                    ViewData["loaiDMSP"] = loaiDMSP.ToList();
                    ViewData["DanhMuc"] = DanhMuc.ToList();
                }
            }
            return View();
        }
        public ActionResult DMTheoPhanLoai(int? ID)
        {
            using (var db = new ApplicationDbContextt())
            {
                var TenDMPhanTheoLoai = db.PhanLoaiSanPhams.Where(x => x.PhanLoaiSanPhamID == ID).Select(x=>x.TenPhanLoaiSanPham).FirstOrDefault() ;
                var ListPhanLoai = new SanPhamDAO().DanhMucSanPhamTheoPhanLoai(ID);
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

                ViewBag.TenDMPhanTheoLoai = TenDMPhanTheoLoai;
                ViewData["ListPhanLoai"] = ListPhanLoai.ToList();

                ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                ViewData["loaiDMSP"] = loaiDMSP.ToList();
                ViewData["DanhMuc"] = DanhMuc.ToList();
            }
            return View();
        }
        public ActionResult DMTheoTen(int? ID)
        {
            using (var db = new ApplicationDbContextt())
            {
                var TenDMPhanTheoTen = db.PhanLoaiTheoHangSps.Where(x => x.PhanLoaiSanPhamID == ID);
                var ListDMTheoTen = new SanPhamDAO().DanhMucSanPhamTheoTen(ID);
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

                ViewBag.TenDMPhanTheoTen = TenDMPhanTheoTen;
                ViewData["ListDMTheoTen"] = ListDMTheoTen.ToList();

                ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                ViewData["loaiDMSP"] = loaiDMSP.ToList();
                ViewData["DanhMuc"] = DanhMuc.ToList();
            }
            return View();
        }
    }
}