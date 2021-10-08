using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Web_PA.Models;

namespace Web_PA.DAO
{
    public class SanPhamDAO
    {
        ApplicationDbContextt db = null;
        private static SanPhamDAO instance;
        static object key = new object();
        public static SanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        instance = new SanPhamDAO();
                    }
                }
                return instance;
            }
        }
        public SanPhamDAO()
        {
            db = new ApplicationDbContextt();
        }
        public long Create(SanPham entity)
        {
            entity.Status = true;
            db.SanPhams.Add(entity);
            db.SaveChanges();
            return entity.SanPhamID;
        }
        public IEnumerable<SanPham> ListAllPaging (string keyword, int page, int pageSize)
        {
            IQueryable<SanPham> model = db.SanPhams;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.TenSanPham.Contains(keyword) || x.ThongTinSanPham.Contains(keyword) || x.MaSanPham.Contains(keyword));
            }
            return model.OrderByDescending(x => x.TenSanPham).ToPagedList(page, pageSize);
        }

        public bool Update(SanPham update)
        {
            try
            {
                var sanPham = db.SanPhams.Find(update.SanPhamID);
                sanPham.TenSanPham = update.TenSanPham;
                sanPham.PhanLoaiSanPhamID = update.PhanLoaiSanPhamID;
                sanPham.DanhMucSanPhamID = update.DanhMucSanPhamID;
                sanPham.DanhMucSanPhamPID = update.DanhMucSanPhamPID;
                sanPham.AnhSanPham = update.AnhSanPham;
                sanPham.GiaBan = update.GiaBan;
                sanPham.GiaNiemYet = update.GiaNiemYet;
                sanPham.MaSanPham = update.MaSanPham;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var sanPham = db.SanPhams.Find(id);
                var listCTSanPham = db.CTSanPhams.Where(x => x.SanPhamID == sanPham.SanPhamID);
                db.CTSanPhams.RemoveRange(listCTSanPham);
                db.SanPhams.Remove(sanPham);
                db.SaveChanges(); 
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public SanPham ViewDetail(int id)
        {
            var detail = db.SanPhams.Find(id);
            return detail;
        }
        public List<SanPham> LoaiDanhMucSanPham(int? id)
        {
            var loaiDMSP = db.SanPhams.Where(x => x.DanhMucSanPhamPID == id).OrderByDescending(x => x.SanPhamID).ToList();
            return loaiDMSP;
        }
        public List<SanPham> DanhMucSanPham(int? id)
        {
            var loaiDMSP = db.SanPhams.Where(x => x.DanhMucSanPhamID == id).OrderByDescending(x => x.SanPhamID).ToList();
            return loaiDMSP;
        }
        public List<SanPham> DanhMucSanPhamTheoPhanLoai(int? id)
        {
            var DMSPTheoPhanLoai = db.SanPhams.Where(x => x.PhanLoaiSanPhamID == id).OrderByDescending(x => x.SanPhamID).ToList();
            return DMSPTheoPhanLoai;
        }
        public List<SanPham> DanhMucSanPhamTheoTen(int? id)
        {
            var DMSPTheoPhanLoai = db.SanPhams.Where(x => x.PhanLoaiSanPhamID == id).OrderByDescending(x => x.SanPhamID).ToList();
            return DMSPTheoPhanLoai;
        }
        public List<string> ListName(string keyword)
        {
            return db.SanPhams.Where(x => x.TenSanPham.Contains(keyword)).Select(x => x.TenSanPham).ToList();
        }
        public List<SanPham> Search( string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 8)
        {
            totalRecord = db.SanPhams.Where(x => x.TenSanPham.Contains(keyword)).Count();
            var model = db.SanPhams.Where(x =>x.TenSanPham.Contains(keyword)).OrderByDescending(x => x.SanPhamID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}