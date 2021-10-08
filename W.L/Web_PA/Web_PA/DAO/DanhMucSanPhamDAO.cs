using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Web_PA.Models;

namespace Web_PA.DAO
{
    public class DanhMucSanPhamDAO
    {
        ApplicationDbContextt db = null;
        private static DanhMucSanPhamDAO instance;
        static object key = new object();
        public static DanhMucSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)//bất đồng bộ , chiếm dụng tài nguyên....
                    {
                        instance = new DanhMucSanPhamDAO();
                    }
                }
                return instance;
            }
        }
        public DanhMucSanPhamDAO()
        {
            db = new ApplicationDbContextt();
        }
        public List<DanhMucSanPham> listAll()
        {
            return db.DanhMucSanPhams.Where(x => x.Status == true).ToList();
        }
        public long Insert(DanhMucSanPham danhMucSanPham)
        {
            danhMucSanPham.Status = true;
            db.DanhMucSanPhams.Add(danhMucSanPham);
            db.SaveChanges();
            return danhMucSanPham.DanhMucSanPhamID;
        }
        public bool Update(DanhMucSanPham update)
        {
            try
            {
                var danhMucSanPham = db.DanhMucSanPhams.Find(update.DanhMucSanPhamID);
                danhMucSanPham.TenDanhMucSanPham = update.TenDanhMucSanPham;
                danhMucSanPham.GhiChu = update.GhiChu;
                danhMucSanPham.Language = update.Language;
                danhMucSanPham.LoaiDanhMucSanPham = update.LoaiDanhMucSanPham;
                danhMucSanPham.Status = update.Status;
                danhMucSanPham.Laptop_theo_khoảng_tiền = update.Laptop_theo_khoảng_tiền;
                danhMucSanPham.Laptop___Linh_phụ_kiện = update.Laptop___Linh_phụ_kiện;
                danhMucSanPham.Linh_kiện_máy_tính = update.Linh_kiện_máy_tính;
                danhMucSanPham.Màn_hình_máy_tính = update.Màn_hình_máy_tính;
                danhMucSanPham.Máy_tính_đồng_bộ = update.Máy_tính_đồng_bộ;
                danhMucSanPham.PC_chơi_Game__Gaming_Gear = update.PC_chơi_Game__Gaming_Gear;
                danhMucSanPham.Phụ_kiện_máy_tính___nghe_nhìn = update.Phụ_kiện_máy_tính___nghe_nhìn;
                danhMucSanPham.Server___Workstation = update.Server___Workstation;
                danhMucSanPham.Thiết_bị_văn_phòng = update.Thiết_bị_văn_phòng;
                danhMucSanPham.Điện_thoại__Tavlet___Phụ_kiện = update.Điện_thoại__Tavlet___Phụ_kiện;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var danhMucSanPham = db.DanhMucSanPhams.Find(id);
                var ListDMSP = db.DanhMucSanPhams.Where(x => x.DanhMucSanPhamID == danhMucSanPham.DanhMucSanPhamID).ToList();
                db.DanhMucSanPhams.RemoveRange(ListDMSP);
                db.DanhMucSanPhams.Remove(danhMucSanPham);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DanhMucSanPham ViewDetail(int id)
        {
            return db.DanhMucSanPhams.Find(id);
        }
        public IEnumerable<DanhMucSanPham> ListAllpaging(string keyword, int page, int pageSize)
        {
            IQueryable<DanhMucSanPham> model = db.DanhMucSanPhams;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.TenDanhMucSanPham.Contains(keyword));
            }
            return model.OrderByDescending(x => x.DanhMucSanPhamID).ToPagedList(page, pageSize);
        }
    }
}