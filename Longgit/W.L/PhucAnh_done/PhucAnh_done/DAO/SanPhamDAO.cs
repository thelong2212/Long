using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PhucAnh_done.Models;

namespace PhucAnh_done.DAO
{
    public class SanPhamDAO
    {
        ApplicationDbContext db = null;
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
            db = new ApplicationDbContext();
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
            return model.OrderByDescending(x => x.NgayTao).ToPagedList(page, pageSize);
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
    }
}