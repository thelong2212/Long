using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Web_PA.Models;

namespace Web_PA.DAO
{
    public class UserGroupDAO
    {
        ApplicationDbContextt db = null;
        private static UserGroupDAO instance;
        static object key = new object();
        public static UserGroupDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)//bất đồng bộ , chiếm dụng tài nguyên....
                    {
                        instance = new UserGroupDAO();
                    }
                }
                return instance;
            }
        }
        public UserGroupDAO()
        {
            db = new ApplicationDbContextt();
        }
        public int Insert(UserGroup UserID)
        {
            db.UserGroups.Add(UserID);
            db.SaveChanges();
            return UserID.UserGroupID;
        }
        public bool Update(UserGroup userID)
        {
            try
            {
                var userGroup = db.UserGroups.Find(userID.UserGroupID);
                userGroup.GroupName = userID.GroupName;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int userID)
        {
            try
            {
                var userGruop = db.UserGroups.Find(userID);
                db.UserGroups.Remove(userGruop);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public UserGroup ViewDetail(int userGroupID)
        {
            return db.UserGroups.Find(userGroupID);
        }
        public IEnumerable<UserGroup> ListAllpaging(string searchString, int page, int pageSize)
        {
            IQueryable<UserGroup> model = db.UserGroups;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.GroupName.Contains(searchString));
            }
            return model.OrderBy(x => x.UserGroupID).ToPagedList(page, pageSize);
        }
    }
}