using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnhWeb.Common;
using PhucAnhWeb.DAO;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Controllers
{
    public class ThanhToanHoaDonController : Controller
    {
        // GET: ThanhToanHoaDon
        public ActionResult Index()
        {
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
                
                var sessionGioHang = Session[Common.CommonSession.CART_SESSION] as GioHang;
                if (sessionGioHang == null)
                {
                    sessionGioHang = new GioHang();
                }
                //var sessionUserLogin = Session[Common.CommonSession.USER_SESSION] as LoginUser;
                //if (sessionUserLogin == null)
                //{
                //    sessionUserLogin = new LoginUser();
                //}
                //var UserLogin = UserDAO.Instance.GetByID(sessionUserLogin.UserID);
                //ViewData["UserLogin"] = UserLogin;
                ViewData["phanLoaiTheoHang"] = phanLoaiTheoHang.ToList();
                ViewData["loaiDanhMucSanPham"] = loaiDanhMucSanPham.ToList();
                ViewData["loaiDMSP"] = loaiDMSP.ToList();
                ViewData["DanhMuc"] = DanhMuc.ToList();
                return View(sessionGioHang);
            }
            
            
        }
        public ActionResult XacNhanThanhToan()
        {
            using (var db = new ApplicationDbContext())
            {
                var kh = new KhachHang();
                var donHang = new DonHang();
                var spDonHang = new SanPhamDonHang();
                var sessionGioHang = Session[Common.CommonSession.CART_SESSION] as GioHang;
               
                kh.HoTen = Request.Form["hoTen"];
                kh.SoDienThoai = Convert.ToInt32(Request.Form["soDienThoai"]);
                kh.Email = Request.Form["email"];
                kh.DiaChi = Request.Form["diaChi"];
                int khacHangID = KhachHangDAO.Instance.CreateKhachHang(kh);
                if (khacHangID != 0)
                {
                    donHang.NhanVienID = 1;
                    donHang.KhachHangID = khacHangID;
                    donHang.NgayNhan = Convert.ToDateTime(Request.Form["ngayNhan"]);
                    donHang.DiaChiNhanHangChiTiet = Request.Form["diaChiNhanHang"];
                    donHang.GhiChu = Request.Form["ghiChu"];
                    donHang.GiaTriDonHang = sessionGioHang.TongTien;
                    var donHangId = DonHangDAO.Instance.insertDonHang(donHang);
                    if (donHangId != 0)
                    {
                        spDonHang.DonHangID = donHangId;
                        foreach (var item in sessionGioHang.Gio)
                        {
                            spDonHang.GhiChu = donHang.GhiChu;
                            spDonHang.SanPhamID = item.SanPham.SanPhamID;
                            spDonHang.SoLuong = item.SoLuong;
                            SanPhamDonHangDAO.Instance.insertSanPhamDonHang(spDonHang);
                        }
                    }
                    ViewBag.DonHangID = donHangId;
                    string content = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Asset/client/Template/mail.html"));
                    content = content.Replace("{{cstomerName}}", kh.HoTen);
                    content = content.Replace("{{SDT}}", kh.SoDienThoai.ToString());
                    content = content.Replace("{{Email}}", kh.Email);
                    content = content.Replace("{{DiaChi}}", kh.DiaChi);
                    content = content.Replace("{{TongTien}}", donHang.GiaTriDonHang.ToString());
                    var toEmailAddr = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                    new MailHelper().SendMail(kh.Email, $"Bạn đã đặt thành công đơn hàng mã số {donHangId} ", content);
                    new MailHelper().SendMail(toEmailAddr, $"Đơn hàng mới {donHangId} từ khách hàng Id = {kh.KhachHangID}: {kh.HoTen}", content);
                }
                return View();
            }
        }
    }
}