using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using Web_PA.Models;
namespace Web_PA.DAO
{
    public class NhanVienDAO
    {
        ApplicationDbContextt db = null;
        private static NhanVienDAO instance;
        static object key = new object();
        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)//bất đồng bộ , chiếm dụng tài nguyên....
                    {
                        instance = new NhanVienDAO();
                    }
                }
                return instance;
            }
        }
        public NhanVienDAO()
        {
            db = new ApplicationDbContextt();
        }

        public int CreateNhanVien(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
            return nv.NhanVienID;
        }

        public bool Update(NhanVien update)
        {
            try
            {
                var nhanVien = db.NhanViens.Find(update.NhanVienID);
                nhanVien.HoTen = update.HoTen;
                nhanVien.NgaySinh = update.NgaySinh;
                nhanVien.SoDienThoai1 = update.SoDienThoai1;
                nhanVien.SoDienThoai2 = update.SoDienThoai2;
                nhanVien.GhiChu = update.GhiChu;
                nhanVien.DiaChi = update.DiaChi;
                nhanVien.Email = update.Email;
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
            var nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return true;
        }
        public NhanVien Detail(int id)
        {
            return db.NhanViens.Find(id);
        }
        public IEnumerable<NhanVien> ListAllpaging(string Keyword, int page, int pageSize)
        {
            IQueryable<NhanVien> model = db.NhanViens;
            if (!string.IsNullOrEmpty(Keyword))
            {
                model = model.Where(x => x.HoTen.Contains(Keyword) || x.Email.Contains(Keyword));
            }

            return model.OrderByDescending(x => x.NhanVienID).ToPagedList(page, pageSize);
        }
    }
}