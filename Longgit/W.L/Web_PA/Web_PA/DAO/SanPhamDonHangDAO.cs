using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_PA.Models;

namespace Web_PA.DAO
{
    public class SanPhamDonHangDAO
    {
        private readonly ApplicationDbContextt db;
        // insert, update, delete
        private static SanPhamDonHangDAO instance;
        static object key = new object();
        public static SanPhamDonHangDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamDonHangDAO();
                }
                return instance;
            }
        }
        public SanPhamDonHangDAO()
        {
            db = new ApplicationDbContextt();
        }
        public int insertSanPhamDonHang(SanPhamDonHang sanPhamDonHang)
        {
            try
            {
                db.SanPhamDonHangs.Add(sanPhamDonHang);
                db.SaveChanges();
                return sanPhamDonHang.SanPhamDonHangID;
            }
            catch (Exception)
            {
                return 0; // them that bai
            }
        }
    }
}