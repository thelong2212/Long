using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_PA.DAO;
using Web_PA.Models;

namespace Web_PA.Areas.Admin.Controllers
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
               
                return RedirectToAction("Index", "LoaiDMSP");
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
               
                return RedirectToAction("Index", "LoaiDMSP");
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
