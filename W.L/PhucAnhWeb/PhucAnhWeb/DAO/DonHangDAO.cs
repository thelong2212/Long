using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhucAnhWeb.Models;

namespace PhucAnhWeb.Common
{
    public class DonHangDAO
    {
        private readonly ApplicationDbContextt db;
        // insert, update, delete
        private static DonHangDAO instance;
        static object key = new object();
        public static DonHangDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DonHangDAO();
                }
                return instance;
            }
        }
        public DonHangDAO()
        {
            db = new ApplicationDbContextt();
        }
        // insert 
        public int insertDonHang(DonHang donHang)
        {
            try
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return donHang.DonHangID;
            }
            catch (Exception)
            {
                return 0; // them that bai
            }
        }
    }
}