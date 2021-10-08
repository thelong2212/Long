using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnh_done.DAO;
using PhucAnh_done.Models;

namespace PhucAnh_done.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string Keyword, int page=1, int pageSize =10)
        {
            var dao = new SanPhamDAO();
            var mode = dao.ListAllPaging(Keyword, page, pageSize);
            ViewBag.Keyword = Keyword;
            return View(mode);
        }


        // GET: Admin/Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(SanPham sanPham)
        {
            var dao = new SanPhamDAO();
            long id = dao.Create(sanPham);
            if (id > 0)
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng thành công";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng KHÔNG thành công";
            }
            return View(sanPham);
        }

        // GET: Admin/Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sanPham = new SanPhamDAO().ViewDetail(id);
            return View(sanPham);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit( SanPham sanPham)
        {
            var dao = new SanPhamDAO();
            var model = dao.Update(sanPham);
            if (model)
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng thành công";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Success = "Thêm mới thông tin khách hàng KHÔNG thành công"; 
            }

            return View("Index");
        }

        // GET: Admin/Product/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SanPhamDAO().Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
