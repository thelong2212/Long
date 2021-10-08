using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhucAnhWeb.DAO;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Areas.Admin.Controllers
{
    //public class UserGroupController : Controller
    //{
    //    // GET: Admin/UserGroup
    //    public ActionResult Index(string Keywword, int page=1, int pageSize=8)
    //    {
    //        var dao = new UserGroupDAO();
    //        var model = dao.ListAllpaging(Keywword, page, pageSize);
    //        ViewBag.Keyword = Keywword;
    //        return View(model);
    //    }

    //    // GET: Admin/UserGroup/Create
    //    [HttpGet]
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Admin/UserGroup/Create
    //    [HttpPost]
    //    public ActionResult Create(UserGroup userID)
    //    {
    //        var dao = new UserGroupDAO();
    //        var model = dao.Insert(userID);
    //        if (model > 0)
    //        {
               
    //            return RedirectToAction("Index", "UserGroup");
    //        }
          
    //        return View(userID);
    //    }

    //    // GET: Admin/UserGroup/Edit/5
    //    [HttpGet]
    //    public ActionResult Edit(int userID)
    //    {
    //        var userGroup = new UserGroupDAO().ViewDetail(userID);
    //        return View(userGroup);
    //    }

    //    // POST: Admin/UserGroup/Edit/5
    //    [HttpPost]
    //    public ActionResult Edit( UserGroup userID)
    //    {
    //        var dao = new UserGroupDAO();
    //        var model = dao.Update(userID);
    //        if (model)
    //        {     
    //            return RedirectToAction("Edit", "UserGroup");
    //        }
           
    //        return View("Edit");
    //    }

    //    // GET: Admin/UserGroup/Delete/5
    //    [HttpDelete]
    //    public ActionResult Delete(int userID)
    //    {
    //        new UserGroupDAO().Delete(userID);
    //        return RedirectToAction("Index");
    //    }
    //}
}
   