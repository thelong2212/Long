using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnhWeb.DAO;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Areas.Admin.Controllers
{
    public class DMSPController : Controller
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
                
                return RedirectToAction("Index", "DMSP");
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
               
                return RedirectToAction("Index", "DMSP");
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
