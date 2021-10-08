using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnh_done.Models;

namespace PhucAnh_done.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
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
                var SanPhamHot = db.SanPhams.Where(x => x.Hot == true).First();
                 var listHot = db.SanPhams.Where(x => x.Hot == true);
                var SanPhamNew = db.SanPhams.Where(x => x.New == true).First();
                var listSpNew = db.SanPhams.Where(x => x.New == true);

                ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                ViewData["loaiDMSP"] = loaiDMSP.ToList();
                ViewData["DanhMuc"] = DanhMuc.ToList();
               
                ViewData["SanPhamHot"] = SanPhamHot;
                ViewData["listHot"] = listHot.ToList();
                ViewData["SanPhamNew"] = SanPhamNew;
                ViewData["listSpNew"] = listSpNew.ToList();
                ViewData["sanPham"] = sanPham.ToList();
            }
            return View();
        }

    }
}