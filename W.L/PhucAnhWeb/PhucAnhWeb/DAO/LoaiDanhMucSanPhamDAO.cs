using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.DAO
{
    public class LoaiDanhMucSanPhamDAO
    {
        ApplicationDbContextt db = null;
        private static LoaiDanhMucSanPhamDAO instance;
        static object key = new object();
        public static LoaiDanhMucSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)//bất đồng bộ , chiếm dụng tài nguyên....
                    {
                        instance = new LoaiDanhMucSanPhamDAO();
                    }
                }
                return instance;
            }
        }

        public LoaiDanhMucSanPhamDAO()
        {
             db = new ApplicationDbContextt();
        }
        public long insert(LoaiDanhMucSanPham loaiDanhMucSanPham)
        {
            loaiDanhMucSanPham.status = true;
            db.LoaiDanhMucSanPhams.Add(loaiDanhMucSanPham);
            db.SaveChanges();
            return loaiDanhMucSanPham.DanhMucSanPhamPID;
        }
        public bool update(LoaiDanhMucSanPham update)
        {
            try
            {
                var loaiDMSP = db.LoaiDanhMucSanPhams.Find(update.DanhMucSanPhamPID);
                loaiDMSP.TenLoaiDanhMucSanPham = update.TenLoaiDanhMucSanPham;
                loaiDMSP.status = update.status;
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
                var loaiDMSP = db.LoaiDanhMucSanPhams.Find(id);
                db.LoaiDanhMucSanPhams.Remove(loaiDMSP);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public LoaiDanhMucSanPham ViewDetail(int id)
        {
            return db.LoaiDanhMucSanPhams.Find(id);
        }
        public IEnumerable<LoaiDanhMucSanPham> ListAllpaging(string keyword, int page, int pageSize)
        {
            IQueryable<LoaiDanhMucSanPham> model = db.LoaiDanhMucSanPhams;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = db.LoaiDanhMucSanPhams.Where(x => x.TenLoaiDanhMucSanPham.Contains(keyword));
            }
            return model.OrderByDescending(x => x.DanhMucSanPhamPID).ToPagedList(page, pageSize);
        }
    }
}