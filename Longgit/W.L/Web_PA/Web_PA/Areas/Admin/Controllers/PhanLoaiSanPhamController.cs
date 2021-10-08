using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_PA.DAO;
using Web_PA.Models;

namespace Web_PA.Areas.Admin.Controllers
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
                return RedirectToAction("Index", "PhanLoaiSanPham");
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
