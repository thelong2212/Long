﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhucAnhWeb.Models;
using PhucAnhWeb.Common;

namespace PhucAnhWeb.DAO
{
    public class UserDAO
    {
        ApplicationDbContextt db = null;
        private static UserDAO instance;
        static object key = new object();
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)//bất đồng bộ , chiếm dụng tài nguyên....
                    {
                        instance = new UserDAO();
                    }
                }
                return instance;
            }
        }
        public UserDAO() { db = new ApplicationDbContextt(); }
        public int Insert(User entity)
        {
            //Mac dinh cho kich hoat
            var user = db.Users.SingleOrDefault(x => x.UserID== entity.UserID);
            if (user == null)
            {
               
                KhachHang kh = new KhachHang();
                kh.GioiTinh = true;
                kh.Email = entity.Email;
                kh.HoTen = entity.Name;
                KhachHangDAO.Instance.CreateKhachHang(kh);                
                db.AspNetUsers.Add(entity);
                db.SaveChanges();
                return entity.UserID;
            }
            else
            {
                return user.UserID;
            }
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.UserID);
                user.Name = entity.Name;
                user.GroupID = entity.GroupID;
                user.DiaChiChiTiet = entity.DiaChiChiTiet;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Email.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public User GetByID(int UserID)
        {
            return db.Users.SingleOrDefault(x => x.UserID == UserID);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName, string passWordSalt, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonGroup.ADMIN_GROUP || result.GroupID == CommonGroup.MOD_GROUP)
                    {
                        if (result.Status == false)
                            return -1;
                        else
                        {
                            if (result.PasswordSalt == passWordSalt)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == true)
                    {
                        if (result.PasswordSalt == passWordSalt)
                            return 1;
                        else
                            return -2;
                    }
                    else
                        return -1;
                }
            }
        }
        public bool? ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
        public List<User> ListAll()
        {
            return db.Users.ToList();
        }
        public bool Account(string userName, string password)
        {
            var res = db.Users.Where(x => x.UserName == userName && x.Password == password).SingleOrDefault();
            return true;
        }
    }
}