using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnhWeb.DAO;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        // GET: ChiTietSanPham
        public ActionResult Index(int id)
        {
            using (var db = new ApplicationDbContextt())
            {

                var sanPham = db.SanPhams.Include("CTSanPhams").Where(x => x.SanPhamID == id).FirstOrDefault();
                var ImgSanPham = db.ImageSanPhams.Where(x => x.SanPhamID == id);
                var ctSanPham = db.CTSanPhams.SingleOrDefault(x => x.SanPhamID == sanPham.SanPhamID);
                var dsSanPhamLienQuan = new List<SanPham>();
                if (sanPham.DanhMucSanPhamID != null)
                {
                    dsSanPhamLienQuan = db.SanPhams.Where(x => x.DanhMucSanPhamID == sanPham.DanhMucSanPhamID).Take(5).ToList();
                }
                if (sanPham.DanhMucSanPhamID == null)
                    return View("Error");
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

                ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                ViewData["loaiDMSP"] = loaiDMSP.ToList();
                ViewData["DanhMuc"] = DanhMuc.ToList();
                ViewData["sanPham"] = sanPham;
                ViewData["ctSanPham"] = ctSanPham;
                ViewData["ImgSanPham"] = ImgSanPham.ToList();
                ViewData["dsSanPhamLienQuan"] = dsSanPhamLienQuan;
            }
            return View();
        }
    }
}