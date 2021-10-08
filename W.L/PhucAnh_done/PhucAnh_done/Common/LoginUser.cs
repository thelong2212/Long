using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhucAnh_done.Common
{
    [Serializable]
    public class LoginUser
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public int? GroupID { set; get; }
    }
}