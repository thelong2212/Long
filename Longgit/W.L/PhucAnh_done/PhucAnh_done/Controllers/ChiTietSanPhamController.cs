using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnh_done.Models;

namespace PhucAnh_done.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        // GET: ChiTietSanPham
        public ActionResult Index(int id)
        {
            using (var db = new ApplicationDbContext())
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
                
                ViewData["sanPham"] = sanPham;
                ViewData["ctSanPham"] = ctSanPham;
                ViewData["ImgSanPham"] = ImgSanPham.ToList();
                ViewData["dsSanPhamLienQuan"] = dsSanPhamLienQuan;
            }
            return View();
        }
    }
}