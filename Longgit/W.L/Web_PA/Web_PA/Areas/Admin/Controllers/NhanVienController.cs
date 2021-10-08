using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_PA.DAO;
using Web_PA.Models;

namespace Web_PA.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien

        public ActionResult Index(string Keyword, int page = 1, int pageSize = 10)
        {
            var dao = new NhanVienDAO();
            var model = dao.ListAllpaging(Keyword, page, pageSize);
            ViewBag.Keyword = Keyword;
            return View(model);
        }

        // GET: Admin/NhanVien/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien nhanVien)
        {
            var dao = new NhanVienDAO();
            var model = dao.CreateNhanVien(nhanVien);
            if (model > 0)
            {
                return RedirectToAction("Index", "NhanVien");
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var nhanVien = new NhanVienDAO().Detail(id);
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(NhanVien nhanVien)
        {
            var dao = new NhanVienDAO();
            var model = dao.Update(nhanVien);
            if (model)
            {
                return RedirectToAction("Index", "NhanVien");
            }
            return View("Index");
        }

        // GET: Admin/NhanVien/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NhanVienDAO().Delete(id);
            return RedirectToAction("Index");
        }

    }
}
