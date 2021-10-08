using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnh_done.DAO;
using PhucAnh_done.Models;

namespace PhucAnh_done.Areas.Admin.Controllers
{
    public class PhanLoaiSanPhamController : Controller
    {
        // GET: Admin/PhanLoaiSanPham
        public ActionResult Index(string KeyWord, int page = 1, int pageSize = 10)
        {
            var dao = new PhanLoaiSanPhamDAO();
            var model = dao.ListAllpaging(KeyWord, page, pageSize);
            ViewBag.Keyword = KeyWord;
            return View(model);
        }


        // GET: Admin/PhanLoaiSanPham/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhanLoaiSanPham/Create
        [HttpPost]
        public ActionResult Create(PhanLoaiSanPham phamLoaiSanPham)
        {
            var dao = new PhanLoaiSanPhamDAO();
            var model = dao.insert(phamLoaiSanPham);
            if (model > 0)
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng thành công";
                return RedirectToAction("Index", "PhanLoaiSanPham");
            }
            else
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng KHÔNG thành công";
            }
            return View(phamLoaiSanPham);
        }

        // GET: Admin/PhanLoaiSanPham/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var phanLoaiSanPham = new PhanLoaiSanPhamDAO().ViewDetail(id);
            return View(phanLoaiSanPham);
        }

        // POST: Admin/PhanLoaiSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit( PhanLoaiSanPham phanLoaiSanPham)
        {
            var dao = new PhanLoaiSanPhamDAO();
            var model = dao.update(phanLoaiSanPham);
            if (model)
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng thành công";
                return RedirectToAction("Index", "PhanLoaiSanPham");
            }
            else
            {
                ViewBag.Success = "Cập nhật thông tin khách hàng KHÔNG thành công";
            }

            return View("Index");
        }

        // GET: Admin/PhanLoaiSanPham/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new PhanLoaiSanPhamDAO().delete(id);
            return RedirectToAction("Index");
        }
    }
}
