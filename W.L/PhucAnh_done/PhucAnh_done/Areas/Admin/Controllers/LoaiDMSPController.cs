using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnh_done.DAO;
using PhucAnh_done.Models;

namespace PhucAnh_done.Areas.Admin.Controllers
{
    public class LoaiDMSPController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string Keyword, int page = 1, int pageSize = 10)
        {
            var dao = new LoaiDanhMucSanPhamDAO();
            var model = dao.ListAllpaging(Keyword, page, pageSize);
            ViewBag.Keyword = Keyword;
            return View(model);
        }

        // GET: Admin/Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(LoaiDanhMucSanPham loaiDanhMucSanPham)
        {
            var dao = new LoaiDanhMucSanPhamDAO();
            var model = dao.insert(loaiDanhMucSanPham);
            if (model > 0)
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng thành công";
                return RedirectToAction("Index", "LoaiDMSP");
            }
            else
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng KHÔNG thành công";
            }
            return View(loaiDanhMucSanPham);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            var loaiDanhMucSanPham = new LoaiDanhMucSanPhamDAO().ViewDetail(id);
            return View(loaiDanhMucSanPham);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit( LoaiDanhMucSanPham loaiDanhMucSanPham)
        {
            var dao = new LoaiDanhMucSanPhamDAO();
            var model = dao.update(loaiDanhMucSanPham);
            if (model)
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng thành công";
                return RedirectToAction("Index", "LoaiDMSP");
            }
            else
            {
                ViewBag.Success = "Cập nhật thông tin khách hàng KHÔNG thành công";
            }

            return View("Index");
        }

        // GET: Admin/Category/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LoaiDanhMucSanPhamDAO().delete(id);
            return RedirectToAction("Index");
        }
    }
}
