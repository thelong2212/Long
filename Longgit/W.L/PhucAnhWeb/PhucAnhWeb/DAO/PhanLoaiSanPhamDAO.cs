using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.DAO
{
    public class PhanLoaiSanPhamDAO
    {
        ApplicationDbContextt db = null;
        private static PhanLoaiSanPhamDAO instance;
        static object key = new object();
        public static PhanLoaiSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)//bất đồng bộ , chiếm dụng tài nguyên....
                    {
                        instance = new PhanLoaiSanPhamDAO();
                    }
                }
                return instance;
            }
        }

        public PhanLoaiSanPhamDAO()
        {
             db = new ApplicationDbContextt();
        }
        public long insert(PhanLoaiSanPham phanLoaiDanhMuc)
        {
            db.PhanLoaiSanPhams.Add(phanLoaiDanhMuc);
            db.SaveChanges();
            return phanLoaiDanhMuc.PhanLoaiSanPhamID;
        }
        public bool update(PhanLoaiSanPham update)
        {
            try
            {
                var phanLoaiSanPham = db.PhanLoaiSanPhams.Find(update.PhanLoaiSanPhamID);
                phanLoaiSanPham.TenPhanLoaiSanPham = update.TenPhanLoaiSanPham;
                phanLoaiSanPham.DanhMucSanPhamID = update.DanhMucSanPhamID;
                phanLoaiSanPham.GhiChu = update.GhiChu;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool delete(int id)
        {
            try
            {
                var phanLoaiSanPham = db.PhanLoaiSanPhams.Find(id);
                db.PhanLoaiSanPhams.Remove(phanLoaiSanPham);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public PhanLoaiSanPham ViewDetail(int id)
        {
            return db.PhanLoaiSanPhams.Find(id);
        }
        public IEnumerable<PhanLoaiSanPham> ListAllpaging(string keyword, int page, int pageSize)
        {
            IQueryable<PhanLoaiSanPham> model = db.PhanLoaiSanPhams;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.TenPhanLoaiSanPham.Contains(keyword));
            }
            return model.OrderByDescending(x => x.PhanLoaiSanPhamID).ToPagedList(page, pageSize);
        }
    }
}