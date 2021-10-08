using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnh_done.DAO;
using PhucAnh_done.Models;

namespace PhucAnh_done.Areas.Admin.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        // GET: Admin/DanhMucSanPham
        public ActionResult Index(string Keyword, int page=1, int pageSize=10)
        {
            var dao = new DanhMucSanPhamDAO();
            var model = dao.ListAllpaging(Keyword, page, pageSize);
            ViewBag.Keyword = Keyword;
            return View(model);
        }

        // GET: Admin/DanhMucSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucSanPham/Create
        [HttpPost]
        public ActionResult Create(DanhMucSanPham danhMucSanPham)
        {
            var dao = new DanhMucSanPhamDAO();
            var model = dao.Insert(danhMucSanPham);
            if (model > 0)
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng thành công";
                return RedirectToAction("Index", "DanhMucSanPham");
            }
            else
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng KHÔNG thành công";
            }
            return View(danhMucSanPham);
        }

        // GET: Admin/DanhMucSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            var danhMucSanPham = new DanhMucSanPhamDAO().ViewDetail(id);
            return View(danhMucSanPham);
        }

        // POST: Admin/DanhMucSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit( DanhMucSanPham danhMucSanPham)
        {
            var dao = new DanhMucSanPhamDAO();
            var model = dao.Update(danhMucSanPham);
            if (model)
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng thành công";
                return RedirectToAction("Index", "DanhMucSanPham");
            }
            else
            {
                ViewBag.Success = "Cập nhật thông tin khách hàng KHÔNG thành công";
            }

            return View("Index");
        }

        // GET: Admin/DanhMucSanPham/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DanhMucSanPhamDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
