  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnhWeb.DAO;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContextt())
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
        //public JsonResult ListName(string keywword)
        //{
        //    var data = new SanPhamDAO().ListName(keywword);
        //    return Json(new
        //    {
        //        data,
        //        status = true
        //    }, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult SearchProduct(string keyword, int page = 1, int pageSize=8)
        {
            using(var db= new ApplicationDbContextt())
            {
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


                int totalRecord = 0;
                var model = new SanPhamDAO().Search(keyword, ref totalRecord, page, pageSize);

                ViewBag.Total = totalRecord;
                ViewBag.Page = page;
                ViewBag.keyword = keyword;
                int maxPage = 5;
                int totalPage = 0;

                totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
                ViewBag.TotalPage = totalPage + 1;
                ViewBag.MaxPage = maxPage;
                ViewBag.First = 1;
                ViewBag.Last = totalPage;
                ViewBag.Next = page + 1;
                ViewBag.Prev = page - 1;
                ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                ViewData["loaiDMSP"] = loaiDMSP.ToList();
                ViewData["DanhMuc"] = DanhMuc.ToList();
                return View(model);
            }
            
        }
    }
}