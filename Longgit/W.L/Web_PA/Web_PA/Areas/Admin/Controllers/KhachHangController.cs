using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_PA.DAO;
using Web_PA.Models;

namespace Web_PA.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        public ActionResult Index(string Keyword, int page=1, int pageSize=10)
        {
            var dao = new KhachHangDAO();
            var model = dao.ListAllpaging(Keyword, page, pageSize);
            ViewBag.Keyword = Keyword;
            return View(model);
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/KhachHang/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHang/Create
        [HttpPost]
        public ActionResult Create(KhachHang khachHang)
        {
            var dao = new KhachHangDAO();
            var model = dao.CreateKhachHang(khachHang);
            if (model>0)
            {          
                return RedirectToAction("Index", "KhachHang");
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHang/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var khacHang = new KhachHangDAO().ViewDetail(id);
            return View(khacHang);
        }

        // POST: Admin/KhachHang/Edit/5
        [HttpPost]
        public ActionResult Edit( KhachHang khachHang)
        {
            var dao = new KhachHangDAO();
            var model = dao.Update(khachHang);
            if (model)
            {
                return RedirectToAction("Index", "KhachHang");
            }


            return View("Index");
        }

        // GET: Admin/KhachHang/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KhachHangDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
